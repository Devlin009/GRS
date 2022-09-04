using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("User")]
    public class User
    {


        public int Id { get; set; }

        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string cpassword { get; set; }

    }
}
