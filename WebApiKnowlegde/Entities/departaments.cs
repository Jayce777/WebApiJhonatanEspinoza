using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiKnowlegde.Entidades
{
    public class departaments
    {
        public int Id { get; set; }
        public string? created_by { get; set; }
        public DateTime? created_date { get; set; } = DateTime.UtcNow;
        public string? modified_by { get; set; }
        public DateTime? modified_date { get; set; }
        public bool status { get; set; }
        public string? description { get; set; }
        [NotMapped]
        public string Hobbie { get; set; }
        public string name { get; set; }
        public string? phone { get; set; }
        public int? entrerprisesId { get; set; }

        public entrerprises entrerprises { get; set; }  
        public List<departaments_employees> departaments_employees { get; set; }    

    }
}
