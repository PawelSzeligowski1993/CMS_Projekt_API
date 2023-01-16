using CMS_Projekt_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;

namespace CMS_Projekt_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select id as ""Id"",
                       firstname as ""FirstName"",
                       lastname as ""LastName"",
                       cms_role as ""CMS_role"",
                       password as ""Password""
                from users
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(UsersDTO user)
        {

            string query = @"
                insert into users(id,firstname,lastname,cms_role,password)
                values (@id,@FirstName,@LastName,@CMS_Role,@Password)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", user.Id);
                    myCommand.Parameters.AddWithValue("@firstname", user.FirstName);
                    myCommand.Parameters.AddWithValue("@lastname", user.LastName);
                    myCommand.Parameters.AddWithValue("@cms_role", user.CMS_Role);
                    myCommand.Parameters.AddWithValue("@password", user.Password);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(UsersDTO user)
        {
            string query = @"
                update users
                set firstname = @firstname,
                lastname = @lastname,
                cms_role = @cms_role,
                password = @password
                where id = @id 
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", user.Id);
                    myCommand.Parameters.AddWithValue("@firstname", user.FirstName);
                    myCommand.Parameters.AddWithValue("@lastname", user.LastName);
                    myCommand.Parameters.AddWithValue("@cms_role", user.CMS_Role);
                    myCommand.Parameters.AddWithValue("@password", user.Password);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Updated Successfully");
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from users
                where id=@id 
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Deleted Successfully");
        }

    }
}
