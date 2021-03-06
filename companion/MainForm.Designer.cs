
namespace companion
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.openLogs = new System.Windows.Forms.Button();
            this.startTrace = new System.Windows.Forms.Button();
            this.stopTrace = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.runtimePimax = new System.Windows.Forms.RadioButton();
            this.runtimeSteam = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.gotoDownloads = new System.Windows.Forms.LinkLabel();
            this.reportIssues = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.versionString = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.recenterMode = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.enableTelemetry = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.60465F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.39535F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(609, 378);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.openLogs);
            this.flowLayoutPanel1.Controls.Add(this.startTrace);
            this.flowLayoutPanel1.Controls.Add(this.stopTrace);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 263);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(603, 80);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // openLogs
            // 
            this.openLogs.Location = new System.Drawing.Point(3, 3);
            this.openLogs.Name = "openLogs";
            this.openLogs.Size = new System.Drawing.Size(195, 65);
            this.openLogs.TabIndex = 7;
            this.openLogs.Text = "Open logs";
            this.openLogs.UseVisualStyleBackColor = true;
            this.openLogs.Click += new System.EventHandler(this.openLogs_Click);
            // 
            // startTrace
            // 
            this.startTrace.Location = new System.Drawing.Point(204, 3);
            this.startTrace.Name = "startTrace";
            this.startTrace.Size = new System.Drawing.Size(195, 65);
            this.startTrace.TabIndex = 8;
            this.startTrace.Text = "Capture trace";
            this.startTrace.UseVisualStyleBackColor = true;
            this.startTrace.Click += new System.EventHandler(this.startTrace_Click);
            // 
            // stopTrace
            // 
            this.stopTrace.Enabled = false;
            this.stopTrace.Location = new System.Drawing.Point(405, 3);
            this.stopTrace.Name = "stopTrace";
            this.stopTrace.Size = new System.Drawing.Size(195, 65);
            this.stopTrace.TabIndex = 9;
            this.stopTrace.Text = "Stop capture";
            this.stopTrace.UseVisualStyleBackColor = true;
            this.stopTrace.Click += new System.EventHandler(this.stopTrace_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label1);
            this.flowLayoutPanel3.Controls.Add(this.runtimePimax);
            this.flowLayoutPanel3.Controls.Add(this.runtimeSteam);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(603, 42);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(226, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select active OpenXR runtime:";
            // 
            // runtimePimax
            // 
            this.runtimePimax.AutoSize = true;
            this.runtimePimax.Location = new System.Drawing.Point(235, 3);
            this.runtimePimax.Name = "runtimePimax";
            this.runtimePimax.Size = new System.Drawing.Size(99, 24);
            this.runtimePimax.TabIndex = 1;
            this.runtimePimax.TabStop = true;
            this.runtimePimax.Text = "PimaxXR";
            this.runtimePimax.UseVisualStyleBackColor = true;
            this.runtimePimax.CheckedChanged += new System.EventHandler(this.runtimePimax_CheckedChanged);
            // 
            // runtimeSteam
            // 
            this.runtimeSteam.AutoSize = true;
            this.runtimeSteam.Location = new System.Drawing.Point(340, 3);
            this.runtimeSteam.Name = "runtimeSteam";
            this.runtimeSteam.Size = new System.Drawing.Size(104, 24);
            this.runtimeSteam.TabIndex = 2;
            this.runtimeSteam.TabStop = true;
            this.runtimeSteam.Text = "SteamVR";
            this.runtimeSteam.UseVisualStyleBackColor = true;
            this.runtimeSteam.CheckedChanged += new System.EventHandler(this.runtimeSteam_CheckedChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.gotoDownloads);
            this.flowLayoutPanel2.Controls.Add(this.reportIssues);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 349);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(603, 26);
            this.flowLayoutPanel2.TabIndex = 10;
            // 
            // gotoDownloads
            // 
            this.gotoDownloads.AutoSize = true;
            this.gotoDownloads.Location = new System.Drawing.Point(3, 0);
            this.gotoDownloads.Name = "gotoDownloads";
            this.gotoDownloads.Size = new System.Drawing.Size(129, 20);
            this.gotoDownloads.TabIndex = 10;
            this.gotoDownloads.TabStop = true;
            this.gotoDownloads.Text = "Go to downloads";
            this.gotoDownloads.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gotoDownloads_LinkClicked);
            // 
            // reportIssues
            // 
            this.reportIssues.AutoSize = true;
            this.reportIssues.Location = new System.Drawing.Point(138, 0);
            this.reportIssues.Name = "reportIssues";
            this.reportIssues.Size = new System.Drawing.Size(107, 20);
            this.reportIssues.TabIndex = 11;
            this.reportIssues.TabStop = true;
            this.reportIssues.Text = "Report issues";
            this.reportIssues.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.reportIssues_LinkClicked);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label2);
            this.flowLayoutPanel4.Controls.Add(this.versionString);
            this.flowLayoutPanel4.Controls.Add(this.label3);
            this.flowLayoutPanel4.Controls.Add(this.recenterMode);
            this.flowLayoutPanel4.Controls.Add(this.label4);
            this.flowLayoutPanel4.Controls.Add(this.enableTelemetry);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 51);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(603, 206);
            this.flowLayoutPanel4.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "PimaxXR version:";
            // 
            // versionString
            // 
            this.versionString.AutoSize = true;
            this.flowLayoutPanel4.SetFlowBreak(this.versionString, true);
            this.versionString.Location = new System.Drawing.Point(141, 0);
            this.versionString.Name = "versionString";
            this.versionString.Size = new System.Drawing.Size(76, 20);
            this.versionString.TabIndex = 4;
            this.versionString.Text = "Unknown";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.flowLayoutPanel4.SetFlowBreak(this.label3, true);
            this.label3.Location = new System.Drawing.Point(4, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(4, 15, 0, 0);
            this.label3.Size = new System.Drawing.Size(584, 55);
            this.label3.TabIndex = 5;
            this.label3.Text = "Use PiTool to set refresh rate, resolution, FOV, enable Smart Smoothing, Parallel" +
    " Projection, etc...";
            // 
            // recenterMode
            // 
            this.recenterMode.AutoSize = true;
            this.flowLayoutPanel4.SetFlowBreak(this.recenterMode, true);
            this.recenterMode.Location = new System.Drawing.Point(3, 78);
            this.recenterMode.Name = "recenterMode";
            this.recenterMode.Padding = new System.Windows.Forms.Padding(4, 5, 0, 0);
            this.recenterMode.Size = new System.Drawing.Size(243, 29);
            this.recenterMode.TabIndex = 6;
            this.recenterMode.Text = "Recenter headset on startup";
            this.recenterMode.UseVisualStyleBackColor = true;
            this.recenterMode.CheckedChanged += new System.EventHandler(this.recenterMode_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.flowLayoutPanel4.SetFlowBreak(this.label4, true);
            this.label4.Location = new System.Drawing.Point(4, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(4, 10, 0, 0);
            this.label4.Size = new System.Drawing.Size(595, 50);
            this.label4.TabIndex = 7;
            this.label4.Text = "Our telemetry does not affect performance, is anonymous and helps the developer w" +
    "ith application support.";
            // 
            // enableTelemetry
            // 
            this.enableTelemetry.AutoSize = true;
            this.flowLayoutPanel4.SetFlowBreak(this.enableTelemetry, true);
            this.enableTelemetry.Location = new System.Drawing.Point(3, 163);
            this.enableTelemetry.Name = "enableTelemetry";
            this.enableTelemetry.Padding = new System.Windows.Forms.Padding(4, 5, 0, 0);
            this.enableTelemetry.Size = new System.Drawing.Size(206, 29);
            this.enableTelemetry.TabIndex = 8;
            this.enableTelemetry.Text = "Enable usage telemetry";
            this.enableTelemetry.UseVisualStyleBackColor = true;
            this.enableTelemetry.CheckedChanged += new System.EventHandler(this.enableTelemetry_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 378);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PimaxXR - OpenXR Control Center";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button openLogs;
        private System.Windows.Forms.Button startTrace;
        private System.Windows.Forms.Button stopTrace;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton runtimePimax;
        private System.Windows.Forms.RadioButton runtimeSteam;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.LinkLabel gotoDownloads;
        private System.Windows.Forms.LinkLabel reportIssues;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label versionString;
        private System.Windows.Forms.CheckBox recenterMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox enableTelemetry;
    }
}

