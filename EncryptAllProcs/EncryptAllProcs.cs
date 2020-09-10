using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace EncryptAllProcs
{
    public partial class EncryptAllDBObjectsForm : Form
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public EncryptAllDBObjectsForm()
        {
            InitializeComponent();
            _logger.Info("Application init .. Begin");


            cmdEncryptObjects.Enabled = false;
        }

        private string ConnectionString
        {
            get
            {
                string m_connectionString = string.Empty;

                m_connectionString = "Server=" + txtServerName.Text + (chkWindowsAuth.Checked ? ";Integrated Security=SSPI;" : "User ID=" + txtUserID.Text + ";Password=" + txtPassword.Text); ;

                return m_connectionString;
            }
        }

        private void EncryptAllDBObjectsForm_Load(object sender, EventArgs e)
        {
            chkWindowsAuth.Checked = false;
        }

        private void chkWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWindowsAuth.Checked)
            {
                txtPassword.Enabled = false;
                txtUserID.Enabled = false;
            }
            else
            {
                txtPassword.Enabled = true;
                txtUserID.Enabled = true;
            }
        }

        private void cmdTestConnection_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnectionInfo sci = new SqlConnectionInfo(txtServerName.Text);


                if (!chkWindowsAuth.Checked)
                {
                    sci.UseIntegratedSecurity = false;
                    sci.UserName = txtUserID.Text;
                    sci.Password = txtPassword.Text;
                }
                else
                {
                    sci.UseIntegratedSecurity = true;
                }

                var serverConnection = new ServerConnection(sci);



                var srv = new Server();
                try // Check to see if server connection details are ok.
                {
                    srv = new Server();
                    var db = new Database();
                    cboComboBox.Items.Clear();

                    for (int i = 0; i < srv.Databases.Count; i++)
                    {
                        var x = srv.Databases[i];
                        if (!x.IsSystemObject)
                            cboComboBox.Items.Add(x.ToString());
                    }
                    cmdEncryptObjects.Enabled = true;
                }
                catch (Exception InnerEx)
                {
                    _logger.Info("Server details are incorrect;"
                       + " please restart the application.");

                    MessageBox.Show("Error\n" + "Server details are incorrect;"
                       + "\nPlease restart the application.\n\n" + InnerEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Unable to connect to the DB");
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmdEncryptObjects_Click(object sender, EventArgs e)
        {
            try
            {


                DialogResult dlgRes = MessageBox.Show("Are you sure you want to encrypt -> " + cboComboBox.Text, "Please Confirm", MessageBoxButtons.YesNo);

                if (dlgRes == DialogResult.Yes)
                {
                    dlgRes = MessageBox.Show("Please note that the encryption is not reversible. Please confirm that you want to encrypt -> " + cboComboBox.Text, "Please Confirm", MessageBoxButtons.YesNo);
                }

                if (dlgRes == DialogResult.No)
                {
                    return;
                }
                SqlConnectionInfo sci = new SqlConnectionInfo(txtServerName.Text);


                if (!chkWindowsAuth.Checked)
                {
                    sci.UseIntegratedSecurity = false;
                    sci.UserName = txtUserID.Text;
                    sci.Password = txtPassword.Text;
                }
                else
                {
                    sci.UseIntegratedSecurity = true;
                }

                var serverConnection = new ServerConnection(sci);



                var srv = new Server();
                try // Check to see if server connection details are ok.
                {
                    var db = new Database();
                    db = srv.Databases[cboComboBox.Text.TrimStart('[').TrimEnd(']')];
                    if (db == null)
                        throw new Exception("Error! Unable to select");

                    Console.WriteLine("Encrypted stored procedures: ");
                    var sp = new StoredProcedure();
                    for (int i = 0; i < db.StoredProcedures.Count; i++)
                    {
                        sp = db.StoredProcedures[i];
                        if (!sp.IsSystemObject)         // Exclude System stored procedures
                        {
                            if (!sp.IsEncrypted)        // Exclude already encrypted stored procedures
                            {
                                sp.TextMode = false;
                                sp.IsEncrypted = true;
                                sp.TextMode = true;
                                sp.Alter();
                                Console.WriteLine("   " + sp.Name); // display name of the SP.         
                                _logger.Info("Encrypting Proc =>{0}", sp.Name);
                            }
                        }
                    }

                    var udfs = new UserDefinedFunction();

                    for (int i = 0; i < db.UserDefinedFunctions.Count; i++)
                    {
                        udfs = db.UserDefinedFunctions[i];
                        if (!udfs.IsSystemObject)         // Exclude System stored procedures
                        {
                            if (!udfs.IsEncrypted)        // Exclude already encrypted stored procedures
                            {
                                udfs.TextMode = false;
                                udfs.IsEncrypted = true;
                                udfs.TextMode = true;
                                try
                                {
                                    udfs.Alter();
                                }
                                catch (Exception excep)
                                {
                                    _logger.Info("Encryption failed for -> {0}", excep.Message);
                                }
                                Console.WriteLine("   " + udfs.Name); // display name of the SP.         
                                _logger.Info("Encrypting UDF  =>{0}", udfs.Name);
                            }
                        }
                    }




                }
                catch (Exception InnerEx)
                {
                    _logger.Info("Server details are incorrect;"
                       + " please restart the application.");

                    MessageBox.Show("Error\n" + "Server details are incorrect;"
                       + "\nPlease restart the application.\n\n" + InnerEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Unable to connect to the DB");
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
