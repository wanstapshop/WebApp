using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WanStap.Models
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Id { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [ForeignKey("MemberType")]
        [Required]
        public int MemberTypeId { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MemberType MemberType { get; set; }
        public virtual List<Ride> Ride { get; set; }
        public virtual List<Establishment> Establishment { get; set; }
    }

    public class MemberType
    {
        [Key]
        public int MemberTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public int? ModifiedBy { get; set; }
    }
}