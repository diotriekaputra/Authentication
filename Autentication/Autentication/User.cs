using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Authentication
{
    class User
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string KonfirmasiPassword { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }

        protected static List<User> data = new List<User>();

        public string firstNames, lastNames, passwords, userNames, userIds;
        public static string idUser, kon, hashPassword;
        public static int id = 0;

        public static void TambahUser()
        {
            try
            {
                if (KonfirmasiPassword == Password)
                {
                    var hasNumber = new Regex(@"[0-9]+");
                    var hasUpperChar = new Regex(@"[A-Z]+");
                    var hasMinimum8Chars = new Regex(@".{6,}");
                    if (Password == "")
                    {
                        Console.WriteLine("Password Should not be empty");
                        kon = Console.ReadLine();
                        Program.CreateUser();
                    }
                    else if (!hasNumber.IsMatch(Password))
                    {
                        Console.WriteLine("Password should contains number");
                        kon = Console.ReadLine();
                        Program.CreateUser();
                    }
                    else if (!hasUpperChar.IsMatch(Password))
                    {
                        Console.WriteLine("Password should has Upper Character");
                        kon = Console.ReadLine();
                        Program.CreateUser();
                    }
                    else if (!hasMinimum8Chars.IsMatch(Password))
                    {
                        Console.WriteLine("Password should has Minimum 6 Characters");
                        kon = Console.ReadLine();
                        Program.CreateUser();
                    }
                    else
                    {

                        idUser = (Convert.ToString((data.Count) + 1));
                        Username = FirstName.Substring(0, 2) + LastName.Substring(0, 2) + idUser;
                        hashPassword = BCrypt.Net.BCrypt.HashString(Password);

                        data.Add(new User { userIds = idUser, firstNames = FirstName, lastNames = LastName, passwords = hashPassword, userNames = Username });
                        Console.WriteLine("======= BERHASIL =======");
                        kon = Console.ReadLine();
                        Program.Main();
                    }
                }
                else
                {
                    Console.WriteLine("Password dan konfirmasi password tidak sama !!!");
                    kon = Console.ReadLine();
                    Program.CreateUser();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR INPUT !!!!");
                kon = Console.ReadLine();
                Program.Main();
            }
        }
        public static void ShowUser(string username)
        {
            Console.Clear();
            if (data.Count == 0)
            {
                Console.WriteLine("======Show User=======");
                Console.WriteLine("DATA BELUM ADA");
                kon = Console.ReadLine();
                Program.Main();
            }
            else
            {
                if (username == "")
                {
                    Console.WriteLine("======Show User=======");
                    Console.WriteLine("======================");
                    for (int i = 0; i < data.Count; i++)
                    {
                        Console.WriteLine($"ID USER  : {data[i].userIds}");
                        Console.WriteLine($"NAME     : {data[i].firstNames} {data[i].lastNames}");
                        Console.WriteLine($"USERNAME : {data[i].userNames}");
                        Console.WriteLine($"PASSWORD : {data[i].passwords}");
                        Console.WriteLine("======================");
                    }
                }
                else
                {
                    try
                    {
                        int i = data.FindIndex(c => c.userNames == username);
                        if (username == data[i].userNames)
                        {
                            Console.WriteLine($"ID      : { data[i].userIds}");
                            Console.WriteLine("NAME     :" + data[i].firstNames + " " + data[i].lastNames);
                            Console.WriteLine("USERNAME :" + data[i].userNames);
                            Console.WriteLine("PASSWORD :" + data[i].passwords);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("DATA TIDAK ADA !!!");
                        kon = Console.ReadLine();
                        Program.Main();
                    }
                }
                Console.WriteLine("ENTER UNTUK KEMBALI !!!");
                kon = Console.ReadLine();
                Program.Main();
            }
        }
    }
}
