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
    public partial class Edit_database : Form
    {
        /*На данной странице вам будет видна полная информация об абонентах и номерах.*/
        public Edit_database()
        {
            InitializeComponent();
        }

        private void Edit_database_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            int count = 0;

            if(Database.size > 0)
            {
                //при загрузке формы появиться полный список абонентов и номеров, которые храняться в базе данных;
                for(int i = 0; i < Database.size; i++)
                {
                    //если все данные пусты кроме номера - номер свободен;
                    if(Database.phone_number[i] != null && Database.surname[i] == null)
                    {
                        richTextBox2.Text += ($"{i + 1}) {Database.phone_number[i]}\n\n");
                        count++;
                    }

                    //в противном случае либо вся информация присутствует, либо она удалена совсем;
                    if(Database.phone_number[i] != null && Database.surname[i] != null)
                    {
                        richTextBox1.Text += ($"Абонент номер {i + 1}:\n");
                        richTextBox1.Text += ($"Фамилия: {Database.surname[i]}\n");
                        richTextBox1.Text += ($"Имя: {Database.name[i]}\n");
                        richTextBox1.Text += ($"Отчество: {Database.patronymic[i]}\n");
                        richTextBox1.Text += ($"Адрес: {Database.address[i]}\n");
                        richTextBox1.Text += ($"Номер телефона: {Database.phone_number[i]}\n\n");
                        count++;
                    }
                    if(Database.phone_number[i] == null)
                    {
                        richTextBox1.Text += ($"Абонент номер {i + 1} удален либо информация он нем отсутствует\n\n");
                        count++;
                    }
                }
                if(count == 0)
                {
                    richTextBox1.Text = ($"База данных пуста\n\n");
                }
            }
            else
            {
                richTextBox1.Text = ($"В базу данных еще не разу не был внесен абонент или номер\n\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_page home_page = new Home_page();
            home_page.Show();
        }
        //мы не можем изменять и удалять данные пока не добавим хотя-бы одного абонента;
        private void button2_Click(object sender, EventArgs e)
        {
            if (Database.size > 0)
            {
                Delete_information delete_Information = new Delete_information();
                delete_Information.Show();
            }
            else
            {
                MessageBox.Show("В базу не было добавлено элементов для их удаления");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Database.size > 0)
            {
                Edit_user_data edit_User_Data = new Edit_user_data();
                edit_User_Data.Show();
            }
            else
            {
                MessageBox.Show("В базу не было добавлено элементов для их редактирования");
            }
        }
    }
}
