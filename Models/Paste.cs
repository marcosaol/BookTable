using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BookTable.Models
{
    public class Paste
    {
        [PrimaryKey, AutoIncrement]
        public int IdPaste { get; set; }
        public String Name { get; set; }

        public Paste()
        {
            Name = string.Empty; 
        }
    }

}
