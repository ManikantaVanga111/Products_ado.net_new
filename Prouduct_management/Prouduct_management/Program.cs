using System.Data;
using System.Data.SqlClient;
namespace Prouduct_management
{
  class Products
    {
        public static void AddNewProduct(SqlConnection conn)
        {

            SqlDataAdapter adp = new SqlDataAdapter("select * from product", conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            var row = ds.Tables[0].NewRow();
            Console.WriteLine("Enter the product name");
            row["productname"] = Console.ReadLine();
            Console.WriteLine("Enter the Brand");
            row["productdescription"] = Console.ReadLine();
            Console.WriteLine("Enter Quantity");
            row["Quantity"]=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter price");
            row["Price"]=Convert.ToInt32(Console.ReadLine());
            ds.Tables[0].Rows.Add(row);
            SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine("successfully inserted");
        }
        public static void GetProduct(SqlConnection conn) 
        {
            Console.WriteLine("Enter the id");
            int id = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"select * from product where productid={id}", conn);
            DataSet ds = new DataSet();
            adp.Fill(ds, "table1");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Console.WriteLine("Id\tProductName\tBrand\tQuantity\tPrice");
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {

                    Console.Write($"{ds.Tables[0].Rows[i][j]}\t");
                }
                Console.WriteLine();
            }


        }
        public static void GetAllProducts(SqlConnection conn)
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select * from product ", conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Console.WriteLine("Id\tProductName\tBrand\tQuantity\tPrice");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
               
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {

                    Console.Write($"{ds.Tables[0].Rows[i][j]}\t");
                }
                Console.WriteLine();
            }
        }
        public static void UpdateProduct(SqlConnection conn)
        {
            Console.WriteLine("Enter the id");
            int id = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"select * from product where productid={id}", conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            var row = ds.Tables[0].Rows[0];
            Console.WriteLine("Enter the update Product Name");
            row["productname"]= Console.ReadLine();
            Console.WriteLine("Enter the Updated Brand");
            row["productdescription"] = Console.ReadLine();
            Console.WriteLine("Enter the updated Quantity");
            row["Quantity"] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the updated price");
            row["Price"] = Convert.ToInt32(Console.ReadLine());
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine("Successfully updated");
        }
        public static void DeleteProduct(SqlConnection conn)
        {
            Console.WriteLine("Enter the id");
            int id = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"select * from product where productid = {id}", conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            ds.Tables[0].Rows[0].Delete();
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine("Successfully deleted");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                SqlConnection conn = new SqlConnection("Data source=US-1C4R8S3;Database=ProductManagement;Integrated security=true");
                Console.WriteLine("1 for AddNewProduct");
                Console.WriteLine("2 for Getproduct by using id");
                Console.WriteLine("3 for GetAllProducts");
                Console.WriteLine("4 for UpdateProduct by using id");
                Console.WriteLine("5 for DeleteProduct by using id");
                Console.WriteLine("Enter the choice");
                
                try
                {
                   int ch = Convert.ToInt32(Console.ReadLine());


                    switch (ch)
                    {
                        case 1:
                            {
                                Products.AddNewProduct(conn);
                                break;

                            }
                        case 2:
                            {
                                Products.GetProduct(conn);
                                break;
                            }
                        case 3:
                            {
                                Products.GetAllProducts(conn);
                                break;
                            }
                        case 4:
                            {
                                Products.UpdateProduct(conn);
                                break;
                            }
                        case 5:
                            {
                                Products.DeleteProduct(conn);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Enter the Valid choice");
                                break;
                            }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input must be integers from 1 to 5");
                }

                }
               
            }
        }
    }
