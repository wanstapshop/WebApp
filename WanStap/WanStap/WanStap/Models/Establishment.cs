using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WanStap.Models
{
    public class Establishment
    {
        [Key]
        public int EstablishmentID { get; set; }
        [ForeignKey("Member")]
        
        public int MemberId { get; set; }
        
        public string Name { get; set; }
        [ForeignKey("EstablishmentType")]
        
        public int EstablishmentTypeID { get; set; }
        
        public int Capacity { get; set; }
        
        public DateTime CreatedDateTime { get; set; }
        
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public int ModifiedBy { get; set; }

        public virtual Member Member { get; set; }
        public virtual EstablishmentType EstablishmentType { get; set; }
    }

    public class EstablishmentType
    {
        [Key]
        public int EstablishmentTypeID { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTime CreatedDateTime { get; set; }
        
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public int ModifiedBy { get; set; }
    }
}
