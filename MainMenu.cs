using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG7312_POE
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        //Click button event to handle the users navigation to the "ReportIssues" form
        private void ReportButton_Click(object sender, EventArgs e)
        {
            //Creating an instance of the Report Issues form and showing that form once the user clicks the button
            ReportIssuesForm reportIssuesForm = new ReportIssuesForm();
            reportIssuesForm.Show();
            //Hiding the main Page to reduce cluttered look 
            this.Hide();
        }

        private void LocalButton_Click(object sender, EventArgs e)
        {

        }

        private void ServiceButton_Click(object sender, EventArgs e)
        {

        }
    }
}
