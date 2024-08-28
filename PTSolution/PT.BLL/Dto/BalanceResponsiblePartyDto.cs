using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PT.BLL.Dto
{
    /// <summary>
    /// Balanc eResponsible Party Dto
    /// </summary>
    [DataContract(Name = "balance_responsible_party_dto")]
    public class BalanceResponsiblePartyDto
    {
        /// <summary>
        /// Code
        /// </summary>
        [DataMember(Name = "brpCode")]
        public string brpCode { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DataMember(Name = "brpName")]
        public string brpName { get; set; }

        /// <summary>
        /// Business Id
        /// </summary>
        [DataMember(Name = "businessId")]
        public string businessId { get; set; }

        /// <summary>
        ///  Coding Scheme
        /// </summary>
        [DataMember(Name = "codingScheme")]
        public string codingScheme { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [DataMember(Name = "country")]
        public string country { get; set; }

        /// <summary>
        /// Validity start
        /// </summary>
        [DataMember(Name = "validityStart")]
        public DateTime validityStart { get; set; }

        /// <summary>
        /// Validity end
        /// </summary>
        [DataMember(Name = "validityEnd")]
        public DateTime validityEnd { get; set; }
    }
}