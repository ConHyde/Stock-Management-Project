using Microsoft.AspNetCore.Mvc;
using StockManagement_Lib;
using StockManagement_Lib.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace Stock_Management_API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public ProductCountController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpPost]
        public JsonResult PostSP(ProductCount count)
        {
            try
            {
                using (DBAccess db = new DBAccess(_configuration.GetConnectionString("DBAccess")))
                {
                    string storedProcedure = "stp_Product_Count_Save";
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, db.DBConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //CH - Input Parameters
                        cmd.Parameters.Add(new SqlParameter("@pdc_guid", count.Guid));
                        cmd.Parameters.Add(new SqlParameter("@pdc_prd_guid", count.ProductGuid));
                        cmd.Parameters.Add(new SqlParameter("@pdc_qty", count.Quantity));
                        cmd.Parameters.Add(new SqlParameter("@pdc_usr_guid", count.UserGuid));
                        cmd.Parameters.Add(new SqlParameter("@pdc_created", count.CreatedDate));
                        cmd.Parameters.Add(new SqlParameter("@pdc_updated", count.UpdatedDate ?? (object)DBNull.Value));
                        //CH - Output parameter(s)
                        SqlParameter successOUT = new SqlParameter("@successOUT", SqlDbType.Bit);
                        successOUT.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(successOUT);
                        //CH - Exexute Command

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                            }
                        }

                        if (!(bool)cmd.Parameters["@successOUT"].Value) { throw new Exception(); }
                    }
                }
                return new JsonResult("Product Count Saved Successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult("Failed to Save Product Count");
            }
        }
    }
}
