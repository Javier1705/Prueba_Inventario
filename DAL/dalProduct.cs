using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using BO;

namespace DAL
{
    public class dalProduct
    {
        public bool AddProduct(string nombre)
        {
            SqlConnection con = new SqlConnection(conexion.ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spInsertProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                var r = ex.Message;
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UpdateProduct(int id_producto, string nombre)
        {
            SqlConnection con = new SqlConnection(conexion.ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spUpdateProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_producto", id_producto);
                cmd.Parameters.AddWithValue("@nombre_producto", nombre);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                var r = ex.Message;
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<productModel> GetProducts()
        {
            var pList = new List<productModel>();

            SqlConnection con = new SqlConnection(conexion.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spViewProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;

            using (var dr = cmd.ExecuteReader())
                while (dr.Read()) {
                    pList.Add(new productModel()
                    {
                        id_producto = Convert.ToInt32(dr["id_producto"]),
                        nombre_producto = dr["nombre_producto"].ToString(),
                        cdate = Convert.ToDateTime(dr["cdate"]),
                        udate = Convert.ToDateTime(dr["udate"])
                    });
                }

            return pList;
        }

        public productModel GetProductById(int id)
        {
            productModel model = new productModel();

            SqlConnection con = new SqlConnection(conexion.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spSelectProductById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_producto", id);

            using (var dr = cmd.ExecuteReader())
                while (dr.Read())
                {
                    model.id_producto = Convert.ToInt32(dr["id_producto"]);
                    model.nombre_producto = dr["nombre_producto"].ToString();
                    model.cdate = Convert.ToDateTime(dr["cdate"]);
                    model.udate = Convert.ToDateTime(dr["udate"]);
                }

            return model;
        }

        public bool AddMovement(int id_producto, int cantidad)
        {
            SqlConnection con = new SqlConnection(conexion.ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spInsertMovements", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_producto", id_producto);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                var r = ex.Message;
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<movementsModel> GetMovements()
        {
            var pList = new List<movementsModel>();

            SqlConnection con = new SqlConnection(conexion.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spViewMovements", con);
            cmd.CommandType = CommandType.StoredProcedure;

            using (var dr = cmd.ExecuteReader())
                while (dr.Read())
                {
                    pList.Add(new movementsModel()
                    {
                        id_movimiento = Convert.ToInt32(dr["id_movimiento"]),
                        nombre_producto = dr["nombre_producto"].ToString(),
                        cantidad = Convert.ToInt32(dr["cantidad"]),
                        cdate = Convert.ToDateTime(dr["cdate"])
                    });
                }

            return pList;
        }
    }
}