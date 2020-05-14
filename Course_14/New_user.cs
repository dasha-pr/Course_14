using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_14
{
    /*На данной странице вы можете добавить в базу данных
      как нового абонента, так и свободный номер.*/
    public partial class New_user : Form
    {
        public New_user()
        {
            InitializeComponent();
        }

        private void New_user_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Добро пожаловать на страницу создания нового абонента! Здесь вы можете как заполнить все данные об абоненте, так и ввести только номер - он будет свободным и его можно будет переназначить");
            this.CenterToScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_page home_page = new Home_page();
            home_page.Show();       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number, name, surname, patronymic, address;
            int count = 0;

            number = textBox1.Text;
            surname = textBox2.Text;
            name = textBox3.Text;
            patronymic = textBox4.Text;
            address = textBox5.Text;

            //данные о новом абоненте не могут совпадать с данными других абонентов базы данных;
            if(Database.size > 0)
            {
                for(int i = 0; i < Database.size; i++)
                {
                    if((number != null && number == Database.phone_number[i]) || (surname != null && surname == Database.surname[i]) || (name != null && name == Database.name[i]) || (patronymic != null && patronymic == Database.patronymic[i]) || (address != null && address == Database.address[i]))
                    {
                        count++;
                        break;
                    }
                }
            }
            //если данные не совпадают - проверяем, введена ли вся информация или только номер;
            if (count == 0)
            {
                if (number.Length > 9 && number.Length < 14 && (name.Length < 3 || surname.Length < 3 || patronymic.Length < 3 || address.Length < 3))
                {
                    DialogResult result = MessageBox.Show("Некоторые или все данные кроме номера телефона состоят менее чем из 3 символов. В данном случае вы добавите только номер телефона, однако его можно будет в дальнейшем передать другому пользователю. Если вы хотите записать полную информацию о пользователе - нажмите Нет и сделайте все данные длинной большей либо равной 3 символам. Если же вас устраивает сохранение одного номера - нажмите Да", " ", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Database.size++;
                        Array.Resize(ref Database.phone_number, Database.size);
                        Array.Resize(ref Database.name, Database.size);
                        Array.Resize(ref Database.surname, Database.size);
                        Array.Resize(ref Database.patronymic, Database.size);
                        Array.Resize(ref Database.address, Database.size);

                        for (int i = Database.size - 1; i < Database.size; i++)
                        {
                            Database.phone_number[i] = number;
                        }

                        MessageBox.Show("Номер сохранен!");
                    }
                }
                else
                {
                    //если же введена вся информация - проверяем ее корректность;
                    if (number.Length > 9 && number.Length < 14 && name.Length >= 3 && surname.Length >= 3 && patronymic.Length >= 3 && address.Length >= 3)
                    {
                        DialogResult result = MessageBox.Show("Все данные введены корректно. В вашем случае вы сохраните полную информацию о пользователе. Если вас все устраивает - нажмите Да. Если же вы хотите добавить только номер - нажмите Нет и сделайте все данные кроме номера длинной менее 3 символов. Номер в дальнейшем можно будет присвоить другому пользователю", " ", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            Database.size++;
                            Array.Resize(ref Database.phone_number, Database.size);
                            Array.Resize(ref Database.name, Database.size);
                            Array.Resize(ref Database.surname, Database.size);
                            Array.Resize(ref Database.patronymic, Database.size);
                            Array.Resize(ref Database.address, Database.size);

                            for (int i = Database.size - 1; i < Database.size; i++)
                            {
                                Database.phone_number[i] = number;
                                Database.name[i] = name;
                                Database.surname[i] = surname;
                                Database.patronymic[i] = patronymic;
                                Database.address[i] = address;
                            }

                            MessageBox.Show("Все данные сохранены!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Данные введены некорректно");
                    }
                }
            }
            else
            {
                MessageBox.Show("Одно или несколько из вводимых данных уже занято");
            }
        }
    }
}
