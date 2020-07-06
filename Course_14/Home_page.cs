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
    public partial class Home_page : Form
    {
        //данная страница является главной
        public Home_page()
        {
            InitializeComponent();
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //открываем форму
        private void NewUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            New_user new_user = new New_user();
            new_user.Show();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search search = new Search();
            search.Show();
        }

        private void EditDatabase_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edit_database edit_database = new Edit_database();
            edit_database.Show();
        }
    }
}
