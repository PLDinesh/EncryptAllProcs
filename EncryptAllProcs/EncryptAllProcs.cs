using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptAllProcs
{
    public partial class EncryptAllDBObjectsForm : Form
    {
        public EncryptAllDBObjectsForm()
        {
            InitializeComponent();
        }

        private void EncryptAllDBObjectsForm_Load(object sender, EventArgs e)
        {
            chkWindowsAuth.Checked = false; 
        }
    }
}
