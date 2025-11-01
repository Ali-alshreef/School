using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.Models
{
    public class PersonInfo : BaseModel
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
