namespace CMS_Projekt_API.Models.Dto
{
    public class UsersDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CMS_Role { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
