namespace CMS_Projekt_API.Models.Dto
{
    public class Page_SectionsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public string Title { get; set; }
        public string Img { get; set; }
        public DateTime Last_Mod_Date { get; set; }
        public int Last_Mod_User_Id { get; set; }
        public int Advantages_List_id { get; set; }
        public int User_id { get; set; }
        public int Service_List_id { get; set; }
    }
}
