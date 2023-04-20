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
        public void Handle(Context context)
        {
            context.Controls.Add(new AxWindowsMediaPlayer());
            context.Controls.Add(new ListBox());
            context.Controls.Add(new CheckBox());
        }
    }
}
