using System;

namespace Authentication
{
    class Program
    {
        public static int input;
        public static string kon;
        public static void Main()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("===BASIC AUTHENTICATION===");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Show User");
                Console.WriteLine("3. Search");
                Console.WriteLine("4. Login");
                Console.WriteLine("5. Exit");
                Console.Write("Input : ");
                input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        CreateUser();
                        break;
                    case 2:
                        User.ShowUser("");
                        break;
                    case 3:
                        Search();
                        break;
                    case 4:
                        UserLogin();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR INPUT !!!!");
                kon = Console.ReadLine();
                Main();
            }
        }
        public static void CreateUser()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("======= CREATE USER =======");
                Console.Write("First Name          : ");
                User.FirstName = Console.ReadLine();
                Console.Write("Last Name           : ");
                User.LastName = Console.ReadLine();
                Console.Write("Password            : ");
                User.Password = Console.ReadLine();
                Console.Write("Konfirmasi Password : ");
                User.KonfirmasiPassword = Console.ReadLine();
                User.TambahUser();
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR INPUT !!!!");
                kon = Console.ReadLine();
                CreateUser();
            }
        }
        public static void Search()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("======= SEARCH USER =======");
                Console.Write("USERNAME          : ");
                kon = Console.ReadLine();
                User.ShowUser(kon);
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR INPUT !!!!");
                kon = Console.ReadLine();
                Main();
            }
        }
        public static void UserLogin()
        {
            Console.Clear();
            Console.Write("Masukkan Username : ");
            Login.Username = Console.ReadLine();
            Console.Write("Masukkan Password : ");
            Login.Password = Console.ReadLine();
            Login.LoginUser();
        }
        public static void MenuUser(string username)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("1. INFO");
                Console.WriteLine("2. HAPUS AKUN");
                Console.WriteLine("3. EDIT USERNAME");
                Console.WriteLine("4. EDIT PASSWORD");
                Console.WriteLine("5. LOGOUT");
                Console.Write("INPUT : ");
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Login.InfoUser(username);
                        break;
                    case 2:
                        Login.HapusUser(username);
                        break;
                    case 3:
                        Login.EditUser(username, 1);
                        break;
                    case 4:
                        Login.EditUser(username, 2);
                        break;
                    case 5:
                        Main();
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR INPUT !!!!");
                kon = Console.ReadLine();
                MenuUser(username);
            }
        }
    }
}
