using FileViewerApp.Models;
using FileViewerApp.Utils;

namespace FileViewerApp.Services
{
    public class FileService
    {
        public FileInfoModel GetFileInfo(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            return new FileInfoModel
            {
                FileName = fileInfo.Name,
                Size = fileInfo.Length,
                CreatedDate = fileInfo.CreationTime
            };
        }

        public IEnumerable<FileDataModel> GetFileData(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                if (filePath.EndsWith(".json"))
                    return JsonXmlParser.ParseJson(reader.ReadToEnd());
                else if (filePath.EndsWith(".xml"))
                    return JsonXmlParser.ParseXml(reader.ReadToEnd());
                else
                    throw new NotSupportedException("File format not supported.");
            }
        }

        public IEnumerable<FileDataModel> FilterData(IQueryable<FileDataModel> data, string criteria)
        {
            return data.Where(d => d.Name.Contains(criteria) || d.Age.ToString().Contains(criteria) || d.Phone.Contains(criteria)).ToList();
        }
    }
}
