using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BorgunRpgClient.Model.Mpi
{
    [DataContract]
    public class EnrollmentResponse
    {
        [DataMember(Name ="ResultStatus")]
        public long ResultStatus { get; set; }

        [DataMember(Name ="MessageId")]
        public string MessageId { get; set; }

        [DataMember(Name ="EnrollmentStatus")]
        public string EnrollmentStatus { get; set; }

        [DataMember(Name ="MdErrorMessage")]
        public string MdErrorMessage { get; set; }

        [DataMember(Name ="MdStatus")]
        public string MdStatus { get; set; }

        [DataMember(Name ="RedirectToACSForm")]
        public string RedirectToAcsForm { get; set; }

        [DataMember(Name ="MD")]
        public string Md { get; set; }

        [DataMember(Name ="RedirectToACSData")]
        public List<RedirectToAcsDatum> RedirectToAcsData { get; set; }

        [DataMember(Name ="MpiToken")]
        public string MpiToken { get; set; }
    }

    public class RedirectToAcsDatum
    {
        [DataMember(Name ="Name")]
        public string Name { get; set; }

        [DataMember(Name ="Value")]
        public string Value { get; set; }
    }
}
