using ChupaChupa.Business.Controller;
using ChupaChupa.Business.Database.DAO;
using ChupaChupa.Business.RSS.Parser;
using ChupaChupa.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;

namespace ChupaChupa.Business.RSS.Scheduler
{
    public class RssScheduler
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(RssScheduler));

        private const int DEFAULT_INTERVAL_IN_MINUTES = 60;

        private Timer _timer;

        public RssScheduler() {
            this.initTimer(TimeSpan.FromMinutes(DEFAULT_INTERVAL_IN_MINUTES).TotalMilliseconds);
        }

        public RssScheduler(double interval) {
            this.initTimer(interval);
        }

        private void initTimer(double interval) {
            _timer = new Timer();
            _timer.Interval = interval;
            _timer.Elapsed += timerElapsed;
        }

        public void run() {
            _timer.Enabled = true;
            _timer.Start();
        }

        public void stop() {
            _timer.Enabled = false;
            _timer.Stop();
        }

        private void timerElapsed(object sender, ElapsedEventArgs e) {
            IList<RssChannel> channels = new List<RssChannel>();
            Stream stream;
            IController controller = new RssChannelController();
            RssChannelDAO dao = new RssChannelDAO();
            RssChannel current;
            channels = dao.findAll();

            if (channels != null) { 
                foreach (RssChannel channel in channels) {
                    if (channel != null && channel.RssLink != null && channel.RssLink.Length > 0) {
                        string channelUrl = channel.RssLink;
                        
                        stream = this.getWebContentAsStream(channelUrl);
                        if (stream == null) {
                            continue;
                        }
                        
                        // TODO: check with skipdays and skiphours
                        current = this.processStream(stream);
                        if (current == null) {
                            continue;
                        }

                        channel.update(current);
                        channel.RssLink = channelUrl;
                        if (controller.controlData(channel)) {
                            dao.saveOrUpdate(channel);
                        }
                    }
                }
            }
        }

        private Stream getWebContentAsStream(String url) {
            HttpWebRequest request;
            HttpWebResponse response;
            Stream ret;

            try {
                request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                response = request.GetResponse() as HttpWebResponse;
                ret = response.GetResponseStream();
            } catch (Exception ex) {
                Logger.Error("Unable to get content from url " + url + " because: " + ex.Message);
                ret = null;
            }
            return ret;
        }

        private RssChannel processStream(Stream stream) {
            RssChannel channel = null;
            
            if (stream == null) {
                return channel;
            }

            XmlDocument document = new XmlDocument();
            try {
                document.Load(new XmlStreamReader(stream));
                RssChannelParser parser = new RssChannelParser();
                if (parser.parseData(document.DocumentElement.SelectSingleNode("channel"))) {
                    channel = parser.getExtractedData() as RssChannel;
                }
            } catch (Exception ex) {
                Logger.Error("Unable to load XML content because: " + ex.Message);
            }
            stream.Close();
            return channel;
        }
    }
}
