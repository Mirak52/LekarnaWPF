using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Lékárna
{
   public class Customers
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Authorization { get; set; }
        public int Choice { get; set; }
    }
}
