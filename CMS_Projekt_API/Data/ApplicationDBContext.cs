using CMS_Projekt_API.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace CMS_Projekt_API.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }
        public DbSet<AdvantagesDTO> Advantages_List { get; set; }
        public virtual DbSet<Page_SectionsDTO> Page_Sections_List { get; set; }
        public virtual DbSet<ServicesDTO> Services_List { get; set; }
        public virtual DbSet<UsersDTO> Users_List { get; set; }
    }
}
