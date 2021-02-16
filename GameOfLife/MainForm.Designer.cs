
namespace GameOfLife
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
            this.populationPanel = new GameOfLife.MultiCellControl();
            this.populationGroup = new System.Windows.Forms.GroupBox();
            this.controlGroup = new System.Windows.Forms.GroupBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.intervalBar = new System.Windows.Forms.TrackBar();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.statusGroup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.aliveCountBox = new System.Windows.Forms.TextBox();
            this.generationCountBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.populationGroup.SuspendLayout();
            this.controlGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalBar)).BeginInit();
            this.statusGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // populationPanel
            // 
            this.populationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.populationPanel.Location = new System.Drawing.Point(3, 27);
            this.populationPanel.Name = "populationPanel";
            this.populationPanel.Size = new System.Drawing.Size(1148, 1047);
            this.populationPanel.TabIndex = 0;
            this.populationPanel.UserChangedState += new System.EventHandler(this.populationPanel_UserChangedState);
            // 
            // populationGroup
            // 
            this.populationGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.populationGroup.BackColor = System.Drawing.SystemColors.Control;
            this.populationGroup.Controls.Add(this.populationPanel);
            this.populationGroup.Location = new System.Drawing.Point(12, 12);
            this.populationGroup.Name = "populationGroup";
            this.populationGroup.Size = new System.Drawing.Size(1154, 1077);
            this.populationGroup.TabIndex = 1;
            this.populationGroup.TabStop = false;
            this.populationGroup.Text = "Population";
            // 
            // controlGroup
            // 
            this.controlGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlGroup.Controls.Add(this.resetButton);
            this.controlGroup.Controls.Add(this.intervalLabel);
            this.controlGroup.Controls.Add(this.label3);
            this.controlGroup.Controls.Add(this.intervalBar);
            this.controlGroup.Controls.Add(this.stopButton);
            this.controlGroup.Controls.Add(this.startButton);
            this.controlGroup.Location = new System.Drawing.Point(12, 1095);
            this.controlGroup.Name = "controlGroup";
            this.controlGroup.Size = new System.Drawing.Size(908, 172);
            this.controlGroup.TabIndex = 2;
            this.controlGroup.TabStop = false;
            this.controlGroup.Text = "Controls";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(6, 122);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(109, 44);
            this.resetButton.TabIndex = 4;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(248, 19);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(56, 25);
            this.intervalLabel.TabIndex = 3;
            this.intervalLabel.Text = " 0 ms";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Interval:";
            // 
            // intervalBar
            // 
            this.intervalBar.LargeChange = 100;
            this.intervalBar.Location = new System.Drawing.Point(168, 47);
            this.intervalBar.Maximum = 500;
            this.intervalBar.Minimum = 50;
            this.intervalBar.Name = "intervalBar";
            this.intervalBar.Size = new System.Drawing.Size(226, 69);
            this.intervalBar.SmallChange = 50;
            this.intervalBar.TabIndex = 0;
            this.intervalBar.TickFrequency = 50;
            this.intervalBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.intervalBar.Value = 50;
            this.intervalBar.Scroll += new System.EventHandler(this.intervalBar_Scroll);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(168, 122);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(109, 44);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(283, 122);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(111, 44);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // statusGroup
            // 
            this.statusGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statusGroup.Controls.Add(this.label2);
            this.statusGroup.Controls.Add(this.aliveCountBox);
            this.statusGroup.Controls.Add(this.generationCountBox);
            this.statusGroup.Controls.Add(this.label1);
            this.statusGroup.Location = new System.Drawing.Point(926, 1095);
            this.statusGroup.Name = "statusGroup";
            this.statusGroup.Size = new System.Drawing.Size(240, 172);
            this.statusGroup.TabIndex = 3;
            this.statusGroup.TabStop = false;
            this.statusGroup.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Alive:";
            // 
            // aliveCountBox
            // 
            this.aliveCountBox.Location = new System.Drawing.Point(114, 67);
            this.aliveCountBox.Name = "aliveCountBox";
            this.aliveCountBox.ReadOnly = true;
            this.aliveCountBox.Size = new System.Drawing.Size(120, 31);
            this.aliveCountBox.TabIndex = 4;
            // 
            // generationCountBox
            // 
            this.generationCountBox.Location = new System.Drawing.Point(114, 30);
            this.generationCountBox.Name = "generationCountBox";
            this.generationCountBox.ReadOnly = true;
            this.generationCountBox.Size = new System.Drawing.Size(120, 31);
            this.generationCountBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Generation:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 1279);
            this.Controls.Add(this.statusGroup);
            this.Controls.Add(this.controlGroup);
            this.Controls.Add(this.populationGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.populationGroup.ResumeLayout(false);
            this.controlGroup.ResumeLayout(false);
            this.controlGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalBar)).EndInit();
            this.statusGroup.ResumeLayout(false);
            this.statusGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MultiCellControl populationPanel;
        private System.Windows.Forms.GroupBox populationGroup;
        private System.Windows.Forms.GroupBox controlGroup;
        private System.Windows.Forms.GroupBox statusGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox aliveCountBox;
        private System.Windows.Forms.TextBox generationCountBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TrackBar intervalBar;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button resetButton;
    }
}

