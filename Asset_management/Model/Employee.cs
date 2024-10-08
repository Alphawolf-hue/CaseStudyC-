namespace DigitalAssetManagement.model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public Employee() { }

        public Employee(int employeeId, string name, string department, string email, string password)
        {
            EmployeeId = employeeId;
            Name = name;
            Department = department;
            Email = email;
            Password = password;
        }
    }
}
