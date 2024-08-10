using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int? ParentPasteId { get; set; }
        public String Name { get; set; }
        [Ignore]
        public ObservableCollection<Paste> SubPastes { get; set; }
        public Paste()
        {
            Name = string.Empty;
            SubPastes = new ObservableCollection<Paste>();
        }
    }

}
