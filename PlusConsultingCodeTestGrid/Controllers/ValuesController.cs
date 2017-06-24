using PlusConsultingCodeTestGrid.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PlusConsultingCodeTestGrid.Controllers
{
    public class ValuesController : Controller
    {
        [HttpGet]
        public JsonResult Product()
        {
            List<Product> products = new List<Product>();
            string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection sqlConnection1 = new SqlConnection(connStr);
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT distinct [Name],[ProductNumber],[Color] ,[SafetyStockLevel] ,[ReorderPoint] ,[StandardCost] ,[ListPrice] FROM [AdventureWorks2012].[Production].[Product]";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product prod = new Product();
                    prod.Name = reader["Name"].ToString();
                    prod.ListPrice = Convert.ToDecimal(reader["ListPrice"]);
                    prod.Color = reader["Color"].ToString();
                    prod.ProductNumber = Convert.ToString(reader["ProductNumber"]);
                    prod.SafetyStockLevel = Convert.ToInt32(reader["SafetyStockLevel"]);
                    prod.ReorderPoint = Convert.ToInt32(reader["ReorderPoint"]);
                    prod.StandardCost = Convert.ToDecimal(reader["StandardCost"]);
                    products.Add(prod);
                }
            }
            catch (SqlException sql)
            {

            }
            catch (Exception exp)
            {

            }
            finally
            {
                sqlConnection1.Close();
            }            
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Product(Product product)
        {
            bool isSuccesfull = false;
            string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection sqlConnection1 = new SqlConnection(connStr);
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;
                StringBuilder builder = new StringBuilder();
                builder.Append("'"); builder.Append(new Guid()); builder.Append("',");
                builder.Append("'"); builder.Append("5/5/1992"); builder.Append("',");
                builder.Append("'"); builder.Append("5/5/1992"); builder.Append("',");
                builder.Append("0"); builder.Append(",");
                builder.Append("'"); builder.Append(product.Name); builder.Append("',");
                builder.Append("'"); builder.Append(product.ProductNumber); builder.Append("',");
                builder.Append("'"); builder.Append(product.Color); builder.Append("',");
                builder.Append(product.SafetyStockLevel); builder.Append(",");
                builder.Append(product.ReorderPoint); builder.Append(",");
                builder.Append(product.StandardCost); builder.Append(",");
                builder.Append(product.ListPrice);

                cmd.CommandText = "INSERT INTO [Production].[Product] ([rowguid],[ModifiedDate],[SellStartDate],[DaysToManufacture], [Name] ,[ProductNumber] ,[Color] ,[SafetyStockLevel] ,[ReorderPoint] ,[StandardCost] ,[ListPrice]) VALUES (" + builder.ToString() + ")";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                reader = cmd.ExecuteReader();
                isSuccesfull = true;
            }
            catch (SqlException sql)
            {
                isSuccesfull = false;
            }
            catch (Exception exp)
            {
                isSuccesfull = false;
            }
            finally
            {
                sqlConnection1.Close();
            }
            return Json(isSuccesfull, JsonRequestBehavior.AllowGet);
        }
    }
}