using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Lékárna.Databaze
{
    public class DrugAllergen
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Id_drug { get; set; }
        public int Id_Allergen { get; set; }
    }
}
