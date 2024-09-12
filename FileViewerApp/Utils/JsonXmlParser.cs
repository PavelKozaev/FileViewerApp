using System.Xml.Linq;
using Newtonsoft.Json;
using FileViewerApp.Models;

namespace FileViewerApp.Utils
{
    public static class JsonXmlParser
    {
        public static async Task<IEnumerable<FileDataModel>> ParseJsonAsync(string jsonContent)
        {
            return await Task.Run(() => JsonConvert.DeserializeObject<List<FileDataModel>>(jsonContent));
        }

        public static async Task<IEnumerable<FileDataModel>> ParseXmlAsync(string xmlContent)
        {
            return await Task.Run(() =>
            {
                var xdoc = XDocument.Parse(xmlContent);
                return xdoc.Descendants("Person").Select(x => new FileDataModel
                {
                    Name = (string)x.Element("Name"),
                    Age = (int)x.Element("Age"),
                    Phone = (string)x.Element("Phone")
                });
            });
        }
    }
}
