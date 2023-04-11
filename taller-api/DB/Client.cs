using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public String IdNum { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }

        public Client(string name,string idNum ,string email, string phone)
        {
            Name = name;
            IdNum = idNum;
            Email = email;
            Phone = phone;
        }
    }
}
