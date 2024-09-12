using FileViewerApp.Models;
using FileViewerApp.Services;

namespace FileViewerApp
{
    public partial class MainForm : Form
    {
        private readonly FileService _fileService;

        public MainForm()
        {
            InitializeComponent();
            _fileService = new FileService();
        }

        private async void btnLoadFile_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text;
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found.");
                return;
            }

            var fileInfo = _fileService.GetFileInfo(filePath);
            lblFileInfo.Text = $"File: {fileInfo.FileName}, Size: {fileInfo.Size} bytes, Created: {fileInfo.CreatedDate}";

            var data = await _fileService.GetFileDataAsync(filePath);
            dgvFileData.DataSource = data.ToList();

            lblFirstElement.Text = $"First: {data.FirstOrDefault()?.ToString() ?? "No data"}";
            lblLastElement.Text = $"Last: {data.LastOrDefault()?.ToString() ?? "No data"}";
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            string filterCriteria = txtFilterCriteria.Text;
            var data = dgvFileData.DataSource as IEnumerable<FileDataModel>;

            if (data != null)
            {
                var filteredData = await _fileService.FilterDataAsync(data, filterCriteria);
                dgvFileData.DataSource = filteredData.ToList();

                lblFilteredElements.Text = int.TryParse(filterCriteria, out int age)
                    ? $"Age = {age}: {string.Join(", ", filteredData.Select(d => d.Name))}"
                    : $"Name contains '{filterCriteria}': {string.Join(", ", filteredData.Select(d => d.Name))}";
            }
            else
            {
                MessageBox.Show("No data to filter.");
            }
        }
    }
}
