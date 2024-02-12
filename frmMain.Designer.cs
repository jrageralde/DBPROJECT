
namespace DBPROJECT
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.tsBottom = new System.Windows.Forms.ToolStrip();
            this.btnMinimize = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtUserName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtServer = new System.Windows.Forms.ToolStripTextBox();
            this.tsTop.SuspendLayout();
            this.tsBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsTop
            // 
            this.tsTop.AutoSize = false;
            this.tsTop.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.btnMinimize});
            this.tsTop.Location = new System.Drawing.Point(0, 0);
            this.tsTop.Name = "tsTop";
            this.tsTop.Size = new System.Drawing.Size(800, 50);
            this.tsTop.TabIndex = 0;
            this.tsTop.Text = "toolStrip1";
            // 
            // btnExit
            // 
            this.btnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(36, 50);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tsBottom
            // 
            this.tsBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtUserName,
            this.toolStripLabel2,
            this.txtServer});
            this.tsBottom.Location = new System.Drawing.Point(0, 425);
            this.tsBottom.Name = "tsBottom";
            this.tsBottom.Size = new System.Drawing.Size(800, 25);
            this.tsBottom.TabIndex = 1;
            this.tsBottom.Text = "toolStrip1";
            // 
            // btnMinimize
            // 
            this.btnMinimize.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnMinimize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(5);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Padding = new System.Windows.Forms.Padding(5);
            this.btnMinimize.Size = new System.Drawing.Size(46, 40);
            this.btnMinimize.Text = "toolStripButton1";
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(65, 22);
            this.toolStripLabel1.Text = "User Name";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel2.Text = "Server";
            // 
            // txtServer
            // 
            this.txtServer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtServer.Name = "txtServer";
            this.txtServer.ReadOnly = true;
            this.txtServer.Size = new System.Drawing.Size(100, 25);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.tsBottom);
            this.Controls.Add(this.tsTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tsTop.ResumeLayout(false);
            this.tsTop.PerformLayout();
            this.tsBottom.ResumeLayout(false);
            this.tsBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsTop;
        private System.Windows.Forms.ToolStrip tsBottom;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripButton btnMinimize;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtUserName;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtServer;
    }
}

