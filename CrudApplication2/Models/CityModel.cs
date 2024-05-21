using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudApplication2.Models
{
    public class CityModel
    {

        public int CityId { get; set; }

        public string CityName { get; set; }
        public int StateId { get; set; }

        public string StateName { get; set; }

        public bool IsActive { get; set; }

        public List<SelectListItem> listStateModels { get; set; }

    }
}
