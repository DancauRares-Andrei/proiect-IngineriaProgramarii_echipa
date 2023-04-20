using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StateChange
{
   public class Context
    {
        public List<Control> Controls { get; set; }
        public State State { get; set; }
        public string Fisier { get; set; }
        public Context(State state,string fisier)
        {
            State = state;
            Fisier = fisier;
            Controls = new List<Control>();
        }

        public void Request() => State.Handle(this);
    }
}
