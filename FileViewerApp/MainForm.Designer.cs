namespace FileViewerApp
{
    partial class MainForm
    {
        private TextBox txtFilePath;
        private Button btnLoadFile;
        private Label lblFileInfo;
        private DataGridView dgvFileData;
        private Label lblFirstElement;
        private Label lblLastElement;
        private TextBox txtFilterCriteria;
        private Button btnFilter;
        private Label lblFilteredElements;

        private void InitializeComponent()
        {
            this.txtFilePath = new TextBox();
            this.btnLoadFile = new Button();
            this.lblFileInfo = new Label();
            this.dgvFileData = new DataGridView();
            this.lblFirstElement = new Label();
            this.lblLastElement = new Label();
            this.txtFilterCriteria = new TextBox();
            this.btnFilter = new Button();
            this.lblFilteredElements = new Label();

            // TextBox: File Path
            this.txtFilePath.Location = new System.Drawing.Point(12, 12);
            this.txtFilePath.Size = new System.Drawing.Size(400, 20);

            // Button: Load File
            this.btnLoadFile.Location = new System.Drawing.Point(420, 10);
            this.btnLoadFile.Size = new System.Drawing.Size(75, 23);
            this.btnLoadFile.Text = "OK";
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);

            // Label: File Information
            this.lblFileInfo.Location = new System.Drawing.Point(12, 40);
            this.lblFileInfo.Size = new System.Drawing.Size(480, 30);

            // DataGridView: File Data
            this.dgvFileData.Location = new System.Drawing.Point(12, 80);
            this.dgvFileData.Size = new System.Drawing.Size(480, 150);

            // Label: First Element
            this.lblFirstElement.Location = new System.Drawing.Point(12, 240);
            this.lblFirstElement.Size = new System.Drawing.Size(480, 30);

            // Label: Last Element
            this.lblLastElement.Location = new System.Drawing.Point(12, 270);
            this.lblLastElement.Size = new System.Drawing.Size(480, 30);

            // TextBox: Filter Criteria
            this.txtFilterCriteria.Location = new System.Drawing.Point(12, 310);
            this.txtFilterCriteria.Size = new System.Drawing.Size(400, 20);

            // Button: Filter
            this.btnFilter.Location = new System.Drawing.Point(420, 310);
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.Text = "Filter";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            // Label: Filtered Elements
            this.lblFilteredElements.Location = new System.Drawing.Point(12, 340);
            this.lblFilteredElements.Size = new System.Drawing.Size(480, 60);

            // MainForm Configuration
            this.ClientSize = new System.Drawing.Size(504, 411);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.lblFileInfo);
            this.Controls.Add(this.dgvFileData);
            this.Controls.Add(this.lblFirstElement);
            this.Controls.Add(this.lblLastElement);
            this.Controls.Add(this.txtFilterCriteria);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.lblFilteredElements);
            this.Text = "File Viewer";
        }
    }
}
