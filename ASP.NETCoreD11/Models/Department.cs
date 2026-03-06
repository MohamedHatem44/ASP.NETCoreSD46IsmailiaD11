using System.Text.Json.Serialization;

namespace ASP.NETCoreD11.Models
{
    public class Department
    {
        /*------------------------------------------------------------------*/
        public int Id { get; set; }
        public required string Name { get; set; }
        /*------------------------------------------------------------------*/
        //[JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
        = new HashSet<Employee>();
        /*------------------------------------------------------------------*/
    }
}
