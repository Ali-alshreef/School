using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.Models
{
    public class LogEntry
    {
        public int Id { get; set; }

        public int TableId { get; set; }
        public string TableName { get; set; }
        public string ColmunName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string AppUser { get; set; }
        public DateTime Date { get; set; }
    }
}
