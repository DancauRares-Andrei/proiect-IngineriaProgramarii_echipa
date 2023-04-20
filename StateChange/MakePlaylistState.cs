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
        public void Handle(Context context)
        {
            context.Controls.Add(new Button());
            context.Controls.Add(new Button());
            context.Controls.Add(new TextBox());
            context.Controls.Add(new TextBox());
        }
    }
}
