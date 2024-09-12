using FileViewerApp.Services;

namespace FileViewerApp
{
    internal static class Program
    {        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IFileService fileService = new FileService();
            Application.Run(new MainForm(fileService));
        }
    }
}