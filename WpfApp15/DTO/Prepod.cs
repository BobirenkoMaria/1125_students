using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.Tools;

namespace WpfApp15.DTO
{
    [Table("prepod")]
    public class Prepod : BaseDTO
    {
        [Column("lastName")]
        public string LastName { get; set; }

        [Column("firstName")]
        public string FirstName { get; set; }
    }
}
