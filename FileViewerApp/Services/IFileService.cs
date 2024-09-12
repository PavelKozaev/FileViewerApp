using FileViewerApp.Models;

namespace FileViewerApp.Services
{
    public interface IFileService
    {
        FileInfoModel GetFileInfo(string filePath);
        Task<List<FileDataModel>> GetFileDataAsync(string filePath);
        Task<IEnumerable<FileDataModel>> FilterDataAsync(IEnumerable<FileDataModel> data, string criteria);
    }
}
