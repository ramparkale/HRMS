namespace HRMS.DTO
{
    public class UploadEmployeeDocumentDto
    {
        public int EmployeeId { get; set; }

        public string DocumentType { get; set; }

        public IFormFile File { get; set; }
    }
}
