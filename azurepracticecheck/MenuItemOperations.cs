using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using azurepracticecheck.Models;

namespace azurepracticecheck
{
    public class MenuItemOperations
    {

        public static string sqlDataSource = "Server=(localdb)\\MSSQLLocalDB;Database=MenuItem;Trusted_Connection=True;MultipleActiveResultSets=true;";

        public static IEnumerable<MenuItem> GetConnection()
        {

            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                List<MenuItem> Items = new List<MenuItem>();
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select * from MenuItem";
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Items.Add(new MenuItem
                        {
                            Id = Convert.ToInt32(rd["Id"]),
                            Name = rd["Name"].ToString(),
                            Price = Convert.ToDouble(rd["Price"]),
                            freeDelivery = Convert.ToBoolean(rd["FreeDelivery"]),
                            Active = Convert.ToBoolean(rd["Active"]),
                            DateOfLaunch = Convert.ToDateTime(rd["DateOfLauch"]),
                            categoryId = Convert.ToInt32(rd["CategoryId"]),
                            categoryType=rd["CategoryType"].ToString()
                        });
                    }
                    con.Close();
                }


                return Items;
            }

        }
        public static void Update(int id, MenuItem menu)
        {
           
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                SqlCommand cmd = new SqlCommand("Update MenuItem set Id=@Id,Name=@Name,FreeDelivery=@FreeDelivery,Price=@Price,Active=@Active,DateOfLauch=@DateOfLauch,CategoryId=@CategoryId,CategoryType=@CategoryType where Id=@Id", con);

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", menu.Name);
                cmd.Parameters.AddWithValue("@Price", menu.Price);
                cmd.Parameters.AddWithValue("@FreeDelivery", menu.freeDelivery);
                cmd.Parameters.AddWithValue("@DateOfLauch", menu.DateOfLaunch);
                cmd.Parameters.AddWithValue("@Active", menu.Active);
                cmd.Parameters.AddWithValue("@CategoryId", menu.categoryId);
                cmd.Parameters.AddWithValue("@CategoryType", menu.categoryType);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        public static void InsertIntoCarts(List<Cart> carts)
        {
            SqlConnection con = new SqlConnection(sqlDataSource);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO Cart(id,userId,menuitemId) Values (@id,@userId,@menuitemId)";
            sqlCmd.Connection = con;
            con.Open();
            foreach (var i in carts)
            {
                sqlCmd.Parameters.AddWithValue("@id", i.id);
                sqlCmd.Parameters.AddWithValue("@userId", i.userId);
                sqlCmd.Parameters.AddWithValue("@menuitemId", i.menuitemId);
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Parameters.Clear();
            }

            con.Close();
        }
        public static string Delete(int cartId)
        {
            SqlConnection con = new SqlConnection(sqlDataSource);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from cart where id =@cartId";
            sqlCmd.Connection = con;
            con.Open();
            sqlCmd.Parameters.AddWithValue("@cartId", cartId);
            int i = sqlCmd.ExecuteNonQuery();
            if (i >= 1)
                return "record deleted";
            else
                return "no record";

        }
        public static List<MenuItem> CartList(int userid, ref int rowCount)
        {

            List<MenuItem> Items = new List<MenuItem>();
            List<int> list = new List<int>();

          

            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select menuitemId from Cart where userId = @userId";
                    cmd.Parameters.AddWithValue("@userid", userid);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        list.Add(Convert.ToInt32(rd["menuitemId"]));
                    }
                    rd.Close();
                    foreach (var i in list)
                    {

                        cmd.CommandText = "select * from MenuItem where Id = @i";
                        cmd.Parameters.AddWithValue("@i", i);
                        SqlDataReader rd1 = cmd.ExecuteReader();
                        while (rd1.Read())
                        {
                            Items.Add(new MenuItem
                            {
                                Id = Convert.ToInt32(rd1["Id"]),
                                Name = rd1["Name"].ToString(),
                                freeDelivery =Convert.ToBoolean(rd1["FreeDelivery"]),
                                Active = Convert.ToBoolean(rd1["Active"]),
                                DateOfLaunch = Convert.ToDateTime(rd1["DateOfLauch"]),
                                Price = Convert.ToDouble(rd1["Price"]),
                                categoryId = Convert.ToInt32(rd1["CategoryId"]),
                                categoryType = rd1["CategoryType"].ToString()
                            });
                            rowCount += Convert.ToInt32(rd1["Id"]);

                        }
                        cmd.Parameters.Clear();
                        rd1.Close();
                    }
                    con.Close();

                }

            }
            return Items;

        }
        public static List<User> UserList()
        {
            List<User> users = new List<User>();

            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select * from [MenuItem].[dbo].[User]";
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        users.Add(new User
                        {
                            userId = Convert.ToInt32(rd["userId"]),
                            password = rd["password"].ToString()
                          
                        });
                    }
                    con.Close();
                }

            }
            return users;


        }
        public static void Insert(User user)
        {
            SqlConnection con = new SqlConnection(sqlDataSource);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO [MenuItem].[dbo].[User](userId,password) Values (@userId,@password)";
            sqlCmd.Connection = con;
            sqlCmd.Parameters.AddWithValue("@userId", user.userId);
            sqlCmd.Parameters.AddWithValue("@password", user.password);
            con.Open();
            sqlCmd.ExecuteNonQuery();
            con.Close();

        }


       
    }
}


