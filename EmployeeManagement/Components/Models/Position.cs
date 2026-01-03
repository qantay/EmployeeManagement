using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Components.Models;

namespace EmployeeManagement.Models;

public class Position
{
    [Key]
    public int Id { get; set; }
    
    public string PosName { get; set; }
    [Required(ErrorMessage = "Position name is required")]
   
    public decimal BaseSalary { get; set; }
    [Required(ErrorMessage = "Base salary is required")]
    
    public ICollection<Employee> Employees { get; set; }
}