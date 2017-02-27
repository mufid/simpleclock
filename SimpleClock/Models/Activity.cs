using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClock.Gui.Models
{
    public class Activity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
    }
}
