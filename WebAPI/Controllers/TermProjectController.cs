using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data;

using Utilities;
using System.Data.SqlClient;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TermProjectController : Controller
    {
 {

        // GET: api/service/Merchants
        [HttpGet("GetDepartments")]
        public List<Department> GetDepartments()
        {
            string query = "SELECT * FROM Departments";

            DBConnect objDB = new DBConnect();
            DataSet ds = objDB.GetDataSet(query);

            Department department = new Department();
            List<Department> dpts = new List<Department>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                department = new Department();
                department.DepartmentID = int.Parse(dr["Id"].ToString());
                department.DepartmentName = dr["Dept_Name"].ToString();
                dpts.Add(department);
            }
            return dpts;
        } //end of GetDepartments


        // GET: api/Merchants/GetProductCatalog
        [HttpGet("GetProductCatalog/{DepartmentNumber}")]
        public List<Product> GetProductCatalog(string DepartmentNumber)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand sqlComm = new SqlCommand();
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.CommandText = "GetProducts";

            SqlParameter deptNum = new SqlParameter("@departmentID", DepartmentNumber);
            deptNum.Direction = ParameterDirection.Input;
            deptNum.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(deptNum);

            DataSet ds = objDB.GetDataSetUsingCmdObj(sqlComm);

            Product product = new Product();

            List<Product> pl = new List<Product>();

            if (ds.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    product = new Product();
                    product.ProductID = dr["Product Number"].ToString();
                    product.Title = dr["Title"].ToString();
                    product.Description = dr["Description"].ToString();
                    product.Price = Convert.ToDouble(dr["Price"].ToString());
                    product.Quantity = Convert.ToInt32(dr["QOH"]);
                    product.ImageUrl = dr["image URL"].ToString();
                    product.DepartmentID = dr["Dept_Num"].ToString();
                    pl.Add(product);
                }
            }
            return pl;
        } //end of GetProductCatalog


        // POST: api/Merchants/RegisterSite
        [HttpPost("RegisterSite/{SiteID}/{Description}/{APIKey}/{email}")]
        public bool RegisterSite(string SiteID, string Description, string APIKey, string email, [FromBody]ContactInformation information)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand sqlComm = new SqlCommand();
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.CommandText = "RegisterSite";


            SqlParameter inputParameter = new SqlParameter("@ID", SiteID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(inputParameter);


            inputParameter = new SqlParameter("@Name", information.Name);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Address", information.Address);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(inputParameter);


            inputParameter = new SqlParameter("@City", information.City);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@State", information.State);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Zip", information.ZipCode);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            sqlComm.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Email", email);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Phone", information.Phone);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(inputParameter);


            inputParameter = new SqlParameter("@Desc", Description);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@ApiKey", APIKey);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(inputParameter);



            int result = objDB.DoUpdateUsingCmdObj(sqlComm);

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        } //end of RegisterSite


        // POST: api/Merchants/RecordPurchase
        [HttpPost("RecordPurchase/{ProductID}/{Quantity:int}/{SellerSiteID}/{APIKey}")]
        public bool RecordPurchase(string ProductID, int Quantity, string SellerSiteID, string APIKey, [FromBody]Customer information)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand sqlComm = new SqlCommand();
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.CommandText = "RecordPurchase";

            SqlParameter inputParameter = new SqlParameter("@productID", ProductID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@quantity", Quantity);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            sqlComm.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@sellerSiteID", SellerSiteID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@apikey", APIKey);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@customerID", information.CustomerID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(inputParameter);



            int result = objDB.DoUpdateUsingCmdObj(sqlComm);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        } //end of RecordPurchase
    } //end of class
} //end of namespace

