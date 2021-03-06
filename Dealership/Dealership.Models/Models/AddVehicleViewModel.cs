using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Dealership.Models
{
    public class AddVehicleViewModel : IValidatableObject
    {
        public string VIN { get; set; }
        public string Year { get; set; }
        public int SalePrice { get; set; }
        public int MSRP { get; set; }
        public bool IsNew { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public int Mileage { get; set; }
        public int BodyStyleID { get; set; }
        public int ColorID { get; set; }
        public int InteriorID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int TransmissionTypeID { get; set; }
        public HttpPostedFileBase Picture { get; set; }
        public List<BodyStyle> BodyStyles { get; set; }
        public List<Color> Colors { get; set; }
        public List<Interior> Interiors { get; set; }
        public List<Make> Makes { get; set; }
        public List<Model> Models { get; set; }
        public List<TransmissionType> TransmissionTypes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(VIN) || !Regex.Match(VIN, @"^[0-z]{17}$").Success)
            {
                errors.Add(new ValidationResult("VIN is required, please enter a 17 digit VIN", new[] { "VIN" }));
            }

            if (string.IsNullOrEmpty(Year) || !Regex.Match(Year,@"^[0-9]{4}$").Success || int.Parse(Year) < 1886 || int.Parse(Year) > DateTime.Now.Year+1 )
            {
                errors.Add(new ValidationResult($"Please enter a 4 digit year between 1886 and {DateTime.Now.Year+1}", new[] { "Year" }));
            }

            if (string.IsNullOrEmpty(SalePrice.ToString()) || SalePrice <= 0)
            {
                errors.Add(new ValidationResult("Sale price is required", new[] { "SalePrice" }));
            }

            if (string.IsNullOrEmpty(MSRP.ToString()) || MSRP <= 0)
            {
                errors.Add(new ValidationResult("MSRP is required", new[] { "MSRP" }));
            }

            if (string.IsNullOrEmpty(Mileage.ToString()) || Mileage <= 0)
            {
                errors.Add(new ValidationResult("Mileage is required", new[] { "Mileage" }));
            }

            if (SalePrice > MSRP)
            {
                errors.Add(new ValidationResult("Sale price must not exceed MSRP"));
            }

            if (IsNew && Mileage > 1000)
            {
                errors.Add(new ValidationResult("New vehicle mileage cannont exceed 1000. Please deselect New"));
            }

            if (Picture == null)
            {
                errors.Add(new ValidationResult("Picture is required"));
            }

            return errors;
        }
    }
}