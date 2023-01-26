namespace WebApiKnowlegde.Entidades
{
    public class entrerprises
    {
        public int Id { get; set; }
        public string? created_by { get; set; }
        public DateTime? created_date { get; set; } = DateTime.UtcNow;
        public string? modified_by { get; set; }
        public DateTime? modified_date { get; set; }
        public bool status { get; set; } = true;
        public string address { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public List<departaments> departaments { get; set; }
    }
}
