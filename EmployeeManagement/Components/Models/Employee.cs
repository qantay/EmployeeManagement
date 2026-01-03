using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.Models;

namespace EmployeeManagement.Components.Models;
public class Employee
{
    [Key]
    public int Id { get; set; }
   
    public string FullName { get; set; }
    [Required(ErrorMessage = "Employee Name is required")]
    
    public string DOB { get; set; }
    [Required(ErrorMessage = "Date of birth is required")]
    
    public string Gender { get; set; }
    [Required(ErrorMessage = "Gender is required")]
    
    public string Phone { get; set; }
    [Required(ErrorMessage = "Phone is required")]
    
    public string Place { get; set; }
    [Required(ErrorMessage = "Address is required")]
    
    public decimal Salary { get; set; }
    [Required(ErrorMessage = "Salary is required")]
    
    public int DepartId { get; set; }
    [ForeignKey("DepartId")]
    
    public int PosId { get; set; }
    [ForeignKey("PosId")]
    
    
    public Position Position { get; set; }

    public Department Department { get; set; }
    public ICollection<Attendance> Attendances { get; set; }
    public ICollection<Salary> Salaries { get; set; }

}