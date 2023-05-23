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
using NAudio.Wave;
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
using static System.Net.WebRequestMethods;


namespace ProiectIP
{
    /// <summary>
    /// Clasa principala a programului, ce extinde clasa Form
    /// </summary>
    public partial class MP3Player : Form
    {
        /// <summary>
        /// Contextul folosit de program pentru a schimba controalele din groupBox
        /// </summary>
        private Context _context;
        /// <summary>
        /// Constructor ce initializeaza componentele Form-ului si apeleaza contructorul contextului
        /// </summary>
        public MP3Player()
        {
            InitializeComponent();
            _context = new Context();
        }
        /// <summary>
        /// Functie apelata atunci cand se apasa "Deschidere fisier"
        /// </summary>
        private WaveOut waveOut;
        private MediaFoundationReader mediaFoundationReader;
        private string url;

        private void deschidereFisierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificam daca nu se reda un canal de radio.
                if (this.waveOut != null && this.waveOut.PlaybackState == PlaybackState.Playing)
                {
                    //Daca da, il oprim.
                    this.waveOut.Stop();
                }
                openFileDialog.Filter = "Audio file(*.mp3)|*.mp3";
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                if (_context.StateNumber == MP3PlayerStates.SingleFileState)
                {
                    ((AxWindowsMediaPlayer)_context.Controls[0]).URL = Path.GetFullPath(openFileDialog.FileName);
                }
                else
                {
                    groupBox.Controls.Clear();
                    if (_context.StateNumber == MP3PlayerStates.PlaylistState)
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
        /// <summary>
        /// Functie apelata atunci cand se apasa "Iesire"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Functie apelata cand se apasa "Deschidere playlist"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deschiderePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificam daca nu se reda un canal de radio.
                if (this.waveOut != null && this.waveOut.PlaybackState == PlaybackState.Playing)
                {
                    //Daca da, il oprim.
                    this.waveOut.Stop();
                }
                openFileDialog.Filter = "Playlist(*.txt)|*.txt";
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                List<string> melodii = new List<string>();
                StreamReader sr = new StreamReader(Path.GetFullPath(openFileDialog.FileName));
                string[] lvls = sr.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                sr.Close();
                for (int i = 0; i < lvls.Length; i++)
                    melodii.Add(lvls[i]);
                // Crearea listei cu perechi cheie-valoare (calea completa la fisier - numele fisierului)
                var files = melodii.Select(path => new { Path = path, FileName = Path.GetFileName(path) }).ToList();
                if (_context.StateNumber == MP3PlayerStates.PlaylistState)
                {
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
                    if (_context.StateNumber == MP3PlayerStates.SingleFileState)
                        ((AxWindowsMediaPlayer)_context.Controls[0]).Ctlcontrols.stop();

                    _context.StateNumber = MP3PlayerStates.PlaylistState;
                    _context.Request();
                    groupBox.Controls.Add(_context.Controls[0]);
                    groupBox.Controls.Add(_context.Controls[1]);
                    groupBox.Controls.Add(_context.Controls[2]);
                    groupBox.Controls.Add(_context.Controls[3]);
                    _context.Controls[0].Location = new System.Drawing.Point(6, 27);
                    _context.Controls[0].Size = new System.Drawing.Size(498, 368);
                    _context.Controls[1].Location = new System.Drawing.Point(531, 27);
                    _context.Controls[1].Size = new System.Drawing.Size(200, 368);
                    ((ListBox)_context.Controls[1]).HorizontalScrollbar = true;
                    _context.Controls[2].Text = "Random";
                    _context.Controls[2].Size = new System.Drawing.Size(66, 17);
                    _context.Controls[2].Location = new System.Drawing.Point(740, 27);
                    _context.Controls[3].Text = "Loop";
                    ((CheckBox)_context.Controls[3]).CheckedChanged += PlaylistLoop_CheckedChanged;
                    _context.Controls[3].Size = new System.Drawing.Size(66, 17);
                    _context.Controls[3].Location = new System.Drawing.Point(740, 47);

                    // Setarea DataSource-ului pentru ListBox
                    ((ListBox)_context.Controls[1]).DataSource = files;

                    // Setarea DisplayMember-ului si ValueMember-ului pentru ListBox
                    ((ListBox)_context.Controls[1]).DisplayMember = "FileName";
                    ((ListBox)_context.Controls[1]).ValueMember = "Path";


                    ((ListBox)_context.Controls[1]).SelectedIndexChanged += listBoxPlaylist_SelectedIndexChanged;
                    ((AxWindowsMediaPlayer)_context.Controls[0]).URL = ((dynamic)((ListBox)_context.Controls[1]).SelectedItem).Path;
                    ((AxWindowsMediaPlayer)_context.Controls[0]).PlayStateChange += axWindowsMediaPlayer_PlayStateChange;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Functie apelata atunci cand se apasa pe checkbox-ul Loop din playlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Functie apelata atunci cand se schimba melodia selectata din playlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Functie apelata atunci cand obiectul AxWindowsMediaPlayer isi schimba starea
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axWindowsMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
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
        /// <summary>
        /// Functie apelata atunci cand trece perioada unui timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                timer.Enabled = false;
                if (((ListBox)_context.Controls[1]).Items.Count == 1)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Functie apelata atunci cand se apasa pe "Creare playlist"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void crearePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox.Controls.Clear();
            try
            {
                //Verificam daca nu se reda un canal de radio.
                if (this.waveOut != null && this.waveOut.PlaybackState == PlaybackState.Playing)
                {
                    //Daca da, il oprim.
                    this.waveOut.Stop();
                }
                if (_context.StateNumber == MP3PlayerStates.SingleFileState || _context.StateNumber == MP3PlayerStates.PlaylistState)
                {
                    ((AxWindowsMediaPlayer)_context.Controls[0]).Ctlcontrols.stop();
                }
                InitializeMakePlaylistContext(_context);
                groupBox.Controls.Add(_context.Controls[0]);
                groupBox.Controls.Add(_context.Controls[1]);
                groupBox.Controls.Add(_context.Controls[2]);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Functie apelata atunci cand se apasa pe butonul de salvare din creare playlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Functie apelata atunci cand se apasa pe butonul de adaugare cantec din creare playlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Functie ce initializeaza contextul la crearea unui playlist
        /// </summary>
        public void InitializeMakePlaylistContext(Context context)
        {
            context.StateNumber = MP3PlayerStates.MakePlaylistState;
            context.Request();
            context.Controls[0].Text = "Adaugă fișier";
            context.Controls[1].Text = "Salvează playlist";
            context.Controls[2].Enabled = false;
            context.Controls[0].Location = new System.Drawing.Point(30, 30);
            context.Controls[1].Location = new System.Drawing.Point(120, 30);
            context.Controls[2].Location = new System.Drawing.Point(30, 60);
            ((TextBox)context.Controls[2]).Multiline = true;
            ((TextBox)context.Controls[2]).Size = new System.Drawing.Size(770, 300);
            ((Button)context.Controls[0]).Click += AddButtonClick;
            ((Button)context.Controls[1]).Click += SaveButtonClick;
        }

        private void operatiiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Functie ce initializeaza contextul pentru starea Radio
        /// </summary>
        public void InitializeRadioContext(Context context)
        {
            context.StateNumber = MP3PlayerStates.RadioState;
            context.Request();
            context.Controls[1].Text = "Play";
            context.Controls[2].Text = "Stop";
            context.Controls[2].Enabled = false;

            context.Controls[0].Location = new System.Drawing.Point(100, 20);
            context.Controls[0].Size = new System.Drawing.Size(600, 200);

            context.Controls[1].Location = new System.Drawing.Point(100, 300);
            context.Controls[1].Size = new System.Drawing.Size(150, 50);

            context.Controls[2].Location = new System.Drawing.Point(550, 300);
            context.Controls[2].Size = new System.Drawing.Size(150, 50);
            ((Button)context.Controls[1]).Click += PlayButtonClick;
            ((Button)context.Controls[2]).Click += StopButtonClick;
        }

        /// <summary>
        /// Functie apelata atunci cand se apasa pe butonul play din starea RadioState
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayButtonClick(object sender, EventArgs e)
        {
            try
            {
                //Verificam daca nu se reda un canal de radio.
                if (this.waveOut != null && this.waveOut.PlaybackState == PlaybackState.Playing)
                {
                    //Daca da, il oprim.
                    this.waveOut.Stop();
                }
                this.waveOut = new WaveOut();
                this.mediaFoundationReader = new MediaFoundationReader(this.url);
                this.waveOut.Init(mediaFoundationReader);
                this.waveOut.Play();
                _context.Controls[2].Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Functie apelata atunci cand se apasa pe butonul stop din starea RadioState
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopButtonClick(object sender, EventArgs e)
        {
            try { 
                this.waveOut.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Functie apelata cand se apasa "Radio"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void radioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Adaugam intr-o lista toate posturile de radio.
            List<RadioStation> radioStationList = new List<RadioStation>
            {
            new RadioStation("Radio Paradise - Main Mix", "http://stream.radioparadise.com/aac-320"),
            new RadioStation("Radio Paradise - Rock Mix", "http://stream.radioparadise.com/rock-320"),
            new RadioStation("Radio Paradise - Mellow Mix", "http://stream.radioparadise.com/mellow-320"),
            new RadioStation("Radio Paradise - Global Mix", "http://stream.radioparadise.com/global-320"),
            new RadioStation("JazzFM UK", "http://radio.canstream.co.uk:8007/live.mp3"),
            new RadioStation("KissFM", "https://astreaming.edi.ro:8443/EuropaFM_aac"),
            new RadioStation("MagicFM", "https://live.magicfm.ro:8443/magicfm.aacp"),
            new RadioStation("ProFM", "https://edge126.rcs-rds.ro/profm/profm.mp3"),
            new RadioStation("Radio ZU", "http://zuicast.digitalag.ro:9420/zu"),
            new RadioStation("DigiFM", "http://edge76.rdsnet.ro:84/digifm/digifm.mp3")
            };
            if (_context.StateNumber == MP3PlayerStates.SingleFileState || _context.StateNumber == MP3PlayerStates.PlaylistState)
            {
                ((AxWindowsMediaPlayer)_context.Controls[0]).Ctlcontrols.stop();
            }
            groupBox.Controls.Clear();
            try
            {
                _context.StateNumber = MP3PlayerStates.RadioState;
                _context.Request();
                InitializeRadioContext(_context);
                groupBox.Controls.Add(_context.Controls[0]);
                groupBox.Controls.Add(_context.Controls[1]);
                groupBox.Controls.Add(_context.Controls[2]);

                ((ListBox)_context.Controls[0]).DataSource = radioStationList;
                ((ListBox)_context.Controls[0]).DisplayMember = "Name";
                ((ListBox)_context.Controls[0]).SelectedIndex = 1;
                ((ListBox)_context.Controls[0]).SelectedIndexChanged += (radioStationItem, args) =>
                {
                    var selectedRadio = (RadioStation)((ListBox)_context.Controls[0]).SelectedItem;
                    this.url = selectedRadio.Link;
                };
                ((ListBox)_context.Controls[0]).SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
