using Mart_Management_System.Models;
using Mart_Management_System.UI;

namespace Mart_Management_System.Forms
{
    public partial class Settings : Form
    {
        private readonly User? _currentUser;

        public Settings()
            : this(null)
        {
        }

        public Settings(User? currentUser)
        {
            _currentUser = currentUser;
            InitializeComponent();
            UiTheme.Apply(this);
            ShowAccountInfo();
            LoadAccountInfo();
        }

        private void btnAccountInfo_Click(object sender, EventArgs e)
        {
            ShowAccountInfo();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            ShowUserManagement();
        }

        private void ShowAccountInfo()
        {
            pnlAccountInfo.Visible = true;
            pnlUserManagement.Visible = false;
        }

        private void ShowUserManagement()
        {
            pnlAccountInfo.Visible = false;
            pnlUserManagement.Visible = true;
        }

        private void LoadAccountInfo()
        {
            if (_currentUser is null)
            {
                lblFullNameValue.Text = "Not signed in";
                lblUsernameValue.Text = "-";
                lblRoleValue.Text = "-";
                lblStatusValue.Text = "-";
                return;
            }

            lblFullNameValue.Text = _currentUser.FullName;
            lblUsernameValue.Text = _currentUser.Username;
            lblRoleValue.Text = _currentUser.Role.ToString();
            lblStatusValue.Text = _currentUser.IsActive ? "Active" : "Inactive";
        }
    }
}
