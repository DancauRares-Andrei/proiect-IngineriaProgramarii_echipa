using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StateChange
{
    public class MakePlaylistState : State
    {
        public bool Handle(Context context)
        {
            if (context.StateNumber == MP3PlayerStates.MAKE_PLAYLIST_STATE)
            {
                context.Controls.Add(new Button());
                context.Controls.Add(new Button());
                context.Controls.Add(new TextBox());
                return true;
            }
            switch (context.StateNumber)
            {
                case MP3PlayerStates.SINGLE_FILE_STATE: context.State = new SingleFileState(); break;
                case MP3PlayerStates.PLAYLIST_STATE: context.State = new PlaylistState(); break;
            }
            return false;
        }
    }
}
