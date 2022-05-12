using System;

namespace Dealership.Models
{
    public class Model
    {
        public int ModelID { get; set; }
        public Make Make { get; set; }
        public string DisplayName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string DateString { get; set; }
    }
}