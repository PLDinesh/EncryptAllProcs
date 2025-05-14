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
using EncryptAllProcs.Models;
using System.Runtime.InteropServices;

namespace EncryptAllProcs
{
    public partial class EncryptAllDBObjectsForm : Form
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private static ExcludeList _excludeList = null;

        private void LoadExcludeList()
        {
            try
            {
                string filePath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "ExcludeList.json");

                if (System.IO.File.Exists(filePath))
                {
                    string jsonContent = System.IO.File.ReadAllText(filePath);
                    _excludeList = Newtonsoft.Json.JsonConvert.DeserializeObject<ExcludeList>(jsonContent);
                    _logger.Info($"ExcludeList loaded successfully with {_excludeList.StoredProcedures.Count} stored procedures and {_excludeList.Views.Count} views");
                }
                else
                {
                    _excludeList = new ExcludeList();
                    _logger.Warn("ExcludeList.json file not found, using empty exclude list");
                }
            }
            catch (Exception ex)
            {
                _excludeList = new ExcludeList();
                _logger.Error(ex, "Failed to load ExcludeList.json");
                MessageBox.Show($"Error loading ExcludeList.json: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


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



                var srv = new Server(serverConnection);
                try // Check to see if server connection details are ok.
                {
                    //  srv = new Server();
                    var db = new Database();
                    cboComboBox.Items.Clear();

                    for (int i = 0; i < srv.Databases.Count; i++)
                    {
                        var x = srv.Databases[i];
                        if (!x.IsSystemObject)
                            cboComboBox.Items.Add(x.ToString());
                    }
                    cmdEncryptObjects.Enabled = true;
                    MessageBox.Show("Connected successfully!\n\n\nPlease select the database you want to encrypt and click encrypt!", "Success!", MessageBoxButtons.OK);
                }
                catch (Exception InnerEx)
                {
                    _logger.Info("Server details are incorrect;"
                       + " please retry with proper details");

                    MessageBox.Show("Error\n" + "Server details are incorrect;"
                       + "\nPlease retry with proper details.\n\n" + InnerEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                LoadExcludeList();

                DialogResult dlgRes = MessageBox.Show("Are you sure you want to encrypt -> " + cboComboBox.Text + "\n\n\nPlease confirm if a backup has been taken before this operation!", "Please Confirm", MessageBoxButtons.YesNo);

                if (dlgRes == DialogResult.Yes)
                {
                    dlgRes = MessageBox.Show("Please note that the encryption is not reversible. Please confirm that you want to encrypt -> " + cboComboBox.Text + "\n\n\nPlease confirm if a backup has been taken before this operation!", "Please Confirm", MessageBoxButtons.YesNo);
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



                var srv = new Server(serverConnection);
                try // Check to see if server connection details are ok.
                {
                    var db = new Database();
                    db = srv.Databases[cboComboBox.Text.TrimStart('[').TrimEnd(']')];
                    if (db == null)
                        throw new Exception("Error! Unable to select");

                    Console.WriteLine("Encrypted stored procedures: ");
                    Microsoft.SqlServer.Management.Smo.StoredProcedure sp = null;
                    for (int i = 0; i < db.StoredProcedures.Count; i++)
                    {
                        sp = db.StoredProcedures[i];
                        if(_excludeList !=null)
                        {
                            var excludeSP = _excludeList.StoredProcedures.FirstOrDefault(x => x.Name.ToLower() == sp.Name.ToLower() && x.DBName.ToLower() == db.Name.ToLower());
                            if (excludeSP != null)
                            {
                                _logger.Info("Skipping encryption for stored procedure: {0} in database: {1}", sp.Name, db.Name);
                                continue;
                            }

                            if (_excludeList.ExcludedSchemas.Contains(sp.Schema.ToLower()))
                            {
                                _logger.Info("Skipping encryption for stored procedure: {0} in database: {1} due to excluded schema", sp.Name, db.Name);
                                continue;
                            }
                        }
                        if (!sp.IsSystemObject)         // Exclude System stored procedures
                        {
                            if (!sp.IsEncrypted)        // Exclude already encrypted stored procedures
                            {
                                sp.TextMode = false;
                                sp.IsEncrypted = true;
                                sp.TextMode = true;

                                try
                                {
                                    sp.Alter();
                                }
                                catch (Exception excep)
                                {
                                    _logger.Info(excep, "Encryption failed for -> {0}, error- -> {1}", sp.Name, excep.Message);
                                }
                                Console.WriteLine("   " + sp.Name); // display name of the SP.         
                                _logger.Info("Encrypting Proc =>{0}", sp.Name);
                            }
                        }
                    }

                    var udfs = new UserDefinedFunction();

                    for (int i = 0; i < db.UserDefinedFunctions.Count; i++)
                    {
                        udfs = db.UserDefinedFunctions[i];
                        if (!udfs.IsSystemObject)
                        {
                            if (!udfs.IsEncrypted)
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
                                    _logger.Info(excep, "Encryption failed for -> {0}, error- -> {1}", udfs.Name, excep.Message);
                                }
                                Console.WriteLine("   " + udfs.Name);
                                _logger.Info("Encrypting UDF  =>{0}", udfs.Name);
                            }
                        }
                    }

                    Microsoft.SqlServer.Management.Smo.View viewobj = null;


                    for (int i = 0; i < db.Views.Count; i++)
                    {
                        viewobj = db.Views[i];
                        if (!viewobj.IsSystemObject)
                        {
                            if (!viewobj.IsEncrypted)
                            {
                                if (_excludeList != null)
                                {
                                    var excludeView = _excludeList.Views.FirstOrDefault(x => x.ViewName.ToLower() == viewobj.Name.ToLower() && x.DBName.ToLower() == db.Name.ToLower());
                                    if (excludeView != null)
                                    {
                                        _logger.Info("Skipping encryption for view: {0} in database: {1}", viewobj.Name, db.Name);
                                        continue;
                                    }
                                    if(_excludeList.ExcludedSchemas.Contains(viewobj.Schema.ToLower()))
                                    {
                                        _logger.Info("Skipping encryption for view: {0} in database: {1} due to excluded schema", viewobj.Name, db.Name);
                                        continue;
                                    }
                                }
                                viewobj.TextMode = false;
                                viewobj.IsEncrypted = true;
                                viewobj.TextMode = true;
                                try
                                {
                                    viewobj.Alter();
                                }
                                catch (Exception excep)
                                {
                                    _logger.Info(excep, "Encryption failed for -> {0}, error- -> {1}", viewobj.Name, excep.Message);
                                }
                                Console.WriteLine("   " + viewobj.Name); // display name of the SP.         
                                _logger.Info("Encrypting View  =>{0}", viewobj.Name);
                            }
                        }
                    }

                    MessageBox.Show("Process has completed succssfully. Please refer to the application logs for more information", "Operation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception InnerEx)
                {
                    _logger.Info("Server details are incorrect;"
                       + " please retry with proper details");

                    MessageBox.Show("Error\n" + "Server details are incorrect;"
                       + "\nPlease retry with proper details.\n\n" + InnerEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
