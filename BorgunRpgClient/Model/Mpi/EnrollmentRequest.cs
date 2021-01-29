using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BorgunRpgClient.Model.Mpi
{
    [DataContract]
    public class EnrollmentRequest
    {
        [DataMember(Name = "CardDetails")]
        public CardDetails CardDetails { get; set; }

        [DataMember(Name = "PurchAmount")]
        public long PurchAmount { get; set; }

        [DataMember(Name = "Currency")]
        public string Currency { get; set; }

        [DataMember(Name = "Exponent")]
        public long Exponent { get; set; }

        [DataMember(Name = "TermUrl")]
        public Uri TermUrl { get; set; }

        [DataMember(Name = "MD")]
        public string Md { get; set; }

        [DataMember(Name = "Description")]
        public string Description { get; set; }
    }

    [DataContract]
    public class CardDetails
    {
        [DataMember(Name = "PaymentType")]
        public string PaymentType { get; set; }

        [DataMember(Name = "PAN")]
        public string Pan { get; set; }

        [DataMember(Name = "ExpMonth")]
        public string ExpMonth { get; set; }

        [DataMember(Name = "ExpYear")]
        public string ExpYear { get; set; }
    }
}
