using Mart_Management_System.Enums;
using Mart_Management_System.Models;
using Mart_Management_System.Repositories;

namespace Mart_Management_System.Forms
{
    public partial class UserManagementForm : Form
    {
        private readonly UserRepository _userRepository;
        private readonly User _currentAdministrator;

        public UserManagementForm()
            : this(new User
            {
                FullName = "Designer",
                Username = "designer",
                Role = UserRole.Admin,
                IsActive = true
            })
        {
        }

        public UserManagementForm(User currentAdministrator)
        {
            ArgumentNullException.ThrowIfNull(currentAdministrator);
            _currentAdministrator = currentAdministrator;
            _userRepository = new UserRepository();

            InitializeComponent();

            if (!IsAdministrator)
            {
                btnAddUser.Enabled = false;
                dgvUsers.Enabled = false;
                txtSearch.Enabled = false;
                cbRoleFilter.Enabled = false;
            }
        }

        private bool IsAdministrator => _currentAdministrator.Role == UserRole.Admin;

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            if (IsAdministrator)
            {
                LoadUsers();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!EnsureAdministrator())
            {
                return;
            }

            using UserEditForm form = new(_currentAdministrator, null);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (IsAdministrator)
            {
                LoadUsers();
            }
        }

        private void cbRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsAdministrator)
            {
                LoadUsers();
            }
        }

        private void dgvUsers_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (!IsAdministrator || e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
            if (row.Tag is not User user)
            {
                return;
            }

            if (e.ColumnIndex == colEdit.Index)
            {
                using UserEditForm form = new(_currentAdministrator, user);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadUsers();
                }
            }
            else if (e.ColumnIndex == colDelete.Index)
            {
                ToggleUser(user);
            }
        }

        private void LoadUsers()
        {
            try
            {
                string search = txtSearch.Text.Trim();
                string roleFilter = cbRoleFilter.SelectedItem?.ToString()
                    ?? "All Roles";

                IEnumerable<User> users = _userRepository.GetAll();
                if (!string.IsNullOrWhiteSpace(search))
                {
                    users = users.Where(user =>
                        user.FullName.Contains(search, StringComparison.OrdinalIgnoreCase)
                        || user.Username.Contains(
                            search,
                            StringComparison.OrdinalIgnoreCase
                        )
                    );
                }

                if (roleFilter != "All Roles"
                    && Enum.TryParse<UserRole>(roleFilter, out UserRole selectedRole))
                {
                    users = users.Where(user => user.Role == selectedRole);
                }

                dgvUsers.Rows.Clear();
                foreach (User user in users.OrderBy(user => user.Username))
                {
                    int rowIndex = dgvUsers.Rows.Add(
                        user.UserId,
                        user.FullName,
                        user.Username,
                        user.Role.ToString(),
                        user.IsActive ? "Active" : "Inactive",
                        "Edit",
                        user.IsActive ? "Deactivate" : "Activate"
                    );
                    dgvUsers.Rows[rowIndex].Tag = user;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to load users. Please try again.",
                    "User Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ToggleUser(User user)
        {
            if (user.UserId == _currentAdministrator.UserId && user.IsActive)
            {
                MessageBox.Show(
                    "You cannot deactivate your own account.",
                    "User Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (user.Role == UserRole.Admin && user.IsActive)
            {
                int activeAdminCount = _userRepository.GetAll().Count(
                    candidate => candidate.Role == UserRole.Admin && candidate.IsActive
                );
                if (activeAdminCount <= 1)
                {
                    MessageBox.Show(
                        "At least one active administrator is required.",
                        "User Management",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            string action = user.IsActive ? "deactivate" : "activate";
            DialogResult confirmation = MessageBox.Show(
                $"Are you sure you want to {action} '{user.Username}'?",
                "Confirm User Status",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (_userRepository.SetActive(user.UserId, !user.IsActive))
                {
                    LoadUsers();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to change the user status. Please try again.",
                    "User Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private bool EnsureAdministrator()
        {
            if (IsAdministrator)
            {
                return true;
            }

            MessageBox.Show(
                "Only administrators can manage user accounts.",
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            return false;
        }
    }
}
