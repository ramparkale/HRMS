namespace HRMS.Models
{
    public class Designation
    {
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        //public bool IsActive { get; set; } = true;

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }

}
