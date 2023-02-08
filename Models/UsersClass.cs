using System.Runtime.Serialization;
using System.Xml.Linq;

namespace TestingWebAPi.Models
{
    public class UsersModels
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Name")]
        public string? Name { get; set; }

        [DataMember(Name = "EmailId")]
        public string? EmailId { get; set; }

        [DataMember(Name = "Mobile")]
        public string? Mobile { get; set; }

        [DataMember(Name = "Address")]
        public string? Address { get; set; }

        [DataMember(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}
