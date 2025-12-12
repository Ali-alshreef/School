using SchoolCore.MyAtterbutes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.Models
{
    public class BaseModel
    {


        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }

        [StringLength(5)]
        public string? CreatedBy { get; set; }
        public DateTime? ModifyedOn { get; set; }

        public string? ModifyedOnBy { get;set; }
    }
}
