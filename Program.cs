using System;
using Models;
using Telas;
using System.Windows.Forms;


namespace PasswordManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new Login());
        }
    }
}
