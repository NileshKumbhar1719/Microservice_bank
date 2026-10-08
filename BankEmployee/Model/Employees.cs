using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace BankEmployee.Model
{
    public class Employees
    {
        [Key]
        public int EmpID { get; set; }

        [Required]
        [StringLength(50)]
        public string EmpName { get; set; } = string.Empty;

        [Precision(18, 2)]
        public decimal Salary { get; set; }

        [Required]
        [Phone]
        [StringLength(15)]
        public string EmpPhone { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string EmpDepartment { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string EmpStatus { get; set; } = string.Empty;

        [StringLength(100)]
        public string EmpDesc { get; set; } = string.Empty;






    }
}
