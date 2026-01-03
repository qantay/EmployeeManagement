using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Components.Models;

public class Attendance
{
    [Key] public int Id { get; set; }
    [Required(ErrorMessage = "ID is required")]
    
    public DateTime WorkDate { get; set; }
    [Required(ErrorMessage = "Work Date is required")]
    
    public string Status { get; set; }
    [Required(ErrorMessage = "Status is required")]
    
    public int EmId { get; set; }
    [ForeignKey("EmId")] 
    
    public Employee Employee { get; set; }
   

}