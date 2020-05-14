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
    public partial class Delete_information : Form
    {
        /*Здесь можно удалить пустой номер либо полную
          информацию о пользователе из базы данных.*/
        public Delete_information()
        {
            InitializeComponent();
        }

        private void Delete_information_Load(object sender, EventArgs e)
        {
            MessageBox.Show("На данной странице вы можете удалить как свободный номер, так и полную информацию");
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int delete_number, count = 0;

            try
            {
                delete_number = Convert.ToInt32(textBox1.Text);

                delete_number -= 1;

                for(int i = 0; i < Database.size; i++)
                {
                    //если под вводимым индексом не храниться пустая строка, то информацию можно удалить;
                    if(delete_number == i && Database.phone_number[i] != null)
                    {
                        //удаляем нужную информацию в зависимости от того свободный ли номер;
                        if (Database.surname[i] != null)
                        {
                            Array.Clear(Database.phone_number, delete_number, 1);
                            Array.Clear(Database.surname, delete_number, 1);
                            Array.Clear(Database.name, delete_number, 1);
                            Array.Clear(Database.patronymic, delete_number, 1);
                            Array.Clear(Database.address, delete_number, 1);
                            count++;
                            MessageBox.Show("Удаление прошло успешно!");
                            break;
                        }
                        else
                        {
                            Array.Clear(Database.phone_number, delete_number, 1);
                            count++;
                            MessageBox.Show("Удаление прошло успешно!");
                            break;
                        }
                    }
                }
                if(count == 0)
                {
                    MessageBox.Show("Абонента с таким номером не существует");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Некорректно введено числовое значение");
            }
        }
    }
}
