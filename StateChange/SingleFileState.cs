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
        public bool Handle(Context context)
        {
            if (context.StateNumber == 1)
            {
                AxWindowsMediaPlayer axWindowsMediaPlayer = new AxWindowsMediaPlayer();
                context.Controls.Add(axWindowsMediaPlayer);
                return true;
            }
            switch (context.StateNumber)
            {
                case 2:context.State = new PlaylistState(); break;
                case 3:context.State = new MakePlaylistState();break;
            }
            return false;
        }
    }
}
