using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.Models
{
    public class City : BaseModel
    {

        [StringLength(50)]
        public string Name { get; set; }

        [NotMapped]
        public string Name2 { get; set; }

        public string Name3
        {
            get
            {
                return "";
            }
        }

    }
}
