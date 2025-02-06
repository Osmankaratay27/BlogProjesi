using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace BlogAPI.DataAccessLayer
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
