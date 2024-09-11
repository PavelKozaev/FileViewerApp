﻿using System.Xml.Linq;
using Newtonsoft.Json;
using FileViewerApp.Models;

namespace FileViewerApp.Utils
{
    public static class JsonXmlParser
    {
        public static IEnumerable<FileDataModel> ParseJson(string jsonContent)
        {
            return JsonConvert.DeserializeObject<List<FileDataModel>>(jsonContent);
        }

        public static IEnumerable<FileDataModel> ParseXml(string xmlContent)
        {
            var xdoc = XDocument.Parse(xmlContent);
            return xdoc.Descendants("Person").Select(x => new FileDataModel
            {
                Name = (string)x.Element("name"),
                Age = (int)x.Element("age"),
                Phone = (string)x.Element("phone")
            });
        }
    }
}
