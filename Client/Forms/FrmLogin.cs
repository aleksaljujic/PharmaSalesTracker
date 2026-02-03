using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.GUIControler;
using Client.GUIController;
using Common.Communication;
using Common.Domain;

namespace Client
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginController.Instance.Login(sender, e);
        }

        internal string GetUsername() => tbUsername.Text;
        internal string GetPassword() => tbPassword.Text;

        internal bool Validacija()
        {
            return !string.IsNullOrWhiteSpace(tbUsername.Text) &&
                   !string.IsNullOrWhiteSpace(tbPassword.Text);
        }
    }
}
