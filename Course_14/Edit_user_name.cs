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
    public partial class Edit_user_name : Form
    {
        /*На данной странице пользователь может редактировать данные.
          После корректного ввода всех данных ему необходимо будет выбрать
          файл для считывания пароля. Если пароль считывается не в первый раз -
          его корректность будет проверена раннее сохраненным паролем.*/
        public Edit_user_name()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string number, name, surname, patronymic, address;
            int user_number;
            int count = 0, count_1 = 0;

            //проверка корректности;
            try
            {
                user_number = Convert.ToInt32(textBox1.Text);
                number = textBox2.Text;
                surname = textBox3.Text;
                name = textBox4.Text;
                patronymic = textBox5.Text;
                address = textBox6.Text;

                //после изменения данные не могут повторяться с другими в базе данных;
                for (int i = 0; i < Database.size; i++)
                {
                    if ((number != null && number == Database.phone_number[i]) || (surname != null && surname.Equals(Database.surname[i])) || (name != null && name.Equals(Database.name[i])) || (patronymic != null && patronymic.Equals(Database.patronymic[i])) || (address != null && address.Equals(Database.address[i])))
                    {
                        count++;
                        break;
                    }
                }

                //если данные не повторяются - проверяем корректность индекса абонента;
                if (count == 0)
                {
                    for (int i = 0; i < Database.size; i++)
                    {
                        if (user_number == i + 1 && user_number >= 1 && user_number <= Database.size)
                        {
                            user_number = i;
                            count_1++;
                            break;
                        }
                    }

                    //если индекс корректный - проверяем корректность всех остальных значений;
                    if (count_1 > 0 && number.Length > 9 && number.Length < 14 && name.Length >= 3 && surname.Length >= 3 && patronymic.Length >= 3 && address.Length >= 3)
                    {
                        OpenFileDialog open = new OpenFileDialog();
                        open.Filter = "Password(*.txt) | *.txt";

                        //пароль для изменения должен быть выбран из файла
                        if (open.ShowDialog() == DialogResult.OK)
                        {
                            string file_name = open.FileName;
                            FileStream file = new FileStream(file_name, FileMode.Open, FileAccess.Read);

                            //если пароль считывается впервые и его длина составляет > 2 символов - изменяем все данные и сохраняем пароль в глобальную переменную
                            if (Database.count == 0)
                            { 
                                string fileText = File.ReadAllText(file_name);
                                textBox7.Text = fileText;

                                if (textBox7.Text.Length > 0)
                                {
                                    Database.count++;
                                    Database.password = textBox7.Text;
                                    Database.phone_number[user_number] = number;
                                    Database.name[user_number] = name;
                                    Database.surname[user_number] = surname;
                                    Database.patronymic[user_number] = patronymic;
                                    Database.address[user_number] = address;

                                    MessageBox.Show("Все данные изменены!");
                                    file.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Пароль не может быть длинной менее одного символа");
                                    file.Close();
                                }
                            }

                            //если пароль уже был считан раннее, то считываем пароль из файла и проверяем его корректность - он должен совпасть с раннее сохраненным;
                            else
                            {
                                string fileText = File.ReadAllText(file_name);
                                textBox7.Text = fileText;
                                if(textBox7.Text == Database.password)
                                {
                                    Database.phone_number[user_number] = number;
                                    Database.name[user_number] = name;
                                    Database.surname[user_number] = surname;
                                    Database.patronymic[user_number] = patronymic;
                                    Database.address[user_number] = address;

                                    MessageBox.Show("Все данные изменены!");
                                    file.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Пароль некорректный");
                                    file.Close();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Данные введены некорректно либо совпадают с раннее введенными");
                    }
                }
                else
                {
                    MessageBox.Show("Одно или несколько из вводимых данных уже занято");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Неверный формат введенных данных");
            }
        }

        private void Edit_user_name_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Введите новые данные. Пароль для подтверждения будет выбран вами из файла");
            this.CenterToScreen();
        }

        //пароль нельзя менять пока он не разу не был считан
        private void EditPassword_Click(object sender, EventArgs e)
        {
            if(Database.password != null)
            {
                New_password new_password = new New_password();
                new_password.Show();
            }
            else
            {
                MessageBox.Show("Пароль не был записан из файла для его изменения");
            }
        }
    }
}
