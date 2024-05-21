using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudApplication2.Models
{
    public class EmployeeModel
    {

        public int EmployeeId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string ContectNo { get; set; }
        public DateTime DOB { get; set; }
        public int CityId { get; set; }

        public string CityName { get; set; }

        public int StateId { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }

        public List<SelectListItem> listEmployrrModels { get; set; }

        public List<SelectListItem> listStateModels { get; set; }

        public IEnumerable<Gender> listGender { get; set; }
    }

    public class Gender
    {
        public string Id { get; set; }
        public string GenderName { get; set; }
    }
}
