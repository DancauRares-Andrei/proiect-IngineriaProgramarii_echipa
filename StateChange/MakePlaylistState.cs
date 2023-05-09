/**************************************************************************
 *                                                                        *
 *  File:        MakePlaylistState.cs                                     *
 *  Copyright:   (c) 2023, Dancău Rareș-Andrei                            *
 *  E-mail:      rares-andrei.dancau@student.tuiasi.ro                    *
 *  Description: Clasă folosită de context în cazul în care se creează    *
 *               un nou playlist.                                         *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/
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
            if (context.StateNumber == MP3PlayerStates.MakePlaylistState)
            {
                context.Controls.Add(new Button());
                context.Controls.Add(new Button());
                context.Controls.Add(new TextBox());
                return true;
            }
            switch (context.StateNumber)
            {
                case MP3PlayerStates.SingleFileState: context.State = new SingleFileState(); break;
                case MP3PlayerStates.PlaylistState: context.State = new PlaylistState(); break;
            }
            return false;
        }
    }
}
