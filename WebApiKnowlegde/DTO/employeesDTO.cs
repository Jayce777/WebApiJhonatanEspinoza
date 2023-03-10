namespace WebApiKnowlegde.DTO
{
    public class employeesDTO
    {
        public int Id { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_date { get; set; }
        public bool status { get; set; } = true;
        public int age { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public string surname { get; set; }
    }
}
