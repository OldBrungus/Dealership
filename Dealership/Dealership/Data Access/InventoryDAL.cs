using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using Dealership.Helpers;
using Dealership.Interfaces;
using Dealership.Models;

namespace Dealership.Data_Access
{
    public class InventoryDAL : IInventoryDAL
    {
        public List<Vehicle> GetNewOrUsedVehicles(bool isNew, string searchTerm, int? minYear, int? maxYear, int? minPrice, int? maxPrice)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@new", isNew);
            cmd.Parameters.AddWithValue("@minYear", minYear.HasValue ? minYear.Value : 0);
            cmd.Parameters.AddWithValue("@minPrice", minPrice.HasValue ? minPrice.Value : 0);
            
            if (!string.IsNullOrEmpty(searchTerm))
            {
                cmd.Parameters.AddWithValue("@searchTerm", searchTerm);
            }

            if (maxYear > 0)
            {
                cmd.Parameters.AddWithValue("@maxYear", maxYear);
            }

            if (maxPrice > 0)
            {
                cmd.Parameters.AddWithValue("@maxPrice", maxPrice);
            }

            cmd.CommandText = "dbo.GetNewOrUsedVehicles";

            using (cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Vehicle vehicle = new Vehicle();
                        vehicle.BodyStyle = new BodyStyle();
                        vehicle.Color = new Color();
                        vehicle.Interior = new Interior();
                        vehicle.Make = new Make();
                        vehicle.Model = new Model();
                        vehicle.TransmissionType = new TransmissionType();

                        vehicle.BodyStyle.BodyStyleID = ViewModelMappingHelper.Parse<int>(reader, "BodyStyleID");
                        vehicle.BodyStyle.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "BodyStyle");
                        vehicle.Color.ColorID = ViewModelMappingHelper.Parse<int>(reader, "ColorID");
                        vehicle.Color.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Color");
                        vehicle.Description = ViewModelMappingHelper.Parse<string>(reader, "Description");
                        vehicle.Featured = ViewModelMappingHelper.Parse<bool>(reader, "Featured");
                        vehicle.ID = ViewModelMappingHelper.Parse<int>(reader, "ID");
                        vehicle.Interior.InteriorID = ViewModelMappingHelper.Parse<int>(reader, "InteriorID");
                        vehicle.Interior.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Interior");
                        vehicle.Make.MakeID = ViewModelMappingHelper.Parse<int>(reader, "MakeID");
                        vehicle.Make.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Make");
                        vehicle.Mileage = ViewModelMappingHelper.Parse<int>(reader, "Mileage");
                        vehicle.Model.Make = vehicle.Make;
                        vehicle.Model.ModelID = ViewModelMappingHelper.Parse<int>(reader, "ModelID");
                        vehicle.Model.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Model");
                        vehicle.MSRP = ViewModelMappingHelper.Parse<int>(reader, "MSRP");
                        vehicle.New = ViewModelMappingHelper.Parse<bool>(reader, "New");
                        vehicle.Picture = ViewModelMappingHelper.Parse<byte[]>(reader, "Picture");
                        vehicle.PictureBase64String = Convert.ToBase64String(vehicle.Picture);
                        vehicle.SalePrice = ViewModelMappingHelper.Parse<int>(reader, "SalePrice");
                        vehicle.TransmissionType.TransmissionTypeID = ViewModelMappingHelper.Parse<int>(reader, "TransmissionTypeID");
                        vehicle.TransmissionType.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "TransmissionType");
                        vehicle.VIN = ViewModelMappingHelper.Parse<string>(reader, "VIN");
                        vehicle.Year = ViewModelMappingHelper.Parse<string>(reader, "Year");

                        vehicles.Add(vehicle);
                    }
                }
            }
            return vehicles;
        }

        public Vehicle GetVehicleByID(int vehicleID)
        {
            Vehicle vehicle = new Vehicle();
            vehicle.ID = vehicleID;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetVehicleByID";
            cmd.Parameters.AddWithValue("@vehicleID", vehicleID);

            using (cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        vehicle.BodyStyle = new BodyStyle();
                        vehicle.Color = new Color();
                        vehicle.Interior = new Interior();
                        vehicle.Make = new Make();
                        vehicle.Model = new Model();
                        vehicle.TransmissionType = new TransmissionType();

                        vehicle.BodyStyle.BodyStyleID = ViewModelMappingHelper.Parse<int>(reader, "BodyStyleID");
                        vehicle.BodyStyle.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "BodyStyle");
                        vehicle.Color.ColorID = ViewModelMappingHelper.Parse<int>(reader, "ColorID");
                        vehicle.Color.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Color");
                        vehicle.Description = ViewModelMappingHelper.Parse<string>(reader, "Description");
                        vehicle.Featured = ViewModelMappingHelper.Parse<bool>(reader, "Featured");
                        vehicle.ID = ViewModelMappingHelper.Parse<int>(reader, "ID");
                        vehicle.Interior.InteriorID = ViewModelMappingHelper.Parse<int>(reader, "InteriorID");
                        vehicle.Interior.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Interior");
                        vehicle.Make.MakeID = ViewModelMappingHelper.Parse<int>(reader, "MakeID");
                        vehicle.Make.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Make");
                        vehicle.Mileage = ViewModelMappingHelper.Parse<int>(reader, "Mileage");
                        vehicle.Model.Make = vehicle.Make;
                        vehicle.Model.ModelID = ViewModelMappingHelper.Parse<int>(reader, "ModelID");
                        vehicle.Model.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Model");
                        vehicle.MSRP = ViewModelMappingHelper.Parse<int>(reader, "MSRP");
                        vehicle.New = ViewModelMappingHelper.Parse<bool>(reader, "New");
                        vehicle.Picture = ViewModelMappingHelper.Parse<byte[]>(reader, "Picture");
                        vehicle.SalePrice = ViewModelMappingHelper.Parse<int>(reader, "SalePrice");
                        vehicle.TransmissionType.TransmissionTypeID = ViewModelMappingHelper.Parse<int>(reader, "TransmissionTypeID");
                        vehicle.TransmissionType.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "TransmissionType");
                        vehicle.VIN = ViewModelMappingHelper.Parse<string>(reader, "VIN");
                        vehicle.Year = ViewModelMappingHelper.Parse<string>(reader, "Year");
                    }
                }
            }

            return vehicle;
        }

        public List<Vehicle> GetVehicles(string searchTerm, int? minYear, int? maxYear, int? minPrice, int? maxPrice)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@minYear", minYear.HasValue ? minYear.Value : 0);
            cmd.Parameters.AddWithValue("@minPrice", minPrice.HasValue ? minPrice.Value : 0);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                cmd.Parameters.AddWithValue("@searchTerm", searchTerm);
            }

            if (maxYear > 0)
            {
                cmd.Parameters.AddWithValue("@maxYear", maxYear);
            }

            if (maxPrice > 0)
            {
                cmd.Parameters.AddWithValue("@maxPrice", maxPrice);
            }

            cmd.CommandText = "dbo.GetVehicles";

            using (cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Vehicle vehicle = new Vehicle();
                        vehicle.BodyStyle = new BodyStyle();
                        vehicle.Color = new Color();
                        vehicle.Interior = new Interior();
                        vehicle.Make = new Make();
                        vehicle.Model = new Model();
                        vehicle.TransmissionType = new TransmissionType();

                        vehicle.BodyStyle.BodyStyleID = ViewModelMappingHelper.Parse<int>(reader, "BodyStyleID");
                        vehicle.BodyStyle.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "BodyStyle");
                        vehicle.Color.ColorID = ViewModelMappingHelper.Parse<int>(reader, "ColorID");
                        vehicle.Color.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Color");
                        vehicle.Description = ViewModelMappingHelper.Parse<string>(reader, "Description");
                        vehicle.Featured = ViewModelMappingHelper.Parse<bool>(reader, "Featured");
                        vehicle.ID = ViewModelMappingHelper.Parse<int>(reader, "ID");
                        vehicle.Interior.InteriorID = ViewModelMappingHelper.Parse<int>(reader, "InteriorID");
                        vehicle.Interior.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Interior");
                        vehicle.Make.MakeID = ViewModelMappingHelper.Parse<int>(reader, "MakeID");
                        vehicle.Make.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Make");
                        vehicle.Mileage = ViewModelMappingHelper.Parse<int>(reader, "Mileage");
                        vehicle.Model.Make = vehicle.Make;
                        vehicle.Model.ModelID = ViewModelMappingHelper.Parse<int>(reader, "ModelID");
                        vehicle.Model.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Model");
                        vehicle.MSRP = ViewModelMappingHelper.Parse<int>(reader, "MSRP");
                        vehicle.New = ViewModelMappingHelper.Parse<bool>(reader, "New");
                        vehicle.Picture = ViewModelMappingHelper.Parse<byte[]>(reader, "Picture");
                        vehicle.PictureBase64String = Convert.ToBase64String(vehicle.Picture);
                        vehicle.SalePrice = ViewModelMappingHelper.Parse<int>(reader, "SalePrice");
                        vehicle.TransmissionType.TransmissionTypeID = ViewModelMappingHelper.Parse<int>(reader, "TransmissionTypeID");
                        vehicle.TransmissionType.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "TransmissionType");
                        vehicle.VIN = ViewModelMappingHelper.Parse<string>(reader, "VIN");
                        vehicle.Year = ViewModelMappingHelper.Parse<string>(reader, "Year");

                        vehicles.Add(vehicle);
                    }
                }
            }
            return vehicles;
        }
        private string FormatPrice(int price)
        {
            return price.ToString("C", CultureInfo.CurrentCulture);
        }

        public Vehicle AddVehicle(Vehicle vehicle)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.AddVehicle";
            cmd.Parameters.AddWithValue("@featured", vehicle.Featured);
            cmd.Parameters.AddWithValue("@make", vehicle.Make.MakeID);
            cmd.Parameters.AddWithValue("@model", vehicle.Model.ModelID);
            cmd.Parameters.AddWithValue("@new", vehicle.New);
            cmd.Parameters.AddWithValue("@bodyStyle", vehicle.BodyStyle.BodyStyleID);
            cmd.Parameters.AddWithValue("@year", vehicle.Year);
            cmd.Parameters.AddWithValue("@transmission", vehicle.TransmissionType.TransmissionTypeID);
            cmd.Parameters.AddWithValue("@color", vehicle.Color.ColorID);
            cmd.Parameters.AddWithValue("@interior", vehicle.Interior.InteriorID);
            cmd.Parameters.AddWithValue("@mileage", vehicle.Mileage);
            cmd.Parameters.AddWithValue("@vin", vehicle.VIN);
            cmd.Parameters.AddWithValue("@msrp", vehicle.MSRP);
            cmd.Parameters.AddWithValue("@salePrice", vehicle.SalePrice);
            cmd.Parameters.AddWithValue("@description", vehicle.Description);
            cmd.Parameters.AddWithValue("@picture", vehicle.Picture);

            using(cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                object id = cmd.ExecuteScalar();
                vehicle.ID = int.Parse(id.ToString());

                return vehicle;
            }
        }

        public List<BodyStyle> GetBodyStyles()
        {
            List<BodyStyle> bodyStyles = new List<BodyStyle>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetBodyStyles";
            
            using(cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BodyStyle style = new BodyStyle();
                        style.BodyStyleID = ViewModelMappingHelper.Parse<int>(reader, "BodyStyleID");
                        style.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "BodyStyle");

                        bodyStyles.Add(style);
                    }
                }
            }
            return bodyStyles;
        }

        public List<Color> GetColors()
        {
            List<Color> colors = new List<Color>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetColors";

            using(cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Color color = new Color();
                        color.ColorID = ViewModelMappingHelper.Parse<int>(reader, "ColorID");
                        color.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Color");

                        colors.Add(color);
                    }
                }
            }

            return colors;
        }

        public List<Interior> GetInteriors()
        {
            List<Interior> interiors = new List<Interior>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetInteriors";

            using(cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Interior interior = new Interior();
                        interior.InteriorID = ViewModelMappingHelper.Parse<int>(reader, "InteriorID");
                        interior.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Interior");

                        interiors.Add(interior);
                    }
                }
            }

            return interiors;
        }

        public List<Make> GetMakes()
        {
            List<Make> makes = new List<Make>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetMakes";

            using(cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Make make = new Make();
                        make.MakeID = ViewModelMappingHelper.Parse<int>(reader, "MakeID");
                        make.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Make");

                        makes.Add(make);
                    }
                }
            }

            return makes;
        }

        public List<Model> GetModels()
        {
            List<Model> models = new List<Model>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetModels";

            using(cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Model model = new Model();
                        model.ModelID = ViewModelMappingHelper.Parse<int>(reader, "ModelID");
                        model.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Model");
                        model.Make = new Make();
                        model.Make.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Make");
                        model.Make.MakeID = ViewModelMappingHelper.Parse<int>(reader, "MakeID");

                        models.Add(model);
                    }
                }
            }

            return models;
        }

        public List<TransmissionType> GetTransmissionTypes()
        {
            List<TransmissionType> transmissionTypes = new List<TransmissionType>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetTransmissions";

            using(cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TransmissionType transmissionType = new TransmissionType();
                        transmissionType.TransmissionTypeID = ViewModelMappingHelper.Parse<int>(reader, "TransmissionTypeID");
                        transmissionType.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "TransmissionType");

                        transmissionTypes.Add(transmissionType);
                    }
                }
            }

            return transmissionTypes;
        }

        public void EditVehicle(EditVehicleViewModel vehicleVM)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.CommandText = "dbo.EditVehicle";
            cmd.Parameters.AddWithValue("@ID", vehicleVM.ID);
            cmd.Parameters.AddWithValue("@makeID", vehicleVM.MakeID);
            cmd.Parameters.AddWithValue("@modelID", vehicleVM.ModelID);
            cmd.Parameters.AddWithValue("@new", vehicleVM.IsNew);
            cmd.Parameters.AddWithValue("@bodyStyleID", vehicleVM.BodyStyleID);
            cmd.Parameters.AddWithValue("@year", vehicleVM.Year);
            cmd.Parameters.AddWithValue("@transmissionTypeID", vehicleVM.TransmissionTypeID);
            cmd.Parameters.AddWithValue("@colorID", vehicleVM.ColorID);
            cmd.Parameters.AddWithValue("@interiorID", vehicleVM.InteriorID);
            cmd.Parameters.AddWithValue("@mileage", vehicleVM.Mileage);
            cmd.Parameters.AddWithValue("@vin", vehicleVM.VIN);
            cmd.Parameters.AddWithValue("@msrp", vehicleVM.MSRP);
            cmd.Parameters.AddWithValue("@salePrice", vehicleVM.SalePrice);
            cmd.Parameters.AddWithValue("@description", vehicleVM.Description);
            cmd.Parameters.AddWithValue("@isFeatured", vehicleVM.IsFeatured);

            if (vehicleVM.Picture != null)
            {
                cmd.Parameters.AddWithValue("@picture", vehicleVM.Picture);
            }
            
            cmd.Parameters.AddWithValue("@isFeatured", vehicleVM.IsFeatured);

            using(cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteVehicle(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.DeleteVehicle";
            cmd.Parameters.AddWithValue("@id", id);

            using(cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<InventoryReport> GetInventoryReportRows()
        {
            List<InventoryReport> results = new List<InventoryReport>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetInventoryReportRows";
            
            using(cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        InventoryReport inventoryReport = new InventoryReport();

                        inventoryReport.StockValue = ViewModelMappingHelper.Parse<int>(reader, "StockValue").ToString("C", CultureInfo.CurrentCulture);
                        inventoryReport.Count = ViewModelMappingHelper.Parse<int>(reader, "Count");
                        inventoryReport.Year = ViewModelMappingHelper.Parse<string>(reader, "Year");
                        inventoryReport.MakeName = ViewModelMappingHelper.Parse<string>(reader, "MakeName");
                        inventoryReport.ModelName = ViewModelMappingHelper.Parse<string>(reader, "ModelName");
                        inventoryReport.IsNew = ViewModelMappingHelper.Parse<bool>(reader, "New");

                        results.Add(inventoryReport);
                    }
                }
            }
            return results;
        }

        public void AddModel(string modelName, int makeID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.AddModel";
            cmd.Parameters.AddWithValue("@modelName", modelName);
            cmd.Parameters.AddWithValue("@makeID", makeID);

            using (cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void AddMake(Make make)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.AddMake";
            cmd.Parameters.AddWithValue("@displayName", make.DisplayName);

            using (cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<State> GetStates()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetStates";
            List<State> states = new List<State>();

            using (cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        State state = new State();
                        state.ID = ViewModelMappingHelper.Parse<int>(reader, "ID");
                        state.StateName = ViewModelMappingHelper.Parse<string>(reader, "StateName");
                        state.StateAbbreviation = ViewModelMappingHelper.Parse<string>(reader, "StateAbbreviation");

                        states.Add(state);
                    }
                }
            }
            return states;
        }

        public List<PurchaseType> GetPurchaseTypes()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetPurchaseTypes";
            List<PurchaseType> purchaseTypes = new List<PurchaseType>();

            using (cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PurchaseType purchaseType = new PurchaseType();
                        purchaseType.ID = ViewModelMappingHelper.Parse<int>(reader, "ID");
                        purchaseType.PurchaseTypeName = ViewModelMappingHelper.Parse<string>(reader, "PurchaseTypeName");

                        purchaseTypes.Add(purchaseType);
                    }
                }
            }
            return purchaseTypes;
        }

        public void Purchase(PurchaseInfo purchase)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.PurchaseVehicle";
            cmd.Parameters.AddWithValue("@vehicleID", purchase.VehicleID);
            cmd.Parameters.AddWithValue("@name", purchase.Name);
            cmd.Parameters.AddWithValue("@phone", purchase.Phone);
            cmd.Parameters.AddWithValue("@email", purchase.Email);
            cmd.Parameters.AddWithValue("@street1", purchase.Street1);
            cmd.Parameters.AddWithValue("@street2", purchase.Street2);
            cmd.Parameters.AddWithValue("@city", purchase.City);
            cmd.Parameters.AddWithValue("@state", purchase.StateID);
            cmd.Parameters.AddWithValue("@zip", purchase.Zip);
            cmd.Parameters.AddWithValue("@purchasePrice", purchase.PurchasePrice);
            cmd.Parameters.AddWithValue("@purchaseType", purchase.PurchaseTypeID);

            using (cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public SalesReportViewModel GetSalesReport(DateTime? startDate, DateTime? endDate)
        {
            SalesReportViewModel model = new SalesReportViewModel();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetSalesReport";
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);

            using (cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        model.TotalSalesCount = ViewModelMappingHelper.Parse<int>(reader, "TotalSalesCount");
                        model.TotalSalesAmount = ViewModelMappingHelper.Parse<int>(reader, "TotalSalesAmount").ToString("C");
                    }
                }
            }
            return model;
        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            List<Vehicle> featuredVehicles = new List<Vehicle>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetFeaturedVehicles";

            using (cmd.Connection = SqlConnectionHelper.GetConnection())
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Vehicle vehicle = new Vehicle();
                        vehicle.ID = ViewModelMappingHelper.Parse<int>(reader, "ID");
                        vehicle.Year = ViewModelMappingHelper.Parse<string>(reader, "Year");
                        vehicle.Make = new Make();
                        vehicle.Make.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Make");
                        vehicle.Model = new Model();
                        vehicle.Model.DisplayName = ViewModelMappingHelper.Parse<string>(reader, "Model");
                        vehicle.SalePrice = ViewModelMappingHelper.Parse<int>(reader, "SalePrice");
                        vehicle.Picture = ViewModelMappingHelper.Parse<byte[]>(reader, "Picture");

                        featuredVehicles.Add(vehicle);
                    }
                }
            }

            return featuredVehicles;
        }
    }
}