using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BL;
using BO;
using Newtonsoft.Json;

namespace Prueba_Inventario.Controllers
{
    public class HomeController : Controller
    {
        blProduct _blProduct = new blProduct();

        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            var productList = _blProduct.GetProducts();
            var movementList = _blProduct.GetMovements();
            model.Products = productList;
            model.Movements = movementList;
            return View(model);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        public ActionResult Editar(int id_producto)
        {
            productModel editProduct = new productModel();
            editProduct = _blProduct.GetProductById(id_producto);
            return View(editProduct);
        }

        public ActionResult Movimientos()
        {
            var productList = _blProduct.GetProducts();
            return View(productList);
        }

        [HttpPost]
        public ActionResult ActionAddProduct(string nombre)
        {
            var result = _blProduct.AddProduct(nombre);
            if (result)
            {
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, data = result }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ActionUpdateProduct(int id, string nombre)
        {
            var result = _blProduct.UpdateProduct(id,nombre);
            if (result)
            {
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, data = result }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ActionViewProduct()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ActionAddMovements(int id_producto, int cantidad)
        {
            var result = _blProduct.AddMovements(id_producto, cantidad);
            if (result)
            {
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, data = result }, JsonRequestBehavior.AllowGet);
            }
        }
    }

    public class JsonDataTable
    {
        public string Schema { get; set; }
        public string Table { get; set; }

        public static JsonDataTable FromDataTable(DataTable dt)
        {
            JsonDataTable j = new JsonDataTable();
            var columns = dt.Columns.Cast<DataColumn>().Select(c => new { DataPropertyName = c.ColumnName, DataPropertyType = c.DataType.ToString() });
            j.Schema = JsonConvert.SerializeObject(columns);
            j.Table = JsonConvert.SerializeObject(dt);
            return j;
        }


        public DataTable ToDataTable()
        {
            DataTable dt = new DataTable();

            JsonConvert.DeserializeObject<List<dynamic>>(Schema).ForEach(prop =>
            {
                dt.Columns.Add(new DataColumn() { ColumnName = prop.DataPropertyName, DataType = Type.GetType(prop.DataPropertyType.ToString()) });
            });

            dt.Merge(JsonConvert.DeserializeObject<DataTable>(Table), true, MissingSchemaAction.Ignore);

            return dt;
        }

    }
}