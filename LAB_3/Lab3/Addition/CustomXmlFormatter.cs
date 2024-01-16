using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lab3.Addition
{
    public class CustomXmlFormatter : XmlMediaTypeFormatter
    {
        public CustomXmlFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            if (value == null)
                return Task.CompletedTask;

            var xDoc = new XDocument();
            using (var writer = xDoc.CreateWriter())
            {
                var serializer = new XmlSerializer(type);
                serializer.Serialize(writer, value);
            }

            xDoc.Root?.RemoveAll(); // Remove empty elements

            using (var writer = XmlWriter.Create(writeStream, new XmlWriterSettings { Indent = true }))
            {
                xDoc.WriteTo(writer);
            }

            return Task.CompletedTask;
        }
    }
}