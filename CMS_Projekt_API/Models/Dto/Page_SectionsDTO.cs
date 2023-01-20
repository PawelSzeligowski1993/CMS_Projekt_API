using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Projekt_API.Models.Dto
{
    public class Page_SectionsDTO
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public string Title { get; set; }
        public string Img_url { get; set; }
        public DateTime Last_Mod_Date { get; set; }
        public int Last_Mod_User_Id { get; set; }

        [ForeignKey("AdvantagesDTO")]
        public int Advantages_List_id { get; set; }
        public AdvantagesDTO advantagesDTO { get; set; }

        [ForeignKey("UsersDTO")]
        public int User_id { get; set; }
        public UsersDTO usersDTO { get; set; }

        [ForeignKey("ServicesDTO")]
        public int Service_List_id { get; set; }
        public ServicesDTO servicesDTO { get; set; }
    }
}
