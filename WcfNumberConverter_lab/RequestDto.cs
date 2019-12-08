using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfNumberConverter_lab
{

    [DataContract]
    public class RequestDto
    {
        [DataMember]
        public int ArabNumber { get; set; }

        [DataMember]
        public string RomanNumber { get; set; }

        [DataMember]
        public DateTime Time { get; set; }
    }
}