using ChupaChupa.Business.Controller;
using ChupaChupa.Business.Database.DAO;
using ChupaChupa.Business.RSS.Parser;
using ChupaChupa.Business.RSS.Scheduler;
using ChupaChupa.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ChupaChupa.Business.RSS.Constructor
{
    public class RssConstructor
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(RssConstructor));

        public RssChannel createRssChannel(RssChannel channel)
        {
            Stream stream;
            IController controller = new RssChannelController();
            RssChannelDAO dao = new RssChannelDAO();
            RssChannel parsedChannel;
            RssChannel existingChannel;
            string channelUrl = channel.RssLink;

            if (channel == null || channel.RssLink == null || channel.RssLink.Length == 0) {
                return null;
            }

            existingChannel = dao.findByRssLink(channel.RssLink);
            if (existingChannel != null) {
                return existingChannel;
            }

            stream = this.getWebContentAsStream(channel.RssLink);
            if (stream == null) {
                return null;
            }

            parsedChannel = this.processStream(stream);
            if (parsedChannel == null) {
                return null;
            }

            channel.update(parsedChannel);
            channel.RssLink = channelUrl;

            if (!controller.controlData(channel) || !dao.saveOrUpdate(channel)) {
                return null;
            }
            return channel;
        }

        public RssChannel addRssChannelToDatabase(string urlChannel)
        {
            Stream stream;
            IController controller = new RssChannelController();
            RssChannel parsedChannel;
            
            if (string.IsNullOrEmpty(urlChannel)) {
                return null;
            }

            stream = this.getWebContentAsStream(urlChannel);
            if (stream == null) {
                return null;
            }

            parsedChannel = this.processStream(stream);
            if (parsedChannel == null) {
                return null;
            }

            if (parsedChannel.RssItems != null) {
                foreach (RssItem item in parsedChannel.RssItems) {
                    item.RssChannel = parsedChannel;
                }
            }
            parsedChannel.RssLink = urlChannel;

            if (!controller.controlData(parsedChannel)) {
                return null;
            }
            return parsedChannel;
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
            }
            catch (Exception ex) {
                Logger.Error("Unable to load XML content because: " + ex.Message);
            }
            stream.Close();
            return channel;
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
    }
}
