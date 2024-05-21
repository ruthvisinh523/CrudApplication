using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudApplication2.Models
{
    public class StateModel
    {

        public int StateId {  get; set; }

        public string StateName { get; set; }

        public bool IsActive { get; set; }

        public List<SelectListItem> listStateModels { get; set; }
    }
}
