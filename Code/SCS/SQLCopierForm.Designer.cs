using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SCS
{
    partial class SQLCopierForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSrcServer = new System.Windows.Forms.TextBox();
            this.txtDestServer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDestDB = new System.Windows.Forms.TextBox();
            this.btnCopyTables = new System.Windows.Forms.Button();
            this.chkIntegrated = new System.Windows.Forms.CheckBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSrcDB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tblLay = new System.Windows.Forms.TableLayoutPanel();
            this.btnChanges = new System.Windows.Forms.Button();
            this.connection1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkIntegrated2 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUser2 = new System.Windows.Forms.TextBox();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chkSchemaOnly = new System.Windows.Forms.CheckBox();
            this.connection1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(183, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(183, 54);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source DB Provider:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Destination DB Provider:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Source Server Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Destination Server Name:";
            // 
            // txtSrcServer
            // 
            this.txtSrcServer.Location = new System.Drawing.Point(183, 92);
            this.txtSrcServer.Name = "txtSrcServer";
            this.txtSrcServer.Size = new System.Drawing.Size(121, 20);
            this.txtSrcServer.TabIndex = 8;
            this.txtSrcServer.Text = "localhost";
            // 
            // txtDestServer
            // 
            this.txtDestServer.Location = new System.Drawing.Point(183, 125);
            this.txtDestServer.Name = "txtDestServer";
            this.txtDestServer.Size = new System.Drawing.Size(121, 20);
            this.txtDestServer.TabIndex = 9;
            this.txtDestServer.Text = "localhost";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Destination DB Name:";
            // 
            // txtDestDB
            // 
            this.txtDestDB.Location = new System.Drawing.Point(184, 199);
            this.txtDestDB.Name = "txtDestDB";
            this.txtDestDB.Size = new System.Drawing.Size(121, 20);
            this.txtDestDB.TabIndex = 11;
            this.txtDestDB.Text = "Clinic";
            // 
            // btnCopyTables
            // 
            this.btnCopyTables.Location = new System.Drawing.Point(12, 512);
            this.btnCopyTables.Name = "btnCopyTables";
            this.btnCopyTables.Size = new System.Drawing.Size(292, 23);
            this.btnCopyTables.TabIndex = 16;
            this.btnCopyTables.Text = "Copy Database";
            this.btnCopyTables.UseVisualStyleBackColor = true;
            this.btnCopyTables.Click += new System.EventHandler(this.BtnCopyTablesClick);
            // 
            // chkIntegrated
            // 
            this.chkIntegrated.AutoSize = true;
            this.chkIntegrated.Location = new System.Drawing.Point(3, 3);
            this.chkIntegrated.Name = "chkIntegrated";
            this.chkIntegrated.Size = new System.Drawing.Size(194, 17);
            this.chkIntegrated.TabIndex = 12;
            this.chkIntegrated.Text = "Integrated Security (for SQL Server)";
            this.chkIntegrated.UseVisualStyleBackColor = true;
            this.chkIntegrated.CheckedChanged += new System.EventHandler(this.ChkIntegratedCheckedChanged);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(166, 30);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(121, 20);
            this.txtUser.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-3, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Username";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(166, 69);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(121, 20);
            this.txtPassword.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-3, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Password";
            // 
            // txtSrcDB
            // 
            this.txtSrcDB.Location = new System.Drawing.Point(183, 162);
            this.txtSrcDB.Name = "txtSrcDB";
            this.txtSrcDB.Size = new System.Drawing.Size(121, 20);
            this.txtSrcDB.TabIndex = 10;
            this.txtSrcDB.Text = "NDC";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Source DB Name:";
            // 
            // tblLay
            // 
            this.tblLay.AutoScroll = true;
            this.tblLay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLay.Location = new System.Drawing.Point(310, 20);
            this.tblLay.Name = "tblLay";
            this.tblLay.Size = new System.Drawing.Size(535, 515);
            this.tblLay.TabIndex = 18;
            // 
            // btnChanges
            // 
            this.btnChanges.Location = new System.Drawing.Point(12, 483);
            this.btnChanges.Name = "btnChanges";
            this.btnChanges.Size = new System.Drawing.Size(291, 23);
            this.btnChanges.TabIndex = 15;
            this.btnChanges.Text = "Generate Changes";
            this.btnChanges.UseVisualStyleBackColor = true;
            this.btnChanges.Click += new System.EventHandler(this.BtnCheckTablesClick);
            // 
            // connection1
            // 
            this.connection1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connection1.Controls.Add(this.chkIntegrated);
            this.connection1.Controls.Add(this.label6);
            this.connection1.Controls.Add(this.txtUser);
            this.connection1.Controls.Add(this.txtPassword);
            this.connection1.Controls.Add(this.label7);
            this.connection1.Location = new System.Drawing.Point(13, 256);
            this.connection1.Name = "connection1";
            this.connection1.Size = new System.Drawing.Size(291, 93);
            this.connection1.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkIntegrated2);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtUser2);
            this.panel1.Controls.Add(this.txtPassword2);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(13, 381);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 96);
            this.panel1.TabIndex = 25;
            // 
            // chkIntegrated2
            // 
            this.chkIntegrated2.AutoSize = true;
            this.chkIntegrated2.Location = new System.Drawing.Point(3, 3);
            this.chkIntegrated2.Name = "chkIntegrated2";
            this.chkIntegrated2.Size = new System.Drawing.Size(194, 17);
            this.chkIntegrated2.TabIndex = 12;
            this.chkIntegrated2.Text = "Integrated Security (for SQL Server)";
            this.chkIntegrated2.UseVisualStyleBackColor = true;
            this.chkIntegrated2.CheckedChanged += new System.EventHandler(this.ChkIntegrated2CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(-3, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Username";
            // 
            // txtUser2
            // 
            this.txtUser2.Location = new System.Drawing.Point(166, 30);
            this.txtUser2.Name = "txtUser2";
            this.txtUser2.Size = new System.Drawing.Size(121, 20);
            this.txtUser2.TabIndex = 13;
            // 
            // txtPassword2
            // 
            this.txtPassword2.Location = new System.Drawing.Point(166, 71);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.PasswordChar = '*';
            this.txtPassword2.Size = new System.Drawing.Size(121, 20);
            this.txtPassword2.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(-3, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Connection 1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 361);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Connection 2";
            // 
            // chkSchemaOnly
            // 
            this.chkSchemaOnly.AutoSize = true;
            this.chkSchemaOnly.Location = new System.Drawing.Point(183, 232);
            this.chkSchemaOnly.Name = "chkSchemaOnly";
            this.chkSchemaOnly.Size = new System.Drawing.Size(114, 17);
            this.chkSchemaOnly.TabIndex = 26;
            this.chkSchemaOnly.Text = "Just Copy Schema";
            this.chkSchemaOnly.UseVisualStyleBackColor = true;
            // 
            // SQLCopierForm
            // 
            this.ClientSize = new System.Drawing.Size(857, 547);
            this.Controls.Add(this.chkSchemaOnly);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.connection1);
            this.Controls.Add(this.btnChanges);
            this.Controls.Add(this.tblLay);
            this.Controls.Add(this.txtSrcDB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCopyTables);
            this.Controls.Add(this.txtDestDB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDestServer);
            this.Controls.Add(this.txtSrcServer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Name = "SQLCopierForm";
            this.Text = "SQL Database Copier";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SQLCopierFormFormClosed);
            this.connection1.ResumeLayout(false);
            this.connection1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtSrcServer;
        private TextBox txtDestServer;
        private Label label5;
        private TextBox txtDestDB;
        private Button btnCopyTables;
        private CheckBox chkIntegrated;
        private TextBox txtUser;
        private Label label6;
        private TextBox txtPassword;
        private Label label7;
        private TextBox txtSrcDB;
        private Label label8;
        private TableLayoutPanel tblLay;
        internal List<string> changes = new List<string>();
        private Button btnChanges;
        private Panel connection1;
        private Panel panel1;
        private CheckBox chkIntegrated2;
        private Label label11;
        private TextBox txtUser2;
        private TextBox txtPassword2;
        private Label label12;
        private Label label9;
        private Label label10;
        private CheckBox chkSchemaOnly;
    }
}

