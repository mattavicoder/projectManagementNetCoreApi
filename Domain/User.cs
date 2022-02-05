using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public User()
        {
            Id = 0;
            Name = string.Empty;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Pincode = string.Empty;
            BloodGroup = string.Empty;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName {get;set;}

        public string Email { get; set; }

        public int? PhoneNumber { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Pincode { get; set; }

        public string BloodGroup { get; set; }

        [NotMapped]
        public string FullName 
        {
            get
            {
                return (FirstName + " " + LastName).Trim();
            } 
            set{}   
        }
    }
}