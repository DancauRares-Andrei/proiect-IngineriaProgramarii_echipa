﻿using AxWMPLib;
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

        public int StateNumber { get; set; }
        public Context(State state)
        {
            State = state;
            Controls = new List<Control>();
            StateNumber = 0;
        }

        public void Request()
        {            
            bool x= State.Handle(this);
            while (!x)
            {
                x = State.Handle(this);
            }
        }
    }
}
