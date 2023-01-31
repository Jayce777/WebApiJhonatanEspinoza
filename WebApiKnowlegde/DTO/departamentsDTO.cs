using WebApiKnowlegde.Entidades;

namespace WebApiKnowlegde.DTO
{
    public class departamentsDTO
    {
        public int Id { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; } 
        public string modified_by { get; set; }
        public DateTime modified_date { get; set; }
        public bool status { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string phone { get; set; }

        public enterpriesesDTO entrerprises { get; set; }
        //public List<departaments_employees> departaments_employees { get; set; }
    }
}
