using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Course_14
{
    public partial class New_password : Form
    {
        //На данной странице вы можете изменить пароль для изменения информации об абонентах;
        public New_password()
        {
            InitializeComponent();
        }

        private void New_password_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string password;

            password = textBox1.Text;

            if (password.Length > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Password(*.txt) | *.txt";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    //Если пароль длинной хотя-бы один символ - сохраняем его как в переменную, так и в файл;
                    string filename = save.FileName; 
                    File.WriteAllText(filename, textBox1.Text);
                    Database.password = password;
                    MessageBox.Show("Пароль сохранен");
                }
            }
            else
            {
                MessageBox.Show("Пароль должен быть длинной минимум один символ");
            }
        }
    }
}
