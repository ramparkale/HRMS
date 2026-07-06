namespace HRMS.Models
{
    public class EmployeeDocument
    {
        public int DocumentId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public string DocumentType { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public DateTime UploadedDate { get; set; }
            = DateTime.Now;
    }
}
