using Newtonsoft.Json;
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

        public List<FileDataModel> GetFileData(string filePath)
        {            
            var fileExtension = Path.GetExtension(filePath).ToLower();

            var fileContent = File.ReadAllText(filePath);

            try
            {
                if (fileExtension == ".json")
                {
                    return JsonXmlParser.ParseJson(fileContent).ToList();
                }
                else if (fileExtension == ".xml")
                {
                    return JsonXmlParser.ParseXml(fileContent).ToList();
                }
                else
                {
                    MessageBox.Show("Unsupported file format.");
                    return new List<FileDataModel>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to parse file: {ex.Message}");
                return new List<FileDataModel>();
            }
        }

        public IEnumerable<FileDataModel> FilterData(IEnumerable<FileDataModel> data, string criteria)
        {
            if (int.TryParse(criteria, out int age))
            {
                return data.Where(d => d.Age == age);
            }
            else
            {
                return data.Where(d => d.Name.Contains(criteria, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}