using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BorgunRpgClient.Model.Mpi
{
    [DataContract]
    public class ValidationResponse
    {
        [DataMember(Name ="XId")]
        public string XId { get; set; }

        [DataMember(Name ="MdStatus")]
        public string MdStatus { get; set; }

        [DataMember(Name ="MdErrorMessage")]
        public string MdErrorMessage { get; set; }

        [DataMember(Name ="EnrollmentStatus")]
        public string EnrollmentStatus { get; set; }

        [DataMember(Name ="AuthenticationStatus")]
        public string AuthenticationStatus { get; set; }

        [DataMember(Name ="ECI")]
        public string Eci { get; set; }

        [DataMember(Name ="CAVV")]
        public string Cavv { get; set; }

        [DataMember(Name ="CAVVAlgorithm")]
        public string CavvAlgorithm { get; set; }

        [DataMember(Name ="PAResVerified")]
        public string PaResVerified { get; set; }

        [DataMember(Name ="PAResSyntaxOK")]
        public string PaResSyntaxOk { get; set; }
    }
}
