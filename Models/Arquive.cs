using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTable.Models
{
    public class Arquive
    {
        [PrimaryKey, AutoIncrement]
        public int IdArquive { get; set; }
        public int? ParentPasteId { get; set; }
        public String NameArquive { get; set; }
        public String ArquivePath { get; set; }
        public Arquive()
        {
            NameArquive = string.Empty;
            ArquivePath = string.Empty;
        }
    }
}
