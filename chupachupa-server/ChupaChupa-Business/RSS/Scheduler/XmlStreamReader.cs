using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.RSS.Scheduler
{
    public class XmlStreamReader : StreamReader
    {
        private String _stored;
        private Dictionary<String, String> _replacements;

        public XmlStreamReader(Stream stream) : base(stream) {
            this.init();
        }

        public XmlStreamReader(string path) : base(path) {
            this.init();
        }
        public XmlStreamReader(Stream stream, bool detectEncodingFromByteOrderMarks) : base(stream, detectEncodingFromByteOrderMarks) {
            this.init();
        }
        public XmlStreamReader(Stream stream, Encoding encoding) : base(stream, encoding) {
            this.init();
        }
        public XmlStreamReader(string path, bool detectEncodingFromByteOrderMarks) : base(path, detectEncodingFromByteOrderMarks) {
            this.init();
        }
        public XmlStreamReader(string path, Encoding encoding) : base(path, encoding) {
            this.init();
        }
        public XmlStreamReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks) : base(stream, detectEncodingFromByteOrderMarks) {
            this.init();
        }
        public XmlStreamReader(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks) : base(path, encoding, detectEncodingFromByteOrderMarks) {
            this.init();
        }
        public XmlStreamReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize) : base(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize) {
            this.init();
        }
        public XmlStreamReader(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize) : base(path, encoding, detectEncodingFromByteOrderMarks, bufferSize) {
            this.init();
        }
        public XmlStreamReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen) : base(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen) {
            this.init();
        }

        public override int Read(char[] buffer, int index, int count) {
            int readed = base.Read(buffer, index, count);
            if (readed < 0) {
                return readed;
            }
//             } else if (readed == 0) {
//                 _stored.CopyTo(0, buffer, index, Math.Min(_stored.Length, count));
//                 if (_stored.Length > count) {
//                     _stored = _stored.Substring((_stored.Length - 1) - count, _stored.Length - count);
//                 }
//                 return Math.Min(_stored.Length, count);                
//             }
            return this.replaceSequenceInBuffer(buffer, index, count, readed);   
        }
        public override Task<int> ReadAsync(char[] buffer, int index, int count) {
            return base.ReadAsync(buffer, index, count);
        }

        public override int ReadBlock(char[] buffer, int index, int count) {
            return base.ReadBlock(buffer, index, count);
        }
        public override Task<int> ReadBlockAsync(char[] buffer, int index, int count) {
            return base.ReadBlockAsync(buffer, index, count);
        }

        public override string ReadLine() {
            return base.ReadLine();
        }
        public override Task<string> ReadLineAsync() {
            return base.ReadLineAsync();
        }

        public override string ReadToEnd() {
            return base.ReadToEnd();
        }
        public override Task<string> ReadToEndAsync() {
            return base.ReadToEndAsync();
        }

        private void init() {
            _replacements = new Dictionary<string, string>();
            _replacements["&nbsp;"] = " ";

            _stored = "";
        }

        private int replaceSequenceInBuffer(char[] buffer, int index, int count, int readed) {
            String process;
            if (_replacements == null || buffer == null) {
                return readed;
            }

            process = _stored + new String(buffer, index, readed);
            _stored = "";

            foreach (KeyValuePair<String, String> entry in _replacements) {
                process = process.Replace(entry.Key, entry.Value);
            }

            if (readed > 0) { 
                foreach (KeyValuePair<String, String> entry in _replacements) {
                    for (int i = entry.Key.Length; i > 0; --i) {
                        if (process.EndsWith(entry.Key.Substring(0, i))) { 
                            _stored = entry.Key.Substring(0, i);
                            process = process.Remove((process.Length - 1) - i, i);
                            break;
                        }
                    }
                }
            }

            process.CopyTo(0, buffer, index, Math.Min(process.Length, count));
            if (process.Length > count && process.Length > 0) {
                _stored = process.Substring((process.Length - 1) - count, process.Length - count) + _stored;
            }
            return Math.Min(process.Length, count);
        }
    }
}
