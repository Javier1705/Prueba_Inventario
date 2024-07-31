using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BO
{
    public class movementsModel
    {
        public int id_movimiento { get; set; }
        public string nombre_producto { get; set; }
        public int cantidad { get; set; }
        public DateTime cdate { get; set; }
    }
}