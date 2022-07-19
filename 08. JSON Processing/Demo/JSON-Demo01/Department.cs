namespace JSON_Demo01
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    public class Department
    {
        private HashSet<Employee> employes;

        private Department()
        {
            this.employes = new HashSet<Employee>();
        }

        public Department(string name)
            : this()
        {
            this.DepartmentName = name;
        }

        [JsonProperty("Name")]
        public string DepartmentName { get; set; }
        public IReadOnlyCollection<Employee> Employees => this.employes;

        public void Add(Employee employe)
        {
            this.employes.Add(employe);
        }

        public void Remove(Employee employe)
        {
            this.employes.Remove(employe);
        }
    }
}
