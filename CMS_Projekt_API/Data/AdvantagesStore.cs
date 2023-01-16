using CMS_Projekt_API.Models.Dto;

namespace CMS_Projekt_API.Data
{
    public class AdvantagesStore
    {
        public static List<AdvantagesDTO> advantagesList = new List<AdvantagesDTO>
            {
                new AdvantagesDTO{Id=1, Name="Poll View", Text="Jurek Ogórek kiełba i żurek" },
                new AdvantagesDTO{Id=2, Name="Beach View", Text="Stejki Burneiki" }
            };
    }
}
