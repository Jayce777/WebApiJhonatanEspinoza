namespace WebApiKnowlegde.Entidades
{
    public class entrerprises
    {
        public int Id { get; set; }
        public string created_by { get; set; }
        public DateTime? created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime? modified_date { get; set; }
        public bool status { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        List<departaments> departaments { get; set; }
    }
}
