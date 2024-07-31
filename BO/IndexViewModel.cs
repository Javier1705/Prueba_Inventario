using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BO
{
    public class IndexViewModel
    {
        public IEnumerable<productModel> Products { get; set; }
        public IEnumerable<movementsModel> Movements { get; set; }
    }
}