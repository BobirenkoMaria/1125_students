using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.Tools;

namespace WpfApp15.DTO
{
    [Table("curator")]
    public class Curator : BaseDTO
    {
        [Column("lastName")]
        public string LastName { get; set; }

        [Column("firstName")]
        public string FirstName { get; set; }
        
        [Column("birthday")]
        public DateTime Birthday { get; set; }
    }
}
