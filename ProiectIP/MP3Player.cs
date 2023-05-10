/**************************************************************************
 *                                                                        *
 *  File:        MP3Player.cs                                             *
 *  Copyright:   (c) 2023, Dancău Rareș-Andrei                            *
 *  E-mail:      rares-andrei.dancau@student.tuiasi.ro                    *
 *  Description: Clasa principală a programului ce implementează          *
 *               logica acestuia.                                         *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/
using AxWMPLib;
using StateChange;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectIP
{
    public partial class MP3Player : Form
    {
        private Context _context;
        public MP3Player()
        {
            InitializeComponent();
            _context = new Context(new SingleFileState());
        }

        private void deschidereFisierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                openFileDialog.Filter = "Audio file(*.mp3)|*.mp3";
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                if (_context.StateNumber==MP3PlayerStates.SingleFileState)
                {
                   ((AxWindowsMediaPlayer)_context.Controls[0]).URL = Path.GetFullPath(openFileDialog.FileName);
                }
                else
                {
                    groupBox.Controls.Clear();
                    if (_context.StateNumber==MP3PlayerStates.PlaylistState)
                        ((AxWindowsMediaPlayer)_context.Controls[0]).Ctlcontrols.stop();
                    _context.StateNumber = MP3PlayerStates.SingleFileState;
                    _context.Request();
                    groupBox.Controls.Add(_context.Controls[0]);
                    _context.Controls[0].CreateControl();
                    ((AxWindowsMediaPlayer)_context.Controls[0]).settings.setMode("loop", true);
                    _context.Controls[0].Location = new System.Drawing.Point(6, 27);
                    _context.Controls[0].Size = new System.Drawing.Size(498, 368);
                    ((AxWindowsMediaPlayer)_context.Controls[0]).URL = Path.GetFullPath(openFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deschiderePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                openFileDialog.Filter = "Playlist(*.txt)|*.txt";
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                if (_context.StateNumber==MP3PlayerStates.PlaylistState)
                {
                    List<string> melodii = new List<string>();
                    StreamReader sr = new StreamReader(Path.GetFullPath(openFileDialog.FileName));
                    string[] lvls = sr.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    sr.Close();
                    for (int i = 0; i < lvls.Length; i++)
                        melodii.Add(lvls[i]);
                    // Crearea listei cu perechi cheie-valoare (calea completa la fisier - numele fisierului)
                    var files = melodii.Select(path => new { Path = path, FileName = Path.GetFileName(path) }).ToList();

                    // Setarea DataSource-ului pentru ListBox
                    ((ListBox)_context.Controls[1]).DataSource = files;

                    // Setarea DisplayMember-ului si ValueMember-ului pentru ListBox
                    ((ListBox)_context.Controls[1]).DisplayMember = "FileName";
                    ((ListBox)_context.Controls[1]).ValueMember = "Path";


                    ((ListBox)_context.Controls[1]).SelectedIndexChanged += listBoxPlaylist_SelectedIndexChanged;
                    ((AxWindowsMediaPlayer)_context.Controls[0]).URL = ((dynamic)((ListBox)_context.Controls[1]).SelectedItem).Path;
                }
                else
                {
                    groupBox.Controls.Clear();
                    if (_context.StateNumber==MP3PlayerStates.SingleFileState)
                        ((AxWindowsMediaPlayer)_context.Controls[0]).Ctlcontrols.stop();
                    
                    _context.StateNumber = MP3PlayerStates.PlaylistState;
                    _context.Request();
                    groupBox.Controls.Add(_context.Controls[0]);
                    groupBox.Controls.Add(_context.Controls[1]);
                    groupBox.Controls.Add(_context.Controls[2]);
                    groupBox.Controls.Add(_context.Controls[3]);
                    _context.Controls[0].Location = new System.Drawing.Point(6, 27);
                    _context.Controls[0].Size = new System.Drawing.Size(498, 368);
                    List<string> melodii = new List<string>();
                    StreamReader sr = new StreamReader(Path.GetFullPath(openFileDialog.FileName));
                    string[] lvls = sr.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    sr.Close();
                    for (int i = 0; i < lvls.Length; i++)
                        melodii.Add(lvls[i]);
                    _context.Controls[1].Location = new System.Drawing.Point(531, 27);
                    _context.Controls[1].Size = new System.Drawing.Size(200, 368);
                    ((ListBox)_context.Controls[1]).HorizontalScrollbar = true;
                    // Crearea listei cu perechi cheie-valoare (calea completa la fisier - numele fisierului)
                    var files = melodii.Select(path => new { Path = path, FileName = Path.GetFileName(path) }).ToList();

                    // Setarea DataSource-ului pentru ListBox
                    ((ListBox)_context.Controls[1]).DataSource = files;

                    // Setarea DisplayMember-ului si ValueMember-ului pentru ListBox
                    ((ListBox)_context.Controls[1]).DisplayMember = "FileName";
                    ((ListBox)_context.Controls[1]).ValueMember = "Path";


                    ((ListBox)_context.Controls[1]).SelectedIndexChanged += listBoxPlaylist_SelectedIndexChanged;
                    ((AxWindowsMediaPlayer)_context.Controls[0]).URL = ((dynamic)((ListBox)_context.Controls[1]).SelectedItem).Path;
                    ((AxWindowsMediaPlayer)_context.Controls[0]).PlayStateChange += axWindowsMediaPlayer1_PlayStateChange;
                    _context.Controls[2].Text = "Random";
                    _context.Controls[2].Size = new System.Drawing.Size(66, 17);
                    _context.Controls[2].Location = new System.Drawing.Point(740, 27);
                    _context.Controls[3].Text = "Loop";
                    ((CheckBox)_context.Controls[3]).CheckedChanged += PlaylistLoop_CheckedChanged;
                    _context.Controls[3].Size = new System.Drawing.Size(66, 17);
                    _context.Controls[3].Location = new System.Drawing.Point(740, 47);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PlaylistLoop_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox checkBox = (CheckBox)sender;
                if (checkBox.Checked)
                {
                    ((AxWindowsMediaPlayer)_context.Controls[0]).settings.setMode("loop", true);
                }
                else
                {
                    ((AxWindowsMediaPlayer)_context.Controls[0]).settings.setMode("loop", false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listBoxPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListBox listBox = (ListBox)sender;
                int selectedIndex = listBox.SelectedIndex;
                if (listBox.SelectedIndex > -1)
                {
                    ((AxWindowsMediaPlayer)_context.Controls[0]).URL = ((dynamic)listBox.SelectedItem).Path;
                    ((AxWindowsMediaPlayer)_context.Controls[0]).Ctlcontrols.play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            try
            {
                if (e.newState == 8 && ((CheckBox)_context.Controls[3]).Checked == false)
                {
                    timer.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer.Enabled = false;
                if(((ListBox)_context.Controls[1]).Items.Count==1)
                    ((AxWindowsMediaPlayer)_context.Controls[0]).URL = ((dynamic)((ListBox)_context.Controls[1]).SelectedItem).Path;
                else
                {
                    if (((CheckBox)_context.Controls[2]).Checked)
                    {
                        Random rnd = new Random();
                        int nowPlayIndex = rnd.Next(((ListBox)_context.Controls[1]).Items.Count);
                        while (nowPlayIndex == ((ListBox)_context.Controls[1]).SelectedIndex)
                            nowPlayIndex = rnd.Next(((ListBox)_context.Controls[1]).Items.Count);
                        ((ListBox)_context.Controls[1]).SelectedIndex = nowPlayIndex;
                    }
                    else
                    {
                        if (((ListBox)_context.Controls[1]).SelectedIndex != ((ListBox)_context.Controls[1]).Items.Count - 1)
                        {
                            ((ListBox)_context.Controls[1]).SelectedIndex = ((ListBox)_context.Controls[1]).SelectedIndex + 1;
                        }
                        else
                        {
                            ((ListBox)_context.Controls[1]).SelectedIndex = 0;
                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void crearePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox.Controls.Clear();
            try
            {
                if (_context.StateNumber==MP3PlayerStates.SingleFileState || _context.StateNumber==MP3PlayerStates.PlaylistState)
                {
                    ((AxWindowsMediaPlayer)_context.Controls[0]).Ctlcontrols.stop();
                }
                _context.StateNumber = MP3PlayerStates.MakePlaylistState;
                _context.Request();
                _context.Controls[0].Text = "Adaugă fișier";
                _context.Controls[1].Text = "Salvează playlist";
                _context.Controls[2].Enabled = false;
                _context.Controls[0].Location = new System.Drawing.Point(30, 30);
                _context.Controls[1].Location= new System.Drawing.Point(120, 30);
                _context.Controls[2].Location = new System.Drawing.Point(30, 60);
                ((TextBox)_context.Controls[2]).Multiline = true;
                ((TextBox)_context.Controls[2]).Size = new System.Drawing.Size(770, 300);
                ((Button)_context.Controls[0]).Click += AddButtonClick;
                ((Button)_context.Controls[1]).Click += SaveButtonClick;
                groupBox.Controls.Add(_context.Controls[0]);
                groupBox.Controls.Add(_context.Controls[1]);
                groupBox.Controls.Add(_context.Controls[2]);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.Filter = "Playlist(*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(saveFileDialog.FileName, ((TextBox)_context.Controls[2]).Text);
                    groupBox.Controls.Clear();
                    _context.Controls.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.Filter = "Audio file(*.mp3)|*.mp3";
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                _context.Controls[2].Text += Path.GetFullPath(openFileDialog.FileName) + "\r\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
