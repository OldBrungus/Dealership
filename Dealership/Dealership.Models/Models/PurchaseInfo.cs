using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Dealership.Models
{
    public class PurchaseInfo : IValidatableObject
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public int StateID { get; set; }
        public string Zip { get; set; }
        public int? PurchasePrice { get; set; }
        public int? SalePrice { get; set; }
        public PurchaseType PurchaseType { get; set; }
        public int PurchaseTypeID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            bool validEmail = false;

            if (string.IsNullOrEmpty(Phone) && string.IsNullOrEmpty(Email))
            {
                errors.Add(new ValidationResult("Please enter a phone number or email address", new[] {"Phone"}));
            }
            else if (!string.IsNullOrEmpty(Email) && Email.Contains("@"))
            {
                validEmail = true;
            }

            if ((string.IsNullOrEmpty(Phone) || !Regex.Match(Phone,@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$").Success) && !validEmail)
            {
                errors.Add(new ValidationResult("Please enter a 10 digit phone number", new[] { "Phone" }));
            }

            if (string.IsNullOrEmpty(Street1))
            {
                errors.Add(new ValidationResult("Please enter a street address", new[] { "Street1" }));
            }

            if (string.IsNullOrEmpty(City))
            {
                errors.Add(new ValidationResult("Please enter a city", new[] {"City"}));
            }

            if (string.IsNullOrEmpty(Zip) || Zip.Length != 5)
            {
                errors.Add(new ValidationResult("Please enter a 5 digit zip code", new[] { "Zip" }));
            }

            if (string.IsNullOrEmpty(PurchasePrice.ToString()) || (double)PurchasePrice < ((double)SalePrice * .95))
            {
                errors.Add(new ValidationResult("Purchase price must be at least 95% of sale price", new[] { "PurchasePrice" }));
            }

            return errors;
        }
    }
}