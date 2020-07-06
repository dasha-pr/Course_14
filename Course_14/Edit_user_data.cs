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
    public partial class Edit_user_data : Form
    {
        public Edit_user_data()
        {
            InitializeComponent();
        }


        private void Hide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edit_user_name edit_User_Name = new Edit_user_name();
            edit_User_Name.Show();
        }

        private void Assign_Click(object sender, EventArgs e)
        {
            this.Hide();
            Assign_number assign_Number = new Assign_number();
            assign_Number.Show();
        }
    }
}
