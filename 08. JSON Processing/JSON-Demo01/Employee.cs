namespace JSON_Demo01
{
    using Newtonsoft.Json;
    using System;
    public class Employee
    {
        public Employee(string name, int age, string job)
        {
            this.Name = name;
            this.Age = age;
            this.Job = job;
            this.DateTime = DateTime.Now;
        }

        [JsonProperty("EmployeeName", Order = 0)]
        public string Name { get; set; }

        [JsonProperty("EmployeeAge", Order = 1)]
        public int Age { get; set; }

        [JsonProperty("EmployeeJob", Order = 2)]
        public string Job { get; set; }

        [JsonIgnore]
        public DateTime DateTime { get; set; }
    }
}