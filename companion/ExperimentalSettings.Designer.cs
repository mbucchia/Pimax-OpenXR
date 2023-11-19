
namespace companion
{
    partial class ExperimentalSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExperimentalSettings));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.enableFrameTiming = new System.Windows.Forms.CheckBox();
            this.filterLengthValue = new System.Windows.Forms.TextBox();
            this.filterLengthLabel = new System.Windows.Forms.Label();
            this.filterLength = new System.Windows.Forms.TrackBar();
            this.timingBiasValue = new System.Windows.Forms.TextBox();
            this.timingBiasLabel = new System.Windows.Forms.Label();
            this.timingBias = new System.Windows.Forms.TrackBar();
            this.forceRateLabel = new System.Windows.Forms.Label();
            this.forceHalf = new System.Windows.Forms.CheckBox();
            this.forceThird = new System.Windows.Forms.CheckBox();
            this.waitForGpuWorkInEndFrame = new System.Windows.Forms.CheckBox();
            this.forceDisableParallelProjection = new System.Windows.Forms.CheckBox();
            this.droolonProjectionDistanceValue = new System.Windows.Forms.TextBox();
            this.droolonProjectionDistanceLabel = new System.Windows.Forms.Label();
            this.droolonProjectionDistance = new System.Windows.Forms.TrackBar();
            this.noRestartLabel = new System.Windows.Forms.Label();
            this.restoreDefaults = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timingBias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.droolonProjectionDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.enableFrameTiming);
            this.flowLayoutPanel1.Controls.Add(this.filterLengthValue);
            this.flowLayoutPanel1.Controls.Add(this.filterLengthLabel);
            this.flowLayoutPanel1.Controls.Add(this.filterLength);
            this.flowLayoutPanel1.Controls.Add(this.timingBiasValue);
            this.flowLayoutPanel1.Controls.Add(this.timingBiasLabel);
            this.flowLayoutPanel1.Controls.Add(this.timingBias);
            this.flowLayoutPanel1.Controls.Add(this.forceRateLabel);
            this.flowLayoutPanel1.Controls.Add(this.forceHalf);
            this.flowLayoutPanel1.Controls.Add(this.forceThird);
            this.flowLayoutPanel1.Controls.Add(this.waitForGpuWorkInEndFrame);
            this.flowLayoutPanel1.Controls.Add(this.forceDisableParallelProjection);
            this.flowLayoutPanel1.Controls.Add(this.droolonProjectionDistanceValue);
            this.flowLayoutPanel1.Controls.Add(this.droolonProjectionDistanceLabel);
            this.flowLayoutPanel1.Controls.Add(this.droolonProjectionDistance);
            this.flowLayoutPanel1.Controls.Add(this.noRestartLabel);
            this.flowLayoutPanel1.Controls.Add(this.restoreDefaults);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(341, 417);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.label1, true);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "WARNING: These settings are intented for advanced usage by beta testers. You shou" +
    "ld not alter them unless instructed by the developers.";
            // 
            // enableFrameTiming
            // 
            this.enableFrameTiming.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.enableFrameTiming, true);
            this.enableFrameTiming.Location = new System.Drawing.Point(3, 48);
            this.enableFrameTiming.Name = "enableFrameTiming";
            this.enableFrameTiming.Padding = new System.Windows.Forms.Padding(3, 6, 0, 0);
            this.enableFrameTiming.Size = new System.Drawing.Size(210, 23);
            this.enableFrameTiming.TabIndex = 10;
            this.enableFrameTiming.Text = "Enable Smart Smoothing timing control";
            this.enableFrameTiming.UseVisualStyleBackColor = true;
            this.enableFrameTiming.CheckedChanged += new System.EventHandler(this.enableFrameTiming_CheckedChanged);
            // 
            // filterLengthValue
            // 
            this.filterLengthValue.Location = new System.Drawing.Point(6, 80);
            this.filterLengthValue.Margin = new System.Windows.Forms.Padding(6, 6, 3, 3);
            this.filterLengthValue.Name = "filterLengthValue";
            this.filterLengthValue.ReadOnly = true;
            this.filterLengthValue.Size = new System.Drawing.Size(32, 20);
            this.filterLengthValue.TabIndex = 11;
            // 
            // filterLengthLabel
            // 
            this.filterLengthLabel.AutoSize = true;
            this.filterLengthLabel.Location = new System.Drawing.Point(44, 74);
            this.filterLengthLabel.Name = "filterLengthLabel";
            this.filterLengthLabel.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.filterLengthLabel.Size = new System.Drawing.Size(141, 22);
            this.filterLengthLabel.TabIndex = 12;
            this.filterLengthLabel.Text = "Length of smoothing filter (*):";
            // 
            // filterLength
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.filterLength, true);
            this.filterLength.LargeChange = 10;
            this.filterLength.Location = new System.Drawing.Point(191, 77);
            this.filterLength.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.filterLength.Maximum = 600;
            this.filterLength.Minimum = 3;
            this.filterLength.Name = "filterLength";
            this.filterLength.Size = new System.Drawing.Size(104, 45);
            this.filterLength.TabIndex = 13;
            this.filterLength.TickFrequency = 10;
            this.filterLength.Value = 5;
            this.filterLength.Scroll += new System.EventHandler(this.filterLength_Scroll);
            // 
            // timingBiasValue
            // 
            this.timingBiasValue.Location = new System.Drawing.Point(6, 125);
            this.timingBiasValue.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.timingBiasValue.Name = "timingBiasValue";
            this.timingBiasValue.ReadOnly = true;
            this.timingBiasValue.Size = new System.Drawing.Size(32, 20);
            this.timingBiasValue.TabIndex = 14;
            // 
            // timingBiasLabel
            // 
            this.timingBiasLabel.AutoSize = true;
            this.timingBiasLabel.Location = new System.Drawing.Point(44, 122);
            this.timingBiasLabel.Name = "timingBiasLabel";
            this.timingBiasLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.timingBiasLabel.Size = new System.Drawing.Size(123, 19);
            this.timingBiasLabel.TabIndex = 15;
            this.timingBiasLabel.Text = "Frame Time Bias (ms) (*):";
            // 
            // timingBias
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.timingBias, true);
            this.timingBias.Location = new System.Drawing.Point(173, 125);
            this.timingBias.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.timingBias.Maximum = 300;
            this.timingBias.Minimum = -300;
            this.timingBias.Name = "timingBias";
            this.timingBias.Size = new System.Drawing.Size(104, 45);
            this.timingBias.TabIndex = 16;
            this.timingBias.TickFrequency = 10;
            this.timingBias.Scroll += new System.EventHandler(this.timingBias_Scroll);
            // 
            // forceRateLabel
            // 
            this.forceRateLabel.AutoSize = true;
            this.forceRateLabel.Location = new System.Drawing.Point(2, 170);
            this.forceRateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.forceRateLabel.Name = "forceRateLabel";
            this.forceRateLabel.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.forceRateLabel.Size = new System.Drawing.Size(171, 16);
            this.forceRateLabel.TabIndex = 17;
            this.forceRateLabel.Text = "Force fractional smoothing rate (*):";
            // 
            // forceHalf
            // 
            this.forceHalf.AutoSize = true;
            this.forceHalf.Location = new System.Drawing.Point(178, 173);
            this.forceHalf.Name = "forceHalf";
            this.forceHalf.Size = new System.Drawing.Size(43, 17);
            this.forceHalf.TabIndex = 18;
            this.forceHalf.Text = "1/2";
            this.forceHalf.UseVisualStyleBackColor = true;
            this.forceHalf.CheckedChanged += new System.EventHandler(this.forceHalf_CheckedChanged);
            // 
            // forceThird
            // 
            this.forceThird.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.forceThird, true);
            this.forceThird.Location = new System.Drawing.Point(227, 173);
            this.forceThird.Name = "forceThird";
            this.forceThird.Size = new System.Drawing.Size(43, 17);
            this.forceThird.TabIndex = 19;
            this.forceThird.Text = "1/3";
            this.forceThird.UseVisualStyleBackColor = true;
            this.forceThird.CheckedChanged += new System.EventHandler(this.forceThird_CheckedChanged);
            // 
            // waitForGpuWorkInEndFrame
            // 
            this.waitForGpuWorkInEndFrame.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.waitForGpuWorkInEndFrame, true);
            this.waitForGpuWorkInEndFrame.Location = new System.Drawing.Point(3, 196);
            this.waitForGpuWorkInEndFrame.Name = "waitForGpuWorkInEndFrame";
            this.waitForGpuWorkInEndFrame.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.waitForGpuWorkInEndFrame.Size = new System.Drawing.Size(193, 17);
            this.waitForGpuWorkInEndFrame.TabIndex = 30;
            this.waitForGpuWorkInEndFrame.Text = "Wait for GPU work in EndFrame (*)";
            this.waitForGpuWorkInEndFrame.UseVisualStyleBackColor = true;
            this.waitForGpuWorkInEndFrame.CheckedChanged += new System.EventHandler(this.waitForGpuWorkInEndFrame_CheckedChanged);
            // 
            // forceDisableParallelProjection
            // 
            this.forceDisableParallelProjection.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.forceDisableParallelProjection, true);
            this.forceDisableParallelProjection.Location = new System.Drawing.Point(3, 219);
            this.forceDisableParallelProjection.Name = "forceDisableParallelProjection";
            this.forceDisableParallelProjection.Padding = new System.Windows.Forms.Padding(3, 0, 0, 9);
            this.forceDisableParallelProjection.Size = new System.Drawing.Size(185, 26);
            this.forceDisableParallelProjection.TabIndex = 31;
            this.forceDisableParallelProjection.Text = "Force disabling parallel projection";
            this.forceDisableParallelProjection.UseVisualStyleBackColor = true;
            this.forceDisableParallelProjection.CheckedChanged += new System.EventHandler(this.forceDisableParallelProjection_CheckedChanged);
            // 
            // droolonProjectionDistanceValue
            // 
            this.droolonProjectionDistanceValue.Location = new System.Drawing.Point(6, 254);
            this.droolonProjectionDistanceValue.Margin = new System.Windows.Forms.Padding(6, 6, 3, 3);
            this.droolonProjectionDistanceValue.Name = "droolonProjectionDistanceValue";
            this.droolonProjectionDistanceValue.ReadOnly = true;
            this.droolonProjectionDistanceValue.Size = new System.Drawing.Size(32, 20);
            this.droolonProjectionDistanceValue.TabIndex = 40;
            // 
            // droolonProjectionDistanceLabel
            // 
            this.droolonProjectionDistanceLabel.AutoSize = true;
            this.droolonProjectionDistanceLabel.Location = new System.Drawing.Point(44, 248);
            this.droolonProjectionDistanceLabel.Name = "droolonProjectionDistanceLabel";
            this.droolonProjectionDistanceLabel.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.droolonProjectionDistanceLabel.Size = new System.Drawing.Size(169, 22);
            this.droolonProjectionDistanceLabel.TabIndex = 41;
            this.droolonProjectionDistanceLabel.Text = "Droolon projection distance: (m) (*)";
            // 
            // droolonProjectionDistance
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.droolonProjectionDistance, true);
            this.droolonProjectionDistance.LargeChange = 10;
            this.droolonProjectionDistance.Location = new System.Drawing.Point(219, 251);
            this.droolonProjectionDistance.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.droolonProjectionDistance.Maximum = 200;
            this.droolonProjectionDistance.Minimum = 10;
            this.droolonProjectionDistance.Name = "droolonProjectionDistance";
            this.droolonProjectionDistance.Size = new System.Drawing.Size(104, 45);
            this.droolonProjectionDistance.TabIndex = 42;
            this.droolonProjectionDistance.TickFrequency = 10;
            this.droolonProjectionDistance.Value = 10;
            this.droolonProjectionDistance.Scroll += new System.EventHandler(this.droolonProjectionDistance_Scroll);
            // 
            // noRestartLabel
            // 
            this.noRestartLabel.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.noRestartLabel, true);
            this.noRestartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noRestartLabel.Location = new System.Drawing.Point(2, 296);
            this.noRestartLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.noRestartLabel.Name = "noRestartLabel";
            this.noRestartLabel.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.noRestartLabel.Size = new System.Drawing.Size(204, 16);
            this.noRestartLabel.TabIndex = 80;
            this.noRestartLabel.Text = "(*): Settings taking effect without a restart";
            // 
            // restoreDefaults
            // 
            this.restoreDefaults.Location = new System.Drawing.Point(6, 318);
            this.restoreDefaults.Margin = new System.Windows.Forms.Padding(6, 6, 3, 3);
            this.restoreDefaults.Name = "restoreDefaults";
            this.restoreDefaults.Size = new System.Drawing.Size(126, 39);
            this.restoreDefaults.TabIndex = 81;
            this.restoreDefaults.Text = "Restore defaults";
            this.restoreDefaults.UseVisualStyleBackColor = true;
            this.restoreDefaults.Click += new System.EventHandler(this.restoreDefaults_Click);
            // 
            // ExperimentalSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 417);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExperimentalSettings";
            this.Text = "PimaxXR - Experimental Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExperimentalSettings_FormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timingBias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.droolonProjectionDistance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox enableFrameTiming;
        private System.Windows.Forms.Label filterLengthLabel;
        private System.Windows.Forms.TrackBar filterLength;
        private System.Windows.Forms.Label timingBiasLabel;
        private System.Windows.Forms.TrackBar timingBias;
        private System.Windows.Forms.Label forceRateLabel;
        private System.Windows.Forms.TextBox filterLengthValue;
        private System.Windows.Forms.TextBox timingBiasValue;
        private System.Windows.Forms.CheckBox forceHalf;
        private System.Windows.Forms.CheckBox forceThird;
        private System.Windows.Forms.Button restoreDefaults;
        private System.Windows.Forms.CheckBox forceDisableParallelProjection;
        private System.Windows.Forms.Label droolonProjectionDistanceLabel;
        private System.Windows.Forms.TrackBar droolonProjectionDistance;
        private System.Windows.Forms.TextBox droolonProjectionDistanceValue;
        private System.Windows.Forms.Label noRestartLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox waitForGpuWorkInEndFrame;
    }
}