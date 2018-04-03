using System;
using System.Drawing;
using System.Windows.Forms;

namespace JobHelper
{
    partial class JobRunner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        

        private Button executeButton;

        private TextBox LogTextBox;

        private ComboBox switchesCombo;

        private Label CommandLabel;

        private TextBox parameters;

        private Label label1;

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
            this.executeButton = new Button();
            this.LogTextBox = new TextBox();
            this.switchesCombo = new ComboBox();
            this.CommandLabel = new Label();
            this.parameters = new TextBox();
            this.label1 = new Label();
            base.SuspendLayout();
            this.executeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.executeButton.Location = new Point(494, 37);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new Size(75, 23);
            this.executeButton.TabIndex = 0;
            this.executeButton.Text = "&Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new EventHandler(this.executeButton_Click);
            this.LogTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.LogTextBox.Location = new Point(12, 64);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = ScrollBars.Vertical;
            this.LogTextBox.Size = new Size(557, 231);
            this.LogTextBox.TabIndex = 2;
            this.switchesCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.switchesCombo.FormattingEnabled = true;
            this.switchesCombo.Location = new Point(12, 37);
            this.switchesCombo.Name = "switchesCombo";
            this.switchesCombo.Size = new Size(213, 21);
            this.switchesCombo.TabIndex = 3;
            this.CommandLabel.AutoSize = true;
            this.CommandLabel.Location = new Point(12, 18);
            this.CommandLabel.Name = "CommandLabel";
            this.CommandLabel.Size = new Size(54, 13);
            this.CommandLabel.TabIndex = 4;
            this.CommandLabel.Text = "Command";
            this.parameters.Location = new Point(231, 38);
            this.parameters.Name = "parameters";
            this.parameters.Size = new Size(245, 20);
            this.parameters.TabIndex = 5;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(231, 22);
            this.label1.Name = "label1";
            this.label1.Size = new Size(108, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Additional parameters";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(581, 307);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.parameters);
            base.Controls.Add(this.CommandLabel);
            base.Controls.Add(this.switchesCombo);
            base.Controls.Add(this.LogTextBox);
            base.Controls.Add(this.executeButton);
            base.Name = "JobRunner";
            this.Text = "Job Runner";
            base.Load += new EventHandler(this.JobRunner_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}