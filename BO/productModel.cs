using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BO
{
    public class productModel
    {
        public int id_producto { get; set; }
        public string nombre_producto { get; set; }
        public DateTime cdate { get; set; }
        public DateTime udate { get; set; }
    }
}