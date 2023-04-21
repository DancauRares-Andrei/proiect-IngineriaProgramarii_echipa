using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StateChange
{
    public class PlaylistState : State
    {
        public bool Handle(Context context)
        {
            if (context.StateNumber == 2)
            {
                context.Controls.Add(new AxWindowsMediaPlayer());
                context.Controls.Add(new ListBox());
                context.Controls.Add(new CheckBox());
                return true;
            }
            switch (context.StateNumber)
            {
                case 1:context.State = new SingleFileState(); break;
                case 3:context.State = new MakePlaylistState(); break;
            }
            return false;
        }
    }
}
