using System.ComponentModel.DataAnnotations;

namespace WebApiKnowlegde.DTO
{
    public class departamentUpdateDTO
    {
        public DateTime modified_date { get; set; }
        public bool status { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        [Required(ErrorMessage ="The field {0} is requerid for this operation")]
        public int? entrerprisesId { get; set; }
    }
}
