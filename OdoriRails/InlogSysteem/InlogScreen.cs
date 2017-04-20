using System;
using System.Windows.Forms;

namespace LoginSystem
{
    public partial class LoginScreen : Form
    {
        private readonly LogInSystemCode _loginSystem = new LogInSystemCode();

        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                _loginSystem.Login(tbUsername.Text, tbPassword.Text);
            }
            catch (Exception ex)
            {
                tbPassword.Text = "";
                lbError.Text = ex.Message;
            }
        }

        private void InlogScreen_Load(object sender, EventArgs e)
        {
            lbError.Text = "";
        }
    }
}
