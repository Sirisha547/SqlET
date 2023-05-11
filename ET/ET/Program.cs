using System.Data.SqlClient;

namespace ExpenseTracker1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("Server=IN-7G3K9S3; database=ExpenseTracker; Integrated Security=true");
            con.Open();
            string a = "";
            do
            {
                Console.WriteLine("Welcome to Expense Tracker App");
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. View Expenses");
                Console.WriteLine("3. View Incomes");
                Console.WriteLine("4. Check Available Balance");
                int choice = 0;
                try
                {
                    Console.WriteLine("Enter ur Choice");
                    choice = Convert.ToInt16(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("You can enter only Numbers");
                }
                switch (choice)
                {
                    case 1:
                        {
                            SqlCommand cmd = new SqlCommand($"insert into Transactions values(@title, @description, @amount, @date)", con);
                            Console.WriteLine("Enter Title: ");
                            string title = Console.ReadLine();
                            Console.WriteLine("Enter Description: ");
                            string description = Console.ReadLine();
                            Console.WriteLine("Enter Amount: ");
                            int amount = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Enter date ");
                            string date = Console.ReadLine();
                            cmd.Parameters.AddWithValue("@title", title);
                            cmd.Parameters.AddWithValue("@description", description);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("@date", date);
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Record saved successfully");
                            break;



                        }
                    case 2:
                        {
                            SqlCommand cmd1 = new SqlCommand($"select * from Transactions where amount<0", con);
                            SqlDataReader reader = cmd1.ExecuteReader();
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.WriteLine($"{reader[i]}  ");
                                }
                                Console.WriteLine();
                            }
                            reader.Close();
                            break;
                        }
                    case 3:
                        {
                            SqlCommand cmd2 = new SqlCommand($"select * from Transactions where amount>0", con);
                            SqlDataReader reader = cmd2.ExecuteReader();
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.WriteLine($"{reader[i]}  ");
                                }
                                Console.WriteLine();
                            }

                            reader.Close();
                            break;
                        }
                    case 4:
                        {
                            SqlCommand cmd3 = new SqlCommand("select sum(amount) as AvailableBalance from Transactions", con);
                            var bal = cmd3.ExecuteScalar();//used when ur query executes a single value
                            Console.WriteLine($"Available Balance is {bal}");

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong Choice Entered");
                            break;
                        }
                }
                Console.WriteLine("Do you wish to continue? [y/n] ");
                a = Console.ReadLine();
            } while (a.ToLower() == "y");

            con.Close();
        }
    }
}


