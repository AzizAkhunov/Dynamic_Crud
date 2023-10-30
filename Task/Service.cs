using System.Data.SqlClient;

namespace Task
{
    internal class Service
    {
        public readonly string connect = "Server=(localdb)\\MSSQLLocalDB;Database=Apple;Trusted_Connection=True;";
        public void CreateTable_Users()
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {

                var query =
                    @$"CREATE TABLE dbo.Users
        (
           ID int IDENTITY(1,1) NOT NULL,
                    FirstName nvarchar(50) NULL,
                    LastName nvarchar(50) NULL,
                    Email nvarchar(50),
                    CONSTRAINT pk_id PRIMARY KEY (ID)
        );";
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Table Created Succesfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!!");
                }
            }
        }
        public void AddUser()
        {
            Console.WriteLine("Ismingizni kiriting: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Familiyangizni kiriting: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Email kiriting: ");
            string email = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connect))
            {
                var querry = @$"
                INSERT INTO dbo.Users
                Values('{Name}','{lastName}','{email}');";

                SqlCommand cmd = new SqlCommand(querry, connection);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("User Created Succesfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!");
                }
            }
        }
        public void GetUserBy(string nmaOlibKelish,string shart)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();
                var query = $"Select {nmaOlibKelish} from dbo.Users {shart};";
                var command = new SqlCommand(query,connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var c = reader.FieldCount;///column sonini bilish
                        for (int i = 0; i < c; i++)
                        {
                            Console.Write(reader[i] + "\t");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
        public void InsertToTableDynamic(string TableName,string FirstName,string LastName,string email)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                var query = $@"INSERT INTO dbo.{TableName} VALUES('{FirstName}','{LastName}','{email}')";

                SqlCommand cmd = new SqlCommand(query, connection);

                try
                {
                    connection.Open(); 
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Succesfuly!");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error!");
                }
            }  
        }
        public void DeleteByDynamic(string tableName,string what,string id)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                var query = $"Delete * from {tableName} Where {what} = {id};";
                SqlCommand cmd = new SqlCommand(query,connection);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Succesfuly!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error!");
                }
            }
        }
    }
}
