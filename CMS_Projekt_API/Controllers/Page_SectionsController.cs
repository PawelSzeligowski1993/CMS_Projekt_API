using CMS_Projekt_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;

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
                        img as ""img"",
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


        //[HttpPost]
        //public JsonResult Post(Page_SectionsDTO pageSect)
        //{
        //    int id = 0;

        //    string query = @"
        //        insert into advantages
        //        (id,name,position,title,img,last_Mod_Date,last_Mod_User_Id,advantages_List_id,user_id,service_List_id)
        //        values 
        //        (@id,@name,@position,@title,@img,@last_Mod_Date,@last_Mod_User_Id,@advantages_List_id,@user_id,@service_List_id)
        //    ";

        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
        //    NpgsqlDataReader myReader;
        //    using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
        //        {
        //            myCommand.Parameters.AddWithValue("@id", pageSect.Id);
        //            myCommand.Parameters.AddWithValue("@name", pageSect.Name);
        //            myCommand.Parameters.AddWithValue("@text", pageSect.Position);


        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);

        //            myReader.Close();
        //            myCon.Close();

        //        }
        //    }

        //    return new JsonResult("Added Successfully");
        //}



        //[HttpPut]
        //public JsonResult Put(AdvantagesDTO adv)
        //{
        //    string query = @"
        //        update advantages
        //        set name = @name,
        //        text = @text
        //        where id = @id 
        //    ";

        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
        //    NpgsqlDataReader myReader;
        //    using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
        //        {
        //            myCommand.Parameters.AddWithValue("@id", adv.Id);
        //            myCommand.Parameters.AddWithValue("@name", adv.Name);
        //            myCommand.Parameters.AddWithValue("@text", adv.Text);
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);

        //            myReader.Close();
        //            myCon.Close();

        //        }
        //    }

        //    return new JsonResult("Updated Successfully");
        //}

        //[HttpDelete("{id}")]
        //public JsonResult Delete(int id)
        //{
        //    string query = @"
        //        delete from advantages
        //        where id=@id 
        //    ";

        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
        //    NpgsqlDataReader myReader;
        //    using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
        //        {
        //            myCommand.Parameters.AddWithValue("@id", id);
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);

        //            myReader.Close();
        //            myCon.Close();

        //        }
        //    }

        //    return new JsonResult("Deleted Successfully");
        //}
    }
}
