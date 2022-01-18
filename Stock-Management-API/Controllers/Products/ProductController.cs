using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManagement_Lib;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Stock_Management_API.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public ProductController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        //[HttpGet]
        //public JsonResult Get()
        //{
        //    string query = @"LOAD QUERY";
        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("StockTakeManagementAppCon");
        //    SqlDataReader reader;

        //    using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
        //    {
        //        sqlConnection.Open();
        //        using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
        //        {
        //            reader = cmd.ExecuteReader();
        //            table.Load(reader);

        //            reader.Close();
        //            sqlConnection.Close();
        //        }
        //    }
        //    return new JsonResult(table);
        //}

        //[HttpPost]
        //public JsonResult Post(Product prd)
        //{
        //    string query = @"INSERT QUERY";
        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("StockTakeManagementAppCon");
        //    SqlDataReader reader;
        //    using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
        //    {
        //        sqlConnection.Open();
        //        using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
        //        {
        //            reader = cmd.ExecuteReader();
        //            table.Load(reader);

        //            reader.Close();
        //            sqlConnection.Close();


        //        }
        //    }
        //    return new JsonResult("Added Successfully");
        //}

        [HttpPut]
        public JsonResult Put()
        {
            string query = @"UPDATE QUERY";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("StockTakeManagementAppCon");
            SqlDataReader reader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    reader = cmd.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    sqlConnection.Close();


                }
            }
            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{prd_guid}")]
        public JsonResult Delete()
        {
            string query = @"Delete Query";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("StockTakeManagementAppCon");
            SqlDataReader reader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    reader = cmd.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    sqlConnection.Close();


                }
            }
            return new JsonResult("Deleted Successfully");
        }

        [HttpGet]
        public JsonResult Get()
        {
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DBAccess");
            SqlDataReader reader = null;
            bool successOUT = false;
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
                {
                    string storedProcedure = "stp_Product_Get";
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //CH - Input Parameters
                        //cmd.Parameters.Add(new SqlParameter("@prd_guid", prd.Guid));

                        //CH - Output parameter(s)
                        SqlParameter success = new SqlParameter("@successOUT", successOUT);
                        success.Direction = ParameterDirection.InputOutput;
                        cmd.Parameters.Add(success);
                        sqlConnection.Open();
                        //CH - OpenSQL Connection
                        //CH - Exexute Command
                        reader = cmd.ExecuteReader();

                        table.Load(reader);
                        //provider: Shared Memory Provider, error: 0 - No process is on the other end of the pipe -- GOOGLE THIS AND FIX THEN APPLY TO OTHER API ENDPOINTS

                        //CH - Validate that the sp has run successfully
                        //successOUT = (bool)cmd.Parameters["@successOUT"].Value;
                        //if (successOUT)
                        //{
                        //    table.Load(reader);
                        //}
                        //CH - Return Output Params and assign values

                        //CH - Close SQL Connection and Reader.
                        reader.Close();
                        sqlConnection.Close();
                    }
                }

                return new JsonResult(table);
            }
            catch (Exception ex)
            {
                return new JsonResult("Failed to Load");
            }
        }

        [HttpPost]
        public JsonResult PostSP(Product prd)
        {
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("StockTakeManagementAppCon");
            SqlDataReader reader;
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
                {
                    string storedProcedure = "stp_Product_Save";
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //CH - Input Parameters
                        cmd.Parameters.Add(new SqlParameter("@prd_guid", prd.Guid));
                        cmd.Parameters.Add(new SqlParameter("@prd_guid", prd.Guid));

                        //CH - Output parameter(s)
                        SqlParameter ParamId = cmd.Parameters.Add("@Id", SqlDbType.Int);
                        ParamId.Direction = ParameterDirection.InputOutput;
                        cmd.Parameters.Add(ParamId);
                        //CH - OpenSQL Connection
                        sqlConnection.Open();
                        //CH - Exexute Command
                        reader = cmd.ExecuteReader();
                        table.Load(reader);
                        //CH - Return Output Params and assign values
                        int ID = (int)ParamId.Value;
                        //CH - Close SQL Connection and Reader.
                        reader.Close();
                        sqlConnection.Close();
                    }
                }
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult("Failed to Load");
            }
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (FileStream stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch (Exception ex)
            {
                return new JsonResult("anonymous.png");
            }
        }

        [Route("GetAllProductGroupNames")]
        [HttpGet]
        public JsonResult GetAllProductGroupNames()
        {
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("StockTakeManagementAppCon");
            SqlDataReader reader;
            bool successOUT = false;
            try
            {      
                using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
                {
                    string storedProcedure = "stp_Product_Group_Get";
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //CH - Input Parameters
                        //cmd.Parameters.Add(new SqlParameter("@prd_guid", prd.Guid));

                        //CH - Output parameter(s)
                        SqlParameter success = new SqlParameter("@successOUT", successOUT);
                        success.Direction = ParameterDirection.InputOutput;
                        cmd.Parameters.Add(success);
                        //CH - OpenSQL Connection
                        sqlConnection.Open();
                        //CH - Exexute Command
                        reader = cmd.ExecuteReader();

                        table.Load(reader);

                        //CH - Validate that the sp has run successfully
                        //successOUT = (bool)cmd.Parameters["@successOUT"].Value;
                        //if (successOUT)
                        //{
                        //    table.Load(reader);
                        //}
                        //CH - Return Output Params and assign values

                        //CH - Close SQL Connection and Reader.
                        reader.Close();
                        sqlConnection.Close();
                    }
                }

                return new JsonResult(table);
            }
            catch (Exception ex)
            {
                return new JsonResult("Failed to Load");
            }
        }
    }
}
