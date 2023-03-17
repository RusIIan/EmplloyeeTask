namespace HomeTask.Dtos
{
    public class EmployeeDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string Position { get; set; } = string.Empty;
        public int Salary { get; set; }
        public bool IsManager { get; set; } = false;
    }
}
