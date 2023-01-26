namespace WebApiKnowlegde.Entidades
{
    public class departaments_employees
    {
        public string created_by { get; set; }
        public DateTime? created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime? modified_date { get; set; }
        public bool status { get; set; }
        public int departamentsId { get; set; }
        public int employeesId { get; set; }
        public departaments departaments { get; set; }
        public employees employees { get; set; }


    }
}
