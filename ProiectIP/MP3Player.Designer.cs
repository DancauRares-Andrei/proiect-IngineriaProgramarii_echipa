
namespace ProiectIP
{
    partial class MP3Player
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MP3Player));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.operatiiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deschidereFisierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deschiderePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iesireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip.BackgroundImage")));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operatiiToolStripMenuItem,
            this.radioToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip.Size = new System.Drawing.Size(853, 30);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // operatiiToolStripMenuItem
            // 
            this.operatiiToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("operatiiToolStripMenuItem.BackgroundImage")));
            this.operatiiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deschidereFisierToolStripMenuItem,
            this.crearePlaylistToolStripMenuItem,
            this.deschiderePlaylistToolStripMenuItem,
            this.editarePlaylistToolStripMenuItem,
            this.ajutorToolStripMenuItem,
            this.iesireToolStripMenuItem});
            this.operatiiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("operatiiToolStripMenuItem.Image")));
            this.operatiiToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.operatiiToolStripMenuItem.Name = "operatiiToolStripMenuItem";
            this.operatiiToolStripMenuItem.Size = new System.Drawing.Size(36, 28);
            // 
            // deschidereFisierToolStripMenuItem
            // 
            this.deschidereFisierToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.deschidereFisierToolStripMenuItem.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deschidereFisierToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.deschidereFisierToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deschidereFisierToolStripMenuItem.Image")));
            this.deschidereFisierToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deschidereFisierToolStripMenuItem.Name = "deschidereFisierToolStripMenuItem";
            this.deschidereFisierToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.deschidereFisierToolStripMenuItem.Size = new System.Drawing.Size(194, 30);
            this.deschidereFisierToolStripMenuItem.Text = "Deschide fișier";
            this.deschidereFisierToolStripMenuItem.Click += new System.EventHandler(this.deschidereFisierToolStripMenuItem_Click);
            // 
            // crearePlaylistToolStripMenuItem
            // 
            this.crearePlaylistToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.crearePlaylistToolStripMenuItem.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crearePlaylistToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.crearePlaylistToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("crearePlaylistToolStripMenuItem.Image")));
            this.crearePlaylistToolStripMenuItem.Name = "crearePlaylistToolStripMenuItem";
            this.crearePlaylistToolStripMenuItem.Size = new System.Drawing.Size(194, 30);
            this.crearePlaylistToolStripMenuItem.Text = "Crează playlist";
            this.crearePlaylistToolStripMenuItem.Click += new System.EventHandler(this.crearePlaylistToolStripMenuItem_Click);
            // 
            // deschiderePlaylistToolStripMenuItem
            // 
            this.deschiderePlaylistToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.deschiderePlaylistToolStripMenuItem.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deschiderePlaylistToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.deschiderePlaylistToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deschiderePlaylistToolStripMenuItem.Image")));
            this.deschiderePlaylistToolStripMenuItem.Name = "deschiderePlaylistToolStripMenuItem";
            this.deschiderePlaylistToolStripMenuItem.Size = new System.Drawing.Size(194, 30);
            this.deschiderePlaylistToolStripMenuItem.Text = "Deschide playlist";
            this.deschiderePlaylistToolStripMenuItem.Click += new System.EventHandler(this.deschiderePlaylistToolStripMenuItem_Click);
            // 
            // editarePlaylistToolStripMenuItem
            // 
            this.editarePlaylistToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.editarePlaylistToolStripMenuItem.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editarePlaylistToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.editarePlaylistToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editarePlaylistToolStripMenuItem.Image")));
            this.editarePlaylistToolStripMenuItem.Name = "editarePlaylistToolStripMenuItem";
            this.editarePlaylistToolStripMenuItem.Size = new System.Drawing.Size(194, 30);
            this.editarePlaylistToolStripMenuItem.Text = "Editează playlist";
            this.editarePlaylistToolStripMenuItem.Click += new System.EventHandler(this.editarePlaylistToolStripMenuItem_Click);
            // 
            // ajutorToolStripMenuItem
            // 
            this.ajutorToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ajutorToolStripMenuItem.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.ajutorToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.ajutorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ajutorToolStripMenuItem.Image")));
            this.ajutorToolStripMenuItem.Name = "ajutorToolStripMenuItem";
            this.ajutorToolStripMenuItem.Size = new System.Drawing.Size(194, 30);
            this.ajutorToolStripMenuItem.Text = "Ajutor";
            this.ajutorToolStripMenuItem.Click += new System.EventHandler(this.ajutorToolStripMenuItem_Click);
            // 
            // iesireToolStripMenuItem
            // 
            this.iesireToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.iesireToolStripMenuItem.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iesireToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.iesireToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("iesireToolStripMenuItem.Image")));
            this.iesireToolStripMenuItem.Name = "iesireToolStripMenuItem";
            this.iesireToolStripMenuItem.Size = new System.Drawing.Size(194, 30);
            this.iesireToolStripMenuItem.Text = "Ieșire";
            this.iesireToolStripMenuItem.Click += new System.EventHandler(this.iesireToolStripMenuItem_Click);
            // 
            // radioToolStripMenuItem
            // 
            this.radioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("radioToolStripMenuItem.Image")));
            this.radioToolStripMenuItem.Name = "radioToolStripMenuItem";
            this.radioToolStripMenuItem.Size = new System.Drawing.Size(36, 28);
            this.radioToolStripMenuItem.Click += new System.EventHandler(this.radioToolStripMenuItem_Click);
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.Color.Navy;
            this.groupBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox.BackgroundImage")));
            this.groupBox.Location = new System.Drawing.Point(13, 35);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(828, 419);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MP3Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(853, 466);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.menuStrip);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MP3Player";
            this.Text = "RhythmIt";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem operatiiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deschidereFisierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deschiderePlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iesireToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem crearePlaylistToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem radioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarePlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajutorToolStripMenuItem;
    }
}

