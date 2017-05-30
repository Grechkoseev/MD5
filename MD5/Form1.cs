using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace hash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string FreeTest()
        {
            byte[] hash = Encoding.ASCII.GetBytes(textBox1.Text);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashenc = md5.ComputeHash(hash);
            string result = "";
            foreach (var b in hashenc)
            {
                result += b.ToString("x2");
            }
            return result;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "";
            byte[] hash;
            using (Stream input = File.OpenRead("1.txt"))
            {
                hash = MD5.Create().ComputeHash(input);
            }
            foreach(var b in hash)
            {
                label1.Text += b.ToString("x2");
            }
        }
    }
}
