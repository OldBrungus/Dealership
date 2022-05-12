using System;

namespace Dealership.Models
{
    public class Make
    {
        public int MakeID { get; set; }
        public string DisplayName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string DateString { get; set; }
    }
}