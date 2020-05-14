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
    public partial class Assign_number : Form
    {
        /*На данной странице можно переназначить свободный номер
          другому пользователю. Номер можно переназначить только абоненту,
          о котором известна вся информация а не только номер.*/
        public Assign_number()
        {
            InitializeComponent();
        }

        private void Assign_number_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int assignable, assigned, count = 0;

            //проверка корректности ввода;
            try
            {
                assignable = Convert.ToInt32(textBox1.Text);
                assigned = Convert.ToInt32(textBox2.Text);

                assignable -= 1;
                assigned -= 1;

                //ищем совпадения по индексу в базе данных - если под индексом храниться только номер, то идем дальше;
                for (int i = 0; i < Database.size; i++)
                {
                    if (assignable == i && Database.phone_number[i] != null && Database.surname[i] == null)
                    {
                        count++;
                        break;
                    }
                }
                if (count == 0)
                {
                    MessageBox.Show("Переназначаемый номер уже используется либо индекс введен некорректно");
                }
                else
                {
                    count = 0;
                    for(int i = 0; i < Database.size; i++)
                    {
                        //под индексом должна храниться полная информация, при этом индекс номера который переназначают и которому переназначают не должны совпадать - тогда номер будет переназначен;
                        if (assigned == i && Database.phone_number[i] != null && Database.surname[i] != null && assignable != assigned)
                        {
                            Database.phone_number[assigned] = Database.phone_number[assignable];
                            Array.Clear(Database.phone_number, assignable, 1);
                            count++;
                            MessageBox.Show("Номер переназначен!");
                            break;
                        }
                    }
                    if(count == 0)
                    {
                        MessageBox.Show("Индексы номеров совпадают либо некорректно введено значение, проверьте правильность ввода");
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Некорретно введенный индекс");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edit_user_data edit_User_Data = new Edit_user_data();
            edit_User_Data.Show();
        }
    }
}
