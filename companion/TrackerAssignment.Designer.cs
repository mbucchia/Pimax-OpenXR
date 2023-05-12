
namespace companion
{
    partial class TrackerAssignment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrackerAssignment));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.available = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.refresh = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.roles = new System.Windows.Forms.ComboBox();
            this.assigned = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.available, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.assigned, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(390, 279);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // available
            // 
            this.available.Dock = System.Windows.Forms.DockStyle.Fill;
            this.available.FormattingEnabled = true;
            this.available.Location = new System.Drawing.Point(3, 3);
            this.available.Name = "available";
            this.available.Size = new System.Drawing.Size(384, 91);
            this.available.TabIndex = 0;
            this.available.SelectedIndexChanged += new System.EventHandler(this.available_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.refresh);
            this.flowLayoutPanel1.Controls.Add(this.add);
            this.flowLayoutPanel1.Controls.Add(this.remove);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.roles);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 100);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(384, 78);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(3, 3);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(115, 23);
            this.refresh.TabIndex = 0;
            this.refresh.Text = "Detect Trackers";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(124, 3);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(115, 23);
            this.add.TabIndex = 1;
            this.add.Text = "Add with role";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // remove
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.remove, true);
            this.remove.Location = new System.Drawing.Point(245, 3);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(115, 23);
            this.remove.TabIndex = 2;
            this.remove.Text = "Remove";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label1.Size = new System.Drawing.Size(32, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Role:";
            // 
            // roles
            // 
            this.roles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flowLayoutPanel1.SetFlowBreak(this.roles, true);
            this.roles.FormattingEnabled = true;
            this.roles.Location = new System.Drawing.Point(41, 32);
            this.roles.Name = "roles";
            this.roles.Size = new System.Drawing.Size(121, 21);
            this.roles.TabIndex = 4;
            // 
            // assigned
            // 
            this.assigned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assigned.FormattingEnabled = true;
            this.assigned.Location = new System.Drawing.Point(3, 184);
            this.assigned.Name = "assigned";
            this.assigned.Size = new System.Drawing.Size(384, 92);
            this.assigned.TabIndex = 2;
            this.assigned.SelectedIndexChanged += new System.EventHandler(this.assigned_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label2.Size = new System.Drawing.Size(240, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "*Changes require restarting the game/application.";
            // 
            // TrackerAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 279);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrackerAssignment";
            this.Text = "PimaxXR - Trackers Assignment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrackerAssignment_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox available;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox roles;
        private System.Windows.Forms.ListBox assigned;
        private System.Windows.Forms.Label label2;
    }
}