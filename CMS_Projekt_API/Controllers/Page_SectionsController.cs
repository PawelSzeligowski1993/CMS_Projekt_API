using CMS_Projekt_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using System.Xml.Linq;

namespace CMS_Projekt_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Page_SectionsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public Page_SectionsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select id as ""id"",
                        name as ""name"",
                        position as ""position"",
                        title as ""title"",
                        img_url as ""img_url"",
                        last_modification_date as ""last_modification_date"",
                        last_mod_user_id as ""last_mod_user_id"",
                        advantages_id as ""advantages_id"",
                        user_id as ""user_id"",
                        service_id as ""service_id""    
                from page_Sections
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
        public JsonResult Post(Page_SectionsDTO pageSect)
        {
            int id = 0;

            string query = @"
                insert into page_Sections
                (id,name,position,title,img_url,last_modification_date,last_mod_user_id,advantages_id,user_id,service_id)
                values 
                (@id,@name,@position,@title,@img_url,@last_modification_date,@last_mod_user_id,@advantages_id,@user_id,@service_id)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", pageSect.Id);
                    myCommand.Parameters.AddWithValue("@name", pageSect.Name);
                    myCommand.Parameters.AddWithValue("@position", pageSect.Position);
                    myCommand.Parameters.AddWithValue("@title", pageSect.Title);
                    myCommand.Parameters.AddWithValue("@img_url", pageSect.Img_url);
                    myCommand.Parameters.AddWithValue("@last_modification_date", pageSect.Last_Mod_Date);
                    myCommand.Parameters.AddWithValue("@last_mod_user_id", pageSect.Last_Mod_User_Id);
                    myCommand.Parameters.AddWithValue("@advantages_id", pageSect.Advantages_List_id);
                    myCommand.Parameters.AddWithValue("@user_id", pageSect.User_id);
                    myCommand.Parameters.AddWithValue("@service_id", pageSect.Service_List_id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Added Successfully");
        }


        //@name,@position,@title,@img,@last_modification_date,@last_mod_user_id,@advantages_id,@user_id,@service_id
        [HttpPut]
        public JsonResult Put(Page_SectionsDTO pageSect)
        {
            string query = @"
                update page_Sections
                set name = @name,
                position = @position,
                title = @title,
                img_url = @img_url,
                last_modification_date = @last_modification_date,
                last_mod_user_id = @last_mod_user_id,
                advantages_id = @advantages_id,
                user_id = @user_id,
                service_id = @service_id
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
                    myCommand.Parameters.AddWithValue("@id", pageSect.Id);
                    myCommand.Parameters.AddWithValue("@name", pageSect.Name);
                    myCommand.Parameters.AddWithValue("@position", pageSect.Position);
                    myCommand.Parameters.AddWithValue("@title", pageSect.Title);
                    myCommand.Parameters.AddWithValue("@img_url", pageSect.Img_url);
                    myCommand.Parameters.AddWithValue("@last_modification_date", pageSect.Last_Mod_Date);
                    myCommand.Parameters.AddWithValue("@last_mod_user_id", pageSect.Last_Mod_User_Id);
                    myCommand.Parameters.AddWithValue("@advantages_id", pageSect.Advantages_List_id);
                    myCommand.Parameters.AddWithValue("@user_id", pageSect.User_id);
                    myCommand.Parameters.AddWithValue("@service_id", pageSect.Service_List_id);
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
                delete from page_Sections
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
