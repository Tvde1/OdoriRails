using System;
using System.Windows.Forms;

namespace LoginSystem
{
    public partial class LoginScreen : Form
    {
        private readonly Logic _loginSystem;

        public LoginScreen()
        {
            InitializeComponent();
            _loginSystem = new Logic(this);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                _loginSystem.Login(tbUsername.Text, tbPassword.Text);
                tbUsername.Text = "";
                tbPassword.Text = "";
            }
            catch (Exception ex)
            {
                lbError.Text = ex.Message;
            }
        }

        private void InlogScreen_Load(object sender, EventArgs e)
        {
            lbError.Text = "";
        }
    }
}
