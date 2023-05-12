using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace companion
{
    public partial class TrackerAssignment : Form
    {
        private readonly string[] Roles = new string[] { "Handheld Object", "Left foot", "Right foot", "Left shoulder", "Right shoulder", "Left elbow", "Right elbow", "Left knee", "Right knee", "Waist", "Chest", "Camera", "Keyboard" };

        public TrackerAssignment()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void TrackerAssignment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public void LoadSettings()
        {
            SuspendLayout();

            available.Items.Clear();
            assigned.Items.Clear();

            Microsoft.Win32.RegistryKey key = null;

            // Read the PimaxXR configuration.
            try
            {
                key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(MainForm.RegPrefix);

                foreach (string role in Roles) {
                    AddTracker(role, (string)key.GetValue(GetRoleKey(role), ""));
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Failed to write to registry. Please make sure the app is running elevated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                }
            }

            RefreshAvailableRoles();

            available_SelectedIndexChanged(null, null);
            assigned_SelectedIndexChanged(null, null);

            ResumeLayout();
        }

        private void AddTracker(string role, string serial)
        {
            if (serial != "")
            {
                assigned.Items.Add(serial + " - " + role);
            }
        }

        private string GetRoleKey(string role)
        {
            return "tracker_" + role.ToLower().Replace(' ', '_');
        }

        private void RefreshAvailableRoles()
        {
            SuspendLayout();

            roles.Items.Clear();
            foreach (string role in Roles)
            {
                bool used = false;
                foreach (string entry in assigned.Items)
                {
                    if (entry.EndsWith(" - " + role))
                    {
                        used = true;
                        break;
                    }
                }

                if (used)
                {
                    continue;
                }

                roles.Items.Add(role);
            }
            roles.SelectedIndex = 0;

            add.Enabled = available.SelectedItem != null && roles.Items.Count > 0;

            ResumeLayout();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            available.Items.Add("abcde");
            available.Items.Add("hijkl");
        }

        private void add_Click(object sender, EventArgs e)
        {
            SuspendLayout();

            var serial = (string)available.SelectedItem;
            var role = (string)roles.SelectedItem;

            Microsoft.Win32.RegistryKey key = null;

            try
            {
                key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(MainForm.RegPrefix);
                key.SetValue(GetRoleKey(role), serial, Microsoft.Win32.RegistryValueKind.String);
            }
            catch (Exception)
            {
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                }
            }

            assigned.Items.Add(serial + " - " + roles.SelectedItem);
            available.Items.RemoveAt(available.SelectedIndex);

            RefreshAvailableRoles();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (assigned.SelectedItem == null)
            {
                return;
            }

            var entry = (string)assigned.SelectedItem;
            var serial = entry.Substring(0, entry.LastIndexOf(" - "));
            var role = entry.Substring(entry.LastIndexOf(" - ") + 3);

            Microsoft.Win32.RegistryKey key = null;

            try
            {
                key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(MainForm.RegPrefix);
                key.DeleteValue(GetRoleKey(role));
            }
            catch (Exception)
            {
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                }
            }

            available.Items.Add(serial);
            assigned.Items.RemoveAt(assigned.SelectedIndex);

            RefreshAvailableRoles();
        }

        private void available_SelectedIndexChanged(object sender, EventArgs e)
        {
            add.Enabled = available.SelectedItem != null && roles.Items.Count > 0;
        }

        private void assigned_SelectedIndexChanged(object sender, EventArgs e)
        {
            remove.Enabled = assigned.SelectedItem != null;
        }
    }
}
