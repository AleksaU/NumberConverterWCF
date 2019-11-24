using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WcfNumberConverter_lab.Models
{
    public class Request
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [DataMember]
        public double ArabicNumber { get; set; }

        [Required]
        [DataMember]
        public string RomanNumber { get; set; }

        [Required]
        [DataMember]
        public int Count { get; set; }

        [Required]
        [DataMember]
        public string Time { get; set; }

        public User UsersRequests { get; set; }


    }
}