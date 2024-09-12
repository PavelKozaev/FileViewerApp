using FileViewerApp.Models;
using FileViewerApp.Utils;
using Newtonsoft.Json;
using System.Xml;

namespace FileViewerApp.Services
{
    public class FileService : IFileService
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

        public async Task<List<FileDataModel>> GetFileDataAsync(string filePath)
        {
            var fileExtension = Path.GetExtension(filePath).ToLower();
            string fileContent;

            try
            {
                fileContent = await File.ReadAllTextAsync(filePath);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"File not found: {ex.Message}");
                return new List<FileDataModel>();
            }
            catch (IOException ex)
            {
                MessageBox.Show($"I/O error while reading file: {ex.Message}");
                return new List<FileDataModel>();
            }

            try
            {
                if (fileExtension == ".json")
                {
                    return (await JsonXmlParser.ParseJsonAsync(fileContent)).ToList();
                }
                else if (fileExtension == ".xml")
                {
                    return (await JsonXmlParser.ParseXmlAsync(fileContent)).ToList();
                }
                else
                {
                    MessageBox.Show("Unsupported file format.");
                    return new List<FileDataModel>();
                }
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Failed to parse JSON: {ex.Message}");
                return new List<FileDataModel>();
            }
            catch (XmlException ex)
            {
                MessageBox.Show($"Failed to parse XML: {ex.Message}");
                return new List<FileDataModel>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
                return new List<FileDataModel>();
            }
        }

        public async Task<IEnumerable<FileDataModel>> FilterDataAsync(IEnumerable<FileDataModel> data, string criteria)
        {
            return await Task.Run(() =>
            {
                if (int.TryParse(criteria, out int age))
                {
                    return data.Where(d => d.Age == age);
                }
                else
                {
                    return data.Where(d => d.Name.Contains(criteria, StringComparison.OrdinalIgnoreCase));
                }
            });
        }
    }
}
