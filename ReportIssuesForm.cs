using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PROG7312_POE
{
    public partial class ReportIssuesForm : Form
    {
        public List<ReportedIssues> reportedIssues = new List<ReportedIssues>();

        public ReportIssuesForm()
        {
            InitializeComponent();
            //Setting the progress bar and timer's visibility to false
            progressBar.Visible = false;
            timer.Enabled = false;
        }
        //Event handler for when the "Submit" button is clicked
        private void submitBtn_Click(object sender, EventArgs e)
        {
            //If statement to check and validate that the user has inputted data into every required textbox
            //If the text Location is empty a Message Box displays an error message informing the user to enter a location
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter a location.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //If the combo box category is empty a Message Box displays an error message informing the user to select a category
            if (comboBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //If the text description is empty a Message Box displays an error message informing the user to enter a description
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please enter a description.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //If all input fields are valid the progress bar will display 
            progressBar.Visible = true;
            progressBar.Value = 0; //Reset progress bar
            timer.Enabled = true;  //Start the timer to show the progress
            timer.Start();
        }

        //Event handler for the timer tick thats used for the progress bar
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Increment the progress bar value
            if (progressBar.Value < 100)
            {
                progressBar.Value += 10;
            }
            else
            {
                timer.Stop();//The timer will stop once the progress bar is complete

                //Creating a new Issue object and setting its properties based on the users input
                ReportedIssues issue = new ReportedIssues
                {
                    Location = txtLocation.Text,
                    Category = comboBoxCategory.SelectedItem.ToString(),
                    Description = txtDescription.Text,
                    AttachedFilePath = lblFile.Text 
                };

                //Adding the new issue to the list
                reportedIssues.Add(issue);

                //Providing feedback to the user using a Message Box
                MessageBox.Show("Issue reported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Calling the ClearForm() method to clear the form
                ClearForm();
                progressBar.Visible = false; //Hiding the progress bar again once the form is complete
            }
        }

        //Method to clear the form once the user has logged an issue
        private void ClearForm()
        {
            txtLocation.Clear(); //Clear the text location
            comboBoxCategory.SelectedIndex = -1; //Reset the dropdown
            txtDescription.Clear(); //Clear the text description
            lblFile.Text = ""; //Clearing the file path label
        }

        //Event handler for when the "Attach Image" button is clicked
        private void AttachImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png|Document Files|*.doc;*.pdf"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Display the selected file path in a label
                lblFile.Text = openFileDialog.FileName;
                lblFile.Visible= true;
            }
        }
        //Event handler for when the "Return to Main Menu" button is clicked
        private void btnReturnMain_Click(object sender, EventArgs e)
        {
            //Creating an instance of the Main Menu form and showing that form once the user clicks the button
            MainMenu mMenu = new MainMenu();
            mMenu.Show();
            //hiding the current form
            this.Hide();
        }
    }
}
