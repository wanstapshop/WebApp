using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WanStap.DTO
{
    public class MemberDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string UserName { get; set; }
        public string IdentityId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public int MemberTypeId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
    }

    public class MemberTypeDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}