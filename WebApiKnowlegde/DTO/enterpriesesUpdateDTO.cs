namespace WebApiKnowlegde.DTO
{
    public class enterpriesesUpdateDTO
    {
  
        public string address { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string? modified_by { get; set; } 
        public DateTime? modified_date { get; set; } = DateTime.UtcNow;
    }
}
