using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Components.Models;

public class Department
{
    [Key]
    public int Id { get; set; }
    
    public string DepartName { get; set; }
    [Required(ErrorMessage = "Department Name is required")]
    
    public ICollection<Employee> Employees { get; set; }
    
}