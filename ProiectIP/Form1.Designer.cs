
namespace ProiectIP
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.operatiiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deschidereFisierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deschiderePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iesireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.crearePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operatiiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(834, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // operatiiToolStripMenuItem
            // 
            this.operatiiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deschidereFisierToolStripMenuItem,
            this.deschiderePlaylistToolStripMenuItem,
            this.crearePlaylistToolStripMenuItem,
            this.iesireToolStripMenuItem});
            this.operatiiToolStripMenuItem.Name = "operatiiToolStripMenuItem";
            this.operatiiToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.operatiiToolStripMenuItem.Text = "Operatii";
            // 
            // deschidereFisierToolStripMenuItem
            // 
            this.deschidereFisierToolStripMenuItem.Name = "deschidereFisierToolStripMenuItem";
            this.deschidereFisierToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deschidereFisierToolStripMenuItem.Text = "Deschidere fisier";
            this.deschidereFisierToolStripMenuItem.Click += new System.EventHandler(this.deschidereFisierToolStripMenuItem_Click);
            // 
            // deschiderePlaylistToolStripMenuItem
            // 
            this.deschiderePlaylistToolStripMenuItem.Name = "deschiderePlaylistToolStripMenuItem";
            this.deschiderePlaylistToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deschiderePlaylistToolStripMenuItem.Text = "Deschidere playlist";
            this.deschiderePlaylistToolStripMenuItem.Click += new System.EventHandler(this.deschiderePlaylistToolStripMenuItem_Click);
            // 
            // iesireToolStripMenuItem
            // 
            this.iesireToolStripMenuItem.Name = "iesireToolStripMenuItem";
            this.iesireToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.iesireToolStripMenuItem.Text = "Iesire";
            this.iesireToolStripMenuItem.Click += new System.EventHandler(this.iesireToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(809, 410);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // crearePlaylistToolStripMenuItem
            // 
            this.crearePlaylistToolStripMenuItem.Name = "crearePlaylistToolStripMenuItem";
            this.crearePlaylistToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.crearePlaylistToolStripMenuItem.Text = "Creare playlist";
            this.crearePlaylistToolStripMenuItem.Click += new System.EventHandler(this.crearePlaylistToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "MP3 Player";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem operatiiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deschidereFisierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deschiderePlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iesireToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem crearePlaylistToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

