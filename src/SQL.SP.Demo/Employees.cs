namespace SQL.SP.Demo
{
    public class Employees
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"ID:{Id},Name:{Name},Salary:{Salary:F}";
        }
    }
}