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
    public partial class Form1 : Form
    {
        private Context _context;
        public Form1()
        {
            InitializeComponent();
        }

        private void deschidereFisierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                groupBox1.Controls.Clear();
                openFileDialog1.Filter = "Audio file(*.mp3)|*.mp3";
                if (openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;
                if (_context != null && _context.Controls.Count<2)
                {
                   ((AxWindowsMediaPlayer)_context.Controls[0]).URL = Path.GetFullPath(openFileDialog1.FileName);
                }
                else
                {
                    if(_context!=null)
                        ((AxWindowsMediaPlayer)_context.Controls[0]).Ctlcontrols.stop();
                    _context = new Context(new SingleFileState(), Path.GetFullPath(openFileDialog1.FileName));
                    _context.Request();
                    groupBox1.Controls.Add(_context.Controls[0]);
                    _context.Controls[0].CreateControl();
                    ((AxWindowsMediaPlayer)_context.Controls[0]).settings.setMode("loop", true);
                    _context.Controls[0].Location = new System.Drawing.Point(6, 27);
                    _context.Controls[0].Size = new System.Drawing.Size(498, 368);
                    ((AxWindowsMediaPlayer)_context.Controls[0]).URL = Path.GetFullPath(openFileDialog1.FileName);
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
                openFileDialog1.Filter = "Playlist(*.txt)|*.txt";
                if (openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;
                if (_context != null && _context.Controls.Count > 2)
                {
                    List<string> melodii = new List<string>();
                    StreamReader sr = new StreamReader(Path.GetFullPath(openFileDialog1.FileName));
                    string[] lvls = sr.ReadToEnd().Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
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


                    ((ListBox)_context.Controls[1]).SelectedIndexChanged += listBox1_SelectedIndexChanged;
                    ((AxWindowsMediaPlayer)_context.Controls[0]).URL = ((dynamic)((ListBox)_context.Controls[1]).SelectedItem).Path;
                }
                else
                {
                    groupBox1.Controls.Clear();
                    if (_context != null)
                        ((AxWindowsMediaPlayer)_context.Controls[0]).Ctlcontrols.stop();
                    _context = new Context(new PlaylistState(), Path.GetFullPath(openFileDialog1.FileName));
                    _context.Request();
                    groupBox1.Controls.Add(_context.Controls[0]);
                    groupBox1.Controls.Add(_context.Controls[1]);
                    groupBox1.Controls.Add(_context.Controls[2]);
                    _context.Controls[0].Location = new System.Drawing.Point(6, 27);
                    _context.Controls[0].Size = new System.Drawing.Size(498, 368);
                    List<string> melodii = new List<string>();
                    StreamReader sr = new StreamReader(Path.GetFullPath(openFileDialog1.FileName));
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


                    ((ListBox)_context.Controls[1]).SelectedIndexChanged += listBox1_SelectedIndexChanged;
                    ((AxWindowsMediaPlayer)_context.Controls[0]).URL = ((dynamic)((ListBox)_context.Controls[1]).SelectedItem).Path;
                    ((AxWindowsMediaPlayer)_context.Controls[0]).PlayStateChange += axWindowsMediaPlayer1_PlayStateChange;
                    _context.Controls[2].Text = "Random";
                    _context.Controls[2].Size = new System.Drawing.Size(66, 17);
                    _context.Controls[2].Location = new System.Drawing.Point(740, 27);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                if (e.newState == 8)
                {
                    timer1.Enabled = true;
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
                timer1.Enabled = false;
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
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
