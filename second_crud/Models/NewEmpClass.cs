using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace second_crud.Models
{
    public class NewEmpClass
    {
        [Key]

        [Display(Name = "Id")]
        public int emp_id { get; set; }
       


        [Required(ErrorMessage = "Employee Name !!!!")]
        [Display(Name = "Entert Name Here")]
        public string enp_name { get; set; }


        [Required(ErrorMessage = "Please Enter The Email !!!!")]
        [Display(Name = "Entert Email Here")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
      

        [Required(ErrorMessage ="Please Enter Real age")]
        [Display(Name ="Age")]
        [Range(20,50)]
        public int age { get; set; }


        [Required(ErrorMessage ="Enter Employee Salary")]
        [Display(Name ="Salary")]
        public decimal salary { get; set; }
    }
}
