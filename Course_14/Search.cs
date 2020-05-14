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
    //На данной странице вы можете найти информацию об абоненте по фамилии либо номеру;
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            MessageBox.Show("На данной странице вы можете найти абонента по фамилии либо номеру");
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
            if (Database.size == 0)
            {
                MessageBox.Show("На данный момент в базе данных нет информации не об одном абоненте");
            }
            else
            {
                string phone, surname;
                int count = 0;
                phone = textBox1.Text;
                surname = textBox2.Text;

                //поиск доступен только по одному критерию - номер либо фамилия;
                if((phone.Length > 0 && surname.Length > 0) || (phone.Length == 0 && surname.Length == 0))
                {
                    MessageBox.Show("Поиск возможен только по одному критерию");
                }
                else
                {
                    //если длина номера корректна - выполняем данное условие;
                    if(phone.Length > 9 && phone.Length < 14)
                    {
                        for(int i = 0; i < Database.size; i++)
                        {
                            if (phone == Database.phone_number[i] && Database.surname[i] != null)
                            {
                                richTextBox1.Text += ($"Абонент номер {i + 1}:\n");
                                richTextBox1.Text += ($"Имя: {Database.name[i]}\n");
                                richTextBox1.Text += ($"Фамилия: {Database.surname[i]}\n");
                                richTextBox1.Text += ($"Отчество: {Database.patronymic[i]}\n");
                                richTextBox1.Text += ($"Номер телефона: {Database.phone_number[i]}\n\n");
                                count++;
                                break;
                            }
                            if(phone == Database.phone_number[i] && Database.surname[i] == null)
                            {
                                richTextBox1.Text += ($"Номер {Database.phone_number[i]} не принадлежит не одному из абонентов\n\n");
                                count++;
                                break;
                            }
                        }
                        if(count == 0)
                        {
                            richTextBox1.Text += ($"Данного номера не существует\n\n");
                        }
                    }

                    //в противном случае проверяем - возможно был поиск по фамилии. Если это так - выдаем информацию либо сообщение;
                    else
                    {
                        int count_1 = 0;

                        if (surname.Length > 0)
                        {
                            count_1++;
                            for (int i = 0; i < Database.size; i++)
                            {
                                if (surname == Database.surname[i])
                                {
                                    richTextBox2.Text += ($"Абонент номер {i + 1}:\n");
                                    richTextBox2.Text += ($"Имя: {Database.name[i]}\n");
                                    richTextBox2.Text += ($"Фамилия: {Database.surname[i]}\n");
                                    richTextBox2.Text += ($"Отчество: {Database.patronymic[i]}\n");
                                    richTextBox2.Text += ($"Номер телефона: {Database.phone_number[i]}\n\n");
                                    count++;
                                    break;
                                }
                            }
                            if (count == 0)
                            {
                                richTextBox2.Text += ($"Абонента с такой фамилией не существует\n\n");
                            }
                        }

                        //если же все-таки был поиск по номеру, но он некорректен - выводим сообщение;
                        if(count_1 == 0)
                        {
                            MessageBox.Show("Номер должен быть длинной от 9 до 14 символов");
                        }
                    }
                }
            }   
        }
    }
}
