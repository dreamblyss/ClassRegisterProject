using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace ClassRegisterProject
{
    class Student
    {

        public Guid Id { get; }
      
        [Required(ErrorMessage = "Firstname is required. ")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required. ")]
        public string Lastname { get; set; }

        public string Fullname
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Lastname) ? $"{Lastname} {Firstname}" : Firstname;
            }
        }

        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Gadgets is required. ")]
        public string[] Gadgets { get; set; }

        [Required(ErrorMessage = "Phone number is required. ")]
        public string TelephoneNumber { get; set; }

        
        public override string ToString()
        {
            return $"Id: {Id}\nFullname: {Fullname}\nGender: {Gender}\nGadgets: {string.Join(", ", Gadgets)}\nPhone Number: {TelephoneNumber}";
            
        }
    }
}
