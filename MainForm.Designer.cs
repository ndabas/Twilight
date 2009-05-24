namespace Twilight
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.appsTreeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.checkAllLinkLabel = new System.Windows.Forms.LinkLabel();
            this.uncheckAllLinkLabel = new System.Windows.Forms.LinkLabel();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // appsTreeView
            // 
            this.appsTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.appsTreeView.CheckBoxes = true;
            this.appsTreeView.Location = new System.Drawing.Point(12, 25);
            this.appsTreeView.Name = "appsTreeView";
            this.appsTreeView.Size = new System.Drawing.Size(460, 312);
            this.appsTreeView.TabIndex = 0;
            this.appsTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.appsTreeView_AfterCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the applications to close:";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(12, 343);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(211, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close Selected Apps";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // checkAllLinkLabel
            // 
            this.checkAllLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAllLinkLabel.AutoSize = true;
            this.checkAllLinkLabel.Location = new System.Drawing.Point(355, 348);
            this.checkAllLinkLabel.Name = "checkAllLinkLabel";
            this.checkAllLinkLabel.Size = new System.Drawing.Size(50, 13);
            this.checkAllLinkLabel.TabIndex = 3;
            this.checkAllLinkLabel.TabStop = true;
            this.checkAllLinkLabel.Text = "Check All";
            this.checkAllLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.checkAllLinkLabel_LinkClicked);
            // 
            // uncheckAllLinkLabel
            // 
            this.uncheckAllLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uncheckAllLinkLabel.AutoSize = true;
            this.uncheckAllLinkLabel.Location = new System.Drawing.Point(411, 348);
            this.uncheckAllLinkLabel.Name = "uncheckAllLinkLabel";
            this.uncheckAllLinkLabel.Size = new System.Drawing.Size(61, 13);
            this.uncheckAllLinkLabel.TabIndex = 4;
            this.uncheckAllLinkLabel.TabStop = true;
            this.uncheckAllLinkLabel.Text = "Uncheck All";
            this.uncheckAllLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.uncheckAllLinkLabel_LinkClicked);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 200;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 378);
            this.Controls.Add(this.uncheckAllLinkLabel);
            this.Controls.Add(this.checkAllLinkLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.appsTreeView);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Twilight";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView appsTreeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.LinkLabel checkAllLinkLabel;
        private System.Windows.Forms.LinkLabel uncheckAllLinkLabel;
        private System.Windows.Forms.Timer refreshTimer;
    }
}