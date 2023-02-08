using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using TestingWebAPi.Models;
namespace TestingWebAPi.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration) => _configuration = configuration;
        [HttpGet]
        [Route("GetUsers")]
        public List<UsersModels> GetUsers()
        {
            return LoadUsersFromDB();
        }
        private List<UsersModels> LoadUsersFromDB()
        {
            List<UsersModels> lstmain = new List<UsersModels>();
            
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("Select * from Users", con);
            SqlDataAdapter da = new(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UsersModels obj = new UsersModels();
                obj.Id = (int)dt.Rows[i]["Id"];
                obj.Name = (string?)dt.Rows[i]["Name"];
                obj.EmailId = (string?)dt.Rows[i]["EmailId"];
                obj.Mobile = (string?)dt.Rows[i]["Mobile"];
                lstmain.Add(obj);
            }
            return lstmain;
        }
        [HttpGet]
        [Route("GetUsersById")]
        public List<UsersModels> GetUsersById(int UserId)
        {
            return LoadUsersFromDB().Where(e => e.Id == UserId).ToList();
        }


    }
}
