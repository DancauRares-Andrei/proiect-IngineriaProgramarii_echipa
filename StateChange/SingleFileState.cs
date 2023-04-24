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
            if (context.StateNumber == MP3PlayerStates.SINGLE_FILE_STATE)
            {
                AxWindowsMediaPlayer axWindowsMediaPlayer = new AxWindowsMediaPlayer();
                context.Controls.Add(axWindowsMediaPlayer);
                return true;
            }
            switch (context.StateNumber)
            {
                case MP3PlayerStates.PLAYLIST_STATE:context.State = new PlaylistState(); break;
                case MP3PlayerStates.MAKE_PLAYLIST_STATE:context.State = new MakePlaylistState();break;
            }
            return false;
        }
    }
}
