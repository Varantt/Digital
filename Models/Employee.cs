using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Column (TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Department { get; set; }

        [Column(TypeName = "varchar(50)")]

        public string Position { get; set; }
    }
}
