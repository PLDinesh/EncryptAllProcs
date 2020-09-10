namespace EncryptAllProcs
{
    partial class EncryptAllDBObjectsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.cmdTestConnection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdEncryptObjects = new System.Windows.Forms.Button();
            this.chkWindowsAuth = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmdTestConnection
            // 
            this.cmdTestConnection.Location = new System.Drawing.Point(46, 224);
            this.cmdTestConnection.Name = "cmdTestConnection";
            this.cmdTestConnection.Size = new System.Drawing.Size(124, 23);
            this.cmdTestConnection.TabIndex = 4;
            this.cmdTestConnection.Text = "Test Connection";
            this.cmdTestConnection.UseVisualStyleBackColor = true;
            this.cmdTestConnection.Click += new System.EventHandler(this.cmdTestConnection_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server Name";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(145, 21);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(283, 20);
            this.txtServerName.TabIndex = 0;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(145, 59);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(118, 20);
            this.txtUserID.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(145, 103);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(118, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password";
            // 
            // cmdEncryptObjects
            // 
            this.cmdEncryptObjects.Location = new System.Drawing.Point(212, 224);
            this.cmdEncryptObjects.Name = "cmdEncryptObjects";
            this.cmdEncryptObjects.Size = new System.Drawing.Size(124, 23);
            this.cmdEncryptObjects.TabIndex = 5;
            this.cmdEncryptObjects.Text = "Encrypt All DB Text";
            this.cmdEncryptObjects.UseVisualStyleBackColor = true;
            this.cmdEncryptObjects.Click += new System.EventHandler(this.cmdEncryptObjects_Click);
            // 
            // chkWindowsAuth
            // 
            this.chkWindowsAuth.AutoSize = true;
            this.chkWindowsAuth.Location = new System.Drawing.Point(284, 106);
            this.chkWindowsAuth.Name = "chkWindowsAuth";
            this.chkWindowsAuth.Size = new System.Drawing.Size(144, 17);
            this.chkWindowsAuth.TabIndex = 3;
            this.chkWindowsAuth.Text = "Windows  Authentication";
            this.chkWindowsAuth.UseVisualStyleBackColor = true;
            this.chkWindowsAuth.CheckedChanged += new System.EventHandler(this.chkWindowsAuth_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Database";
            // 
            // cboComboBox
            // 
            this.cboComboBox.FormattingEnabled = true;
            this.cboComboBox.Location = new System.Drawing.Point(145, 148);
            this.cboComboBox.Name = "cboComboBox";
            this.cboComboBox.Size = new System.Drawing.Size(221, 21);
            this.cboComboBox.TabIndex = 7;
            // 
            // EncryptAllDBObjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 288);
            this.Controls.Add(this.cboComboBox);
            this.Controls.Add(this.chkWindowsAuth);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdEncryptObjects);
            this.Controls.Add(this.cmdTestConnection);
            this.Name = "EncryptAllDBObjectsForm";
            this.Text = "Encrypt All Procs and Functions";
            this.Load += new System.EventHandler(this.EncryptAllDBObjectsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdTestConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdEncryptObjects;
        private System.Windows.Forms.CheckBox chkWindowsAuth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboComboBox;
    }
}

