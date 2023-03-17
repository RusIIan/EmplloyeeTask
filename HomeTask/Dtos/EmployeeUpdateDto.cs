namespace HomeTask.Dtos;

public class EmployeeUpdateDto
{
    public string Position { get; set; } = string.Empty;
    public int Salary { get; set; }
    public bool IsManager { get; set; }
}
