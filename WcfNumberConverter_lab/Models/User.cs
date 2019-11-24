using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace WcfNumberConverter_lab.Models
{
    public class User
    {

        [Key]
        public Guid Id { get; set; }


        [Required]
        [DataMember]
        public string Name { get; set; }

        [Required]
        [DataMember]
        public string Surname { get; set; }

        [Required]
        [DataMember]
        public string Login { get; set; }

        [Required]
        [DataMember]
        public string Password { get; set; }

        [Required]
        [DataMember]
        public string Email { get; set; }
        public ICollection<Request> Requests { get; set; }

    }
}