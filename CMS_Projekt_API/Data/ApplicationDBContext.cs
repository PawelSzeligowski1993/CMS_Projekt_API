using CMS_Projekt_API.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;


namespace CMS_Projekt_API.Data
{
    public class ApplicationDBContext : DbContext
    {
        public virtual DbSet<AdvantagesDTO> Advantages_List { get; set; }
        public virtual DbSet<Page_SectionsDTO> Page_Sections_List { get; set; }
        public virtual DbSet<ServicesDTO> Services_List { get; set; }
        public virtual DbSet<UsersDTO> Users_List { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)

        {
 
        }

        public ApplicationDBContext()
        {
        }
    }
}
