using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DAL;
using BO;

namespace BL
{
    public class blProduct
    {
        dalProduct _dalProduct = new dalProduct();

        public bool AddProduct(string nombre)
        {
            return _dalProduct.AddProduct(nombre);
        }

        public bool UpdateProduct(int id_producto, string nombre)
        {
            return _dalProduct.UpdateProduct(id_producto, nombre);
        }

        public List<productModel> GetProducts()
        {
            return _dalProduct.GetProducts();
        }

        public productModel GetProductById(int id) {
            return _dalProduct.GetProductById(id);
        }

        public bool AddMovements(int id_producto, int cantidad)
        {
            return _dalProduct.AddMovement(id_producto, cantidad);
        }

        public List<movementsModel> GetMovements()
        {
            return _dalProduct.GetMovements();
        }
    }
}