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
            if (context.StateNumber == 3)
            {
                context.Controls.Add(new Button());
                context.Controls.Add(new Button());
                context.Controls.Add(new TextBox());
                return true;
            }
            switch (context.StateNumber)
            {
                case 1: context.State = new SingleFileState(); break;
                case 2: context.State = new PlaylistState(); break;
            }
            return false;
        }
    }
}
