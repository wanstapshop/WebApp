using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WanStap.DTO
{
    public class EstablishmentDTO
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public int EstablishmentTypeID { get; set; }
        public int Capacity { get; set; }
    }
}