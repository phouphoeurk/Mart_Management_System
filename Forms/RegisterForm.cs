namespace Mart_Management_System.Forms
{
    // Public self-registration is intentionally disabled. User accounts are
    // created from the administrator user-management workflow in Phase 3.
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            Mart_Management_System.UI.UiTheme.Apply(this);

            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            txtConfirmPassword.Enabled = false;
            checkBox1.Enabled = false;
            btnRegister.Enabled = false;
            Text = "User Management";
        }
    }
}
