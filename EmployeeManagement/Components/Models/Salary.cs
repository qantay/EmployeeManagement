using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Components.Models;

public class Salary
{
    [Key]
    public int Id { get; set; }
    
    public int BaseSalary { get; set; }
    [Required(ErrorMessage = "base_salary is required")]
    
    public int Allowance { get; set; }
    [Required(ErrorMessage = "Allowance is required")]
    
    public int Bonus { get; set; }
    [Required(ErrorMessage = "Bonus is required")]
    
    public int Total { get; set; }
    [Required(ErrorMessage = "Total is required")]
    
    public int PayMonth { get; set; }
    [Required(ErrorMessage = "Pay month is required")]
    
    public int EmId { get; set; }
    [ForeignKey("EmId")]
    
    
    public Employee Employee { get; set; }
}