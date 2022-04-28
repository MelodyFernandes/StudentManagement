using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string  LastName { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public int Department { get; set; }

        public List<Department> Departments { get; set; }

        public List<int> SelectedCumSubject { get; set; }
        public List<int> SelectedOptSubject { get; set; }

        public List<Subject> Compulsory { get; set; }
        public List<Subject> Optional { get; set; }
    }
}