namespace WebApiKnowlegde.DTO
{
    public class employeeUpdateDTO
    {
      
        public DateTime? modified_date { get; set; } = DateTime.UtcNow;
        public bool status { get; set; } = true;
        public int age { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public string surname { get; set; }
    }
}
