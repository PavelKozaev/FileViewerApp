namespace FileViewerApp.Models
{
    public class FileDataModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Phone: {Phone}";
        }
    }
}