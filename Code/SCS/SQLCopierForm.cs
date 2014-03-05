// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SQLCopierForm.cs" company="Dylan Corriveau">
//   
// </copyright>
// <summary>
//   This form is used to gather all the information necessary to copy the database
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SQLCopier;

namespace SCS
{
    /// <summary>
    /// The form used
    /// </summary>
    public partial class SQLCopierForm : Form
    {
        /// <summary>
        /// this attribute is used to define if an error occurred within the table identification stage
        /// </summary>
        private bool _error;
        /// <summary>
        /// this attribute is used to store the first connection number
        /// </summary>
        private int _connection1;
        /// <summary>
        /// this attribute is used to store the second connection number
        /// </summary>
        private int _connection2;
        /// <summary>
        /// this constructor is used to set up not only the UI elements, but also set up the SQL options (such as providers), 
        /// as well as gather the providers for the UI,
        /// </summary>
        public SQLCopierForm()
        {
            InitializeComponent();
            MainHandler.SetUp(Changes);
            string log = "Application Started, With ";
            foreach (var key in MainHandler.GetProviders())
            {
                comboBox1.Items.Add(key);
                comboBox2.Items.Add(key);
                log += key + ",";
            }
            comboBox1.SelectedIndex = comboBox2.SelectedIndex = 0;
            MainHandler.LogMessage(log.TrimEnd(',') + " as data providers");
        }
        /// <summary>
        /// this method is used to not only set up the new connection object, 
        /// but also check for the existence of the databases, and compare the table structures
        /// </summary>
        /// <param name="sender">
        /// the object that requested the event to be fired
        /// </param>
        /// <param name="e">
        /// any arguments needed for the event
        /// </param>
        private void BtnCheckTablesClick(object sender, EventArgs e)
        {
            //we first clear the options
            ClearOptions();
            _error = true;
            //if everything's set
            if (txtSrcServer.Text != "" && txtDestServer.Text != "" && txtDestDB.Text != "" && ((chkIntegrated.Checked) || txtUser.Text != "" & txtPassword.Text != "")
                && ((chkIntegrated2.Checked) || txtUser2.Text != "" & txtPassword2.Text != ""))
            {
                ShowAndLogMessage("Identifying changes to copy " + txtSrcDB.Text + " from " + comboBox1.SelectedItem + "-" + txtSrcServer.Text + " to " +
                           txtDestDB.Text + " in " + comboBox1.SelectedItem + "-" + txtDestServer.Text);
                Cursor = Cursors.WaitCursor;
                try
                {
                    //we add our new connections
                    _connection1=MainHandler.AddNewConnection(comboBox1.SelectedItem.ToString(), txtSrcServer.Text,
                                               chkIntegrated.Checked, txtUser.Text, txtPassword.Text);
                    _connection2=MainHandler.AddNewConnection(comboBox2.SelectedItem.ToString(), txtDestServer.Text,
                                               chkIntegrated2.Checked, txtUser2.Text, txtPassword2.Text);
                    //if the databases exist
                    if (MainHandler.CheckForExistanceOfDatabase(txtSrcDB.Text, _connection1))
                    {
                        if (MainHandler.CheckForExistanceOfDatabase(txtDestDB.Text, _connection2))
                        {
                            //we check if the source is empty
                            MainHandler.LogMessage("Both databases exist. Checking if the destination database is empty or not");
                            if (!MainHandler.CheckIfDbIsEmpty(txtSrcDB.Text, _connection1))
                            {
                                //if its not, we check if the destination is empty
                                MainHandler.LogMessage(MainHandler.CheckIfDbIsEmpty(txtDestDB.Text, _connection2)
                                                   ? "Destination is empty! Lets copy it all!"
                                                   : "Destination is Not Empty! Checking to see if the tables are the same");
                                MainHandler.LogMessage("Database B needs the following changes to be equal: ");
                                //in either case, we compare the structure of the tables. if the tables are compatable to convert, we gather changes
                                string status = MainHandler.CompareTableStructure(txtSrcDB.Text, txtDestDB.Text, _connection1, _connection2,chkSchemaOnly.Checked);
                                Cursor = Cursors.Default;
                                if (status == "")
                                {
                                    PopulateChangesList();
                                    MessageBox.Show("Please Review Changes before you go through with the copy");
                                    _error = false;
                                }
                                //otherwise, we alert that there's an error with the schema, and we leave
                                else
                                {
                                    Cursor = Cursors.Default;
                                    ShowAndLogMessage("The Schema's have conflictions! " + status + " We can't work with this!");
                                    changes.Clear();
                                }
                            }
                            else
                            {
                                Cursor = Cursors.Default;
                                ShowAndLogMessage("The Source database is empty! Aborting Operation!");
                            }

                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            ShowAndLogMessage("The Destination Database Doesn't Exist! Aborting operation!");
                        }

                    }
                    else
                    {
                        Cursor = Cursors.Default;
                        ShowAndLogMessage("The Source Database Doesn't Exist! Aborting operation!");
                    }
                } catch(Exception ex)
                {
                    Cursor = Cursors.Default;
                    ShowAndLogMessage("An Error Occurred that we didn't handle! " + ex.Message);
                }
            } else
            {
                MessageBox.Show("Please fill in all appropriate fields");
                _error = true;
            }
        }
        /// <summary>
        /// this method is used to reset the table, the changes, and the sql handler so they can be used.
        /// </summary>
        private void ClearOptions()
        {
            tblLay.Controls.Clear();
            tblLay.RowStyles.Clear();
            tblLay.ColumnStyles.Clear();
            tblLay.ColumnCount = 1;
            tblLay.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            changes.Clear();
            MainHandler.Reset();
        }
        /// <summary>
        /// this method is used to not only show a message to the user, but also put it in the logfile
        /// </summary>
        /// <param name="message">
        /// the message we want to show/log
        /// </param>
        private static void ShowAndLogMessage(string message)
        {
            MainHandler.LogMessage(message);
            MessageBox.Show(message);
        }
        /// <summary>
        /// this method is used to operate the checkmark on the corresponding table control given
        /// </summary>
        /// <param name="name">
        /// the name of the checkmark we want to check
        /// </param>
        private void CheckItem(string name)
        {
            //if a name was given
            if (name != "")
            {
                //if we can get the control
                CheckBox control = ((CheckBox)tblLay.Controls.Find(name, true)[0]);
                if (control != null)
                {
                    //if the control needs an invoke, we use a delegate, otherwise, just check it normally
                    if (control.InvokeRequired)
                    {
                        control.Invoke(new MethodInvoker(delegate { control.Checked = true; }));
                    }
                    else
                    {
                        control.Checked = true;
                    }
                }
            }
        }
        /// <summary>
        /// this method is used to gather the changes that are needed to populate the changes table
        /// </summary>
        private void PopulateChangesList()
        {
            List<string> chCopy = changes;
            chCopy.Sort();
            chCopy.Reverse();
            //for every option in the list, add a new check box with its name, and text set to the message, and have it not checked/enabled
            foreach (var message in chCopy)
            {
                CheckBox check = new CheckBox {Name=message,Text = message, AutoSize = true, Enabled = false};
                //also added to a new row
                tblLay.Controls.Add(check, 0, tblLay.RowStyles.Add(new RowStyle(SizeType.AutoSize)));
            }
        }
        /// <summary>
        /// this method is used to add a new message to the list of changes
        /// </summary>
        /// <param name="message">
        /// the message that we want to add
        /// </param>
        public void Changes(string message)
        {
            changes.Add(message);
            MainHandler.LogMessage(message);
            Invalidate();
        }
        /// <summary>
        /// this method is used to carry out the changes/copy of the data if there are changes
        /// </summary>
        /// <param name="sender">
        /// the object that requested the event to be fired
        /// </param>
        /// <param name="e">
        /// any arguments needed for the event
        /// </param>
        private void BtnCopyTablesClick(object sender, EventArgs e)
        {
            try
            {
                //if there are no errors, and there are changes, we confirm the changes
                if (!_error && changes.Count != 0)
                {
                    if (MessageBox.Show("Are the listed changes ok?", "Go Ahead?",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        btnChanges.Enabled = false;
                        btnCopyTables.Enabled = false;
                        UseWaitCursor = true;
                        ShowAndLogMessage("Starting copy transaction from database " + txtSrcDB.Text + " to " +
                                          txtDestDB.Text);

                        //if yes, we copy the tables over
                        new MainHandler.AsyncFactorCaller (MainHandler.ExecuteCopy).BeginInvoke(txtSrcDB.Text, txtDestDB.Text, _connection1,
                            _connection2,
                            CheckItem, chkSchemaOnly.Checked, FactorizedResults, 0);
                        MessageBox.Show((chkSchemaOnly.Checked ? "Schema" : "Data") + " Copying! Please feel free to do other work while this is occuring");
                    }
                }
                    //if there aren't changes, we alert the user
                else
                {
                    MessageBox.Show("No Changes Done! Please run the first section before you attempt to copy!");
                }
            }

            catch (Exception ex)
            {
                UseWaitCursor = false;
                ShowAndLogMessage("An Error Occurred in the transaction! " + ex.Message + " Rolling back changes!");
                ShowAndLogMessage("Starting identification of new possible changes needed");
                //we try to get a new list of changes (if possible)
                BtnCheckTablesClick(sender,e);
            }
        }
        /// <summary>
        /// This method is used to alert the user that the copy has been successful
        /// </summary>
        /// <param name="ar">
        /// the results of the async message
        /// </param>
        private void FactorizedResults(IAsyncResult ar)
        {
            UseWaitCursor = false;
            btnChanges.Invoke(new MethodInvoker(delegate { btnChanges.Enabled = true; }));
            btnCopyTables.Invoke(new MethodInvoker(delegate { btnCopyTables.Enabled = true; }));
            MessageBox.Show((chkSchemaOnly.Checked ? "Schema" : "Data") + " Copied!");
        }

        /// <summary>
        /// this method is used to turn off the user/password fields if integrated is used
        /// </summary>
        /// <param name="sender">
        /// the object that requested the event to be fired
        /// </param>
        /// <param name="e">
        /// any arguments needed for the event
        /// </param>
        private void ChkIntegratedCheckedChanged(object sender, EventArgs e)
        {
            txtUser.Enabled = txtPassword.Enabled = !chkIntegrated.Checked;
        }

        /// <summary>
        /// this method is used to turn off the user/password fields if integrated is used
        /// </summary>
        /// <param name="sender">
        /// the object that requested the event to be fired
        /// </param>
        /// <param name="e">
        /// any arguments needed for the event
        /// </param>
        private void ChkIntegrated2CheckedChanged(object sender, EventArgs e)
        {
            txtUser2.Enabled = txtPassword2.Enabled = !chkIntegrated2.Checked;
        }
        /// <summary>
        /// this method is used to clean up any form related issues, as well as log the closing of the application
        /// </summary>
        /// <param name="sender">
        /// the object that requested the event to be fired
        /// </param>
        /// <param name="e">
        /// any arguments needed for the event
        /// </param>
        private void SQLCopierFormFormClosed(object sender, FormClosedEventArgs e)
        {
            MainHandler.LogMessage("Application Closed!");
        }
    }
}
