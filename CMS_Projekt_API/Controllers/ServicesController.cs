using CMS_Projekt_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;

namespace CMS_Projekt_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ServicesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

            [HttpGet]
            public JsonResult Get()
            {
                string query = @"
                select id as ""Id"",
                        name as ""Name"",
                        description as ""Description""    
                from services
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
        public JsonResult Post(ServicesDTO services)
        {
            int id = 0;

            string query = @"
                insert into services
                (id,name,description)
                values 
                (@id,@name,@description)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", services.Id);
                    myCommand.Parameters.AddWithValue("@name", services.Name);
                    myCommand.Parameters.AddWithValue("@description", services.Description);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Added Successfully");
        }



        [HttpPut]
        public JsonResult Put(ServicesDTO adv)
        {
            string query = @"
                update services
                set name = @name,
                description = @description
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
                    myCommand.Parameters.AddWithValue("@id", adv.Id);
                    myCommand.Parameters.AddWithValue("@name", adv.Name);
                    myCommand.Parameters.AddWithValue("@description", adv.Description);
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
                delete from services
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
