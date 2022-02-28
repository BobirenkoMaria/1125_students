using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.Tools;

namespace WpfApp15.DTO
{
    [Table("specials")]
    public class Specials : BaseDTO
    {
        [Column("Title")]
        public string Title { get; set; }
    }
}
