using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StateChange
{
    public class SingleFileState : State
    {
        public void Handle(Context context)
        {
            AxWindowsMediaPlayer axWindowsMediaPlayer = new AxWindowsMediaPlayer();
             axWindowsMediaPlayer.CreateControl();
             /*          axWindowsMediaPlayer.settings.setMode("loop", true);
                       axWindowsMediaPlayer.Location = new System.Drawing.Point(12, 66);
                       axWindowsMediaPlayer.Size = new System.Drawing.Size(498, 368);*/
            context.Controls.Add(axWindowsMediaPlayer);
            // axWindowsMediaPlayer.URL = Fisier;
           // return new Button();
        }
    }
}
