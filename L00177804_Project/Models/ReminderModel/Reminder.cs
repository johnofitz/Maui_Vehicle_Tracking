using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00177804_Project.Models.ReminderModel
{
    public class Reminder
    {
        public string KmUntilService { get; set; }
        public string ServiceDate { get; set; }

        public List<Messages> Messages { get; set; } = new List<Messages>();
    }
}
