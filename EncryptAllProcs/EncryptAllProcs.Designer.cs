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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdEncryptObjects = new System.Windows.Forms.Button();
            this.chkWindowsAuth = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmdTestConnection
            // 
            this.cmdTestConnection.Location = new System.Drawing.Point(46, 169);
            this.cmdTestConnection.Name = "cmdTestConnection";
            this.cmdTestConnection.Size = new System.Drawing.Size(124, 23);
            this.cmdTestConnection.TabIndex = 0;
            this.cmdTestConnection.Text = "Test Connection";
            this.cmdTestConnection.UseVisualStyleBackColor = true;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(145, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(283, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(145, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(118, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(145, 103);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(118, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.UseSystemPasswordChar = true;
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
            this.cmdEncryptObjects.Location = new System.Drawing.Point(212, 169);
            this.cmdEncryptObjects.Name = "cmdEncryptObjects";
            this.cmdEncryptObjects.Size = new System.Drawing.Size(124, 23);
            this.cmdEncryptObjects.TabIndex = 0;
            this.cmdEncryptObjects.Text = "Encrypt All DB Text";
            this.cmdEncryptObjects.UseVisualStyleBackColor = true;
            // 
            // chkWindowsAuth
            // 
            this.chkWindowsAuth.AutoSize = true;
            this.chkWindowsAuth.Location = new System.Drawing.Point(284, 99);
            this.chkWindowsAuth.Name = "chkWindowsAuth";
            this.chkWindowsAuth.Size = new System.Drawing.Size(144, 17);
            this.chkWindowsAuth.TabIndex = 3;
            this.chkWindowsAuth.Text = "Windows  Authentication";
            this.chkWindowsAuth.UseVisualStyleBackColor = true;
            // 
            // EncryptAllDBObjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 263);
            this.Controls.Add(this.chkWindowsAuth);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdEncryptObjects;
        private System.Windows.Forms.CheckBox chkWindowsAuth;
    }
}

