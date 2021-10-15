using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Authentication
{
    class Login : User
    {
        public static void LoginUser()
        {
            try
            {
                var index = data.FindIndex(c => c.userNames == Username);
                var id = data[index].userIds;
                var idx = data.FindIndex(c => c.userIds == id);
                if (data[idx].userNames == Username)
                {
                    bool cek = BCrypt.Net.BCrypt.Verify(Password, data[idx].passwords);
                    if (cek == true)
                    {
                        Console.WriteLine("login success");
                        Program.MenuUser(Username);
                    }
                    else
                    {
                        Console.WriteLine("GAGAL LOGIN PASSWORD SALAH !!!");
                        kon = Console.ReadLine();
                        Program.Main();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("GAGAL LOGIN USERNAME SALAH !!!");
                kon = Console.ReadLine();
                Program.Main();
            }
        }
        public static void InfoUser(string usernames)
        {
            Console.Clear();
            Console.WriteLine("======================");
            int i = data.FindIndex(c => c.userNames == usernames);
            if (usernames == data[i].userNames)
            {
                Console.WriteLine($"ID      : { data[i].userIds}");
                Console.WriteLine("NAME     :" + data[i].firstNames + " " + data[i].lastNames);
                Console.WriteLine("USERNAME :" + data[i].userNames);
                Console.WriteLine("PASSWORD :" + data[i].passwords);
            }
            Console.WriteLine("======================");
            Console.WriteLine("ENTER UNTUK KEMBALI !!!");
            kon = Console.ReadLine();
            Program.MenuUser(usernames);
        }
        public static void HapusUser(string hpsUser)
        {
            Console.Clear();
            Console.Write($"Apakah ada yakin ingin menghapus ID ({hpsUser}) ? (Y|N)");
            string konfirmasi = Console.ReadLine();
            if ((konfirmasi == "Y") || (konfirmasi == "y"))
            {
                int i = data.FindIndex(c => c.userNames == hpsUser);
                data.RemoveAt(i);
                Console.Clear();
                Console.WriteLine("========== HAPUS DATA Berhasil ==========");
                Console.WriteLine("========== SILAHKAN MASUK KE MENU UTAMA ==========");
                Console.WriteLine("Tekan ENTER untuk Kembali");
                string con = Console.ReadLine();
                Program.Main();
            }
            else if ((konfirmasi == "N") || (konfirmasi == "n"))
            {
                Program.MenuUser(hpsUser);
            }
        }
        public static void EditUser(string edtUser, int ubah)
        {
            Console.Clear();
            try
            {
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMinimum8Chars = new Regex(@".{6,}");
                string userNameBaru, konfirmasi, konfirmasiPassword;

                int i = data.FindIndex(c => c.userNames == edtUser);
                bool cek;

                if (ubah == 1)
                {
                    Console.WriteLine("======= UBAH USER =======");
                    Console.Write("USERNAME BARU            : ");
                    userNameBaru = Console.ReadLine();

                    Console.Write($"Apakah ada yakin ingin mengubah ID ({edtUser}) ? (Y|N)");
                    konfirmasi = Console.ReadLine();
                    if ((konfirmasi == "Y") || (konfirmasi == "y"))
                    {
                        Console.WriteLine("Masukkan Password untuk mengubah Username ");
                        Console.Write("Password : ");
                        konfirmasiPassword = Console.ReadLine();
                        cek = BCrypt.Net.BCrypt.Verify(konfirmasiPassword, data[i].passwords);
                        if (cek == true)
                        {
                            int j = 0;
                            for (int a = 0; a < data.Count; a++)
                            {
                                if (userNameBaru == data[a].userNames)
                                {
                                    j = 1;
                                }
                            }
                            if (j > 0)
                            {
                                Console.WriteLine("USERNAME SUDAH ADA !!!");
                                kon = Console.ReadLine();
                                Program.MenuUser(edtUser);
                            }
                            else
                            {
                                data[i].userNames = userNameBaru;
                                Console.WriteLine("======= BERHASIL SILAHKAN LOGIN KEMBALI =======");
                                kon = Console.ReadLine();
                                Program.Main();
                            }
                        }
                        else
                        {
                            Console.WriteLine("======= PASSWORD SALAH !!! =======");
                            kon = Console.ReadLine();
                            Program.MenuUser(edtUser);
                        }
                    }
                    else if ((konfirmasi == "N") || (konfirmasi == "n"))
                    {
                        Program.MenuUser(edtUser);
                    }
                }
                else
                {
                    Console.WriteLine("======= UBAH PASSWORD USER =======");
                    Console.Write("PASSWORD BARU                : ");
                    string passBaru = Console.ReadLine();
                    Console.Write("PASSWORD KONFIRMASI BARU     : ");
                    string passBaruKonfir = Console.ReadLine();
                    if (passBaru == "")
                    {
                        Console.WriteLine("Password Should not be empty");
                        kon = Console.ReadLine();
                        Program.MenuUser(edtUser);
                    }
                    else if (!hasNumber.IsMatch(passBaru))
                    {
                        Console.WriteLine("Password should contains number");
                        kon = Console.ReadLine();
                        Program.MenuUser(edtUser);
                    }
                    else if (!hasUpperChar.IsMatch(passBaru))
                    {
                        Console.WriteLine("Password should has Upper Character");
                        kon = Console.ReadLine();
                        Program.MenuUser(edtUser);
                    }
                    else if (!hasMinimum8Chars.IsMatch(passBaru))
                    {
                        Console.WriteLine("Password should has Minimum 6 Characters");
                        kon = Console.ReadLine();
                        Program.MenuUser(edtUser);
                    }
                    else
                    {
                        if (passBaru == passBaruKonfir)
                        {
                            Console.Write($"Apakah ada yakin ingin mengubah Password ID ({edtUser}) ? (Y|N)");
                            konfirmasi = Console.ReadLine();
                            if ((konfirmasi == "Y") || (konfirmasi == "y"))
                            {
                                Console.WriteLine("Masukkan Password Lama untuk mengubah Password ");
                                Console.Write("Password : ");
                                konfirmasiPassword = Console.ReadLine();
                                cek = BCrypt.Net.BCrypt.Verify(konfirmasiPassword, data[i].passwords);
                                if (cek == true)
                                {
                                    hashPassword = BCrypt.Net.BCrypt.HashString(passBaru);
                                    data[i].passwords = hashPassword;
                                    Console.WriteLine("======= BERHASIL SILAHKAN LOGIN KEMBALI =======");
                                    kon = Console.ReadLine();
                                    Program.Main();
                                }
                                else
                                {
                                    Console.WriteLine("======= PASSWORD SALAH !!! =======");
                                    kon = Console.ReadLine();
                                    Program.MenuUser(edtUser);
                                }
                            }
                            else if ((konfirmasi == "N") || (konfirmasi == "n"))
                            {
                                Program.MenuUser(edtUser);
                            }
                        }
                        else
                        {
                            Console.WriteLine("======= PASSWORD TIDAK SAMA !!! =======");
                            kon = Console.ReadLine();
                            Program.MenuUser(edtUser);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR INPUT !!!!");
                kon = Console.ReadLine();
                Program.MenuUser(edtUser);
            }
        }
    }
}
