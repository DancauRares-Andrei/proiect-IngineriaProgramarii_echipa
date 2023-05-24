﻿
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.operatiiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deschidereFisierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deschiderePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iesireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operatiiToolStripMenuItem,
            this.radioToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1251, 35);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // operatiiToolStripMenuItem
            // 
            this.operatiiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deschidereFisierToolStripMenuItem,
            this.crearePlaylistToolStripMenuItem,
            this.deschiderePlaylistToolStripMenuItem,
            this.editarePlaylistToolStripMenuItem,
            this.iesireToolStripMenuItem});
            this.operatiiToolStripMenuItem.Name = "operatiiToolStripMenuItem";
            this.operatiiToolStripMenuItem.Size = new System.Drawing.Size(77, 29);
            this.operatiiToolStripMenuItem.Text = "Meniu";
            this.operatiiToolStripMenuItem.Click += new System.EventHandler(this.operatiiToolStripMenuItem_Click);
            // 
            // deschidereFisierToolStripMenuItem
            // 
            this.deschidereFisierToolStripMenuItem.Name = "deschidereFisierToolStripMenuItem";
            this.deschidereFisierToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.deschidereFisierToolStripMenuItem.Text = "Deschidere fisier";
            this.deschidereFisierToolStripMenuItem.Click += new System.EventHandler(this.deschidereFisierToolStripMenuItem_Click);
            // 
            // deschiderePlaylistToolStripMenuItem
            // 
            this.deschiderePlaylistToolStripMenuItem.Name = "deschiderePlaylistToolStripMenuItem";
            this.deschiderePlaylistToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.deschiderePlaylistToolStripMenuItem.Text = "Deschidere playlist";
            this.deschiderePlaylistToolStripMenuItem.Click += new System.EventHandler(this.deschiderePlaylistToolStripMenuItem_Click);
            // 
            // crearePlaylistToolStripMenuItem
            // 
            this.crearePlaylistToolStripMenuItem.Name = "crearePlaylistToolStripMenuItem";
            this.crearePlaylistToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.crearePlaylistToolStripMenuItem.Text = "Creare playlist";
            this.crearePlaylistToolStripMenuItem.Click += new System.EventHandler(this.crearePlaylistToolStripMenuItem_Click);
            // 
            // iesireToolStripMenuItem
            // 
            this.iesireToolStripMenuItem.Name = "iesireToolStripMenuItem";
            this.iesireToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.iesireToolStripMenuItem.Text = "Iesire";
            this.iesireToolStripMenuItem.Click += new System.EventHandler(this.iesireToolStripMenuItem_Click);
            // 
            // editarePlaylistToolStripMenuItem
            // 
            this.editarePlaylistToolStripMenuItem.Name = "editarePlaylistToolStripMenuItem";
            this.editarePlaylistToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.editarePlaylistToolStripMenuItem.Text = "Editare playlist";
            this.editarePlaylistToolStripMenuItem.Click += new System.EventHandler(this.editarePlaylistToolStripMenuItem_Click);
            // 
            // radioToolStripMenuItem
            // 
            this.radioToolStripMenuItem.Name = "radioToolStripMenuItem";
            this.radioToolStripMenuItem.Size = new System.Drawing.Size(74, 29);
            this.radioToolStripMenuItem.Text = "Radio";
            this.radioToolStripMenuItem.Click += new System.EventHandler(this.radioToolStripMenuItem_Click);
            // 
            // groupBox
            // 
            this.groupBox.Location = new System.Drawing.Point(20, 43);
            this.groupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox.Size = new System.Drawing.Size(1214, 631);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MP3Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 692);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.menuStrip);
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
    }
}

