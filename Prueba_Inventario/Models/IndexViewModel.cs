using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BO;

namespace Prueba_Inventario.Models
{
    public class IndexViewModel
    {
         public IEnumerable<productModel> Products { get; set; }
         public IEnumerable<movementsModel> Movements { get; set; }
    }
}