using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WanStap.Models
{
    public class Ride
    {
        [Key]
        public int RideID { get; set; }
        [ForeignKey("Member")]
        
        public int MemberID { get; set; }
        
        public string PlateNumber { get; set; }
        
        public string BrandName { get; set; }
        
        public string Make { get; set; }
        
        public string Color { get; set; }
        [ForeignKey("RideType")]
        public int RideTypeID { get; set; }
        public int? Capacity { get; set; }
        
        public DateTime CreatedDateTime { get; set; }
        
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public int ModifiedBy { get; set; }

        public virtual Member Member { get; set; }
        public virtual RideType RideType { get; set; }
    }

    public class RideType
    {
        [Key]
        public int RideTypeID { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTime CreatedDateTime { get; set; }
        
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public int ModifiedBy { get; set; }
    }
}