using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/**************************************************************************
 *                                                                        *
 *  File:        PlaylistState.cs                                         *
 *  Copyright:   (c) 2023, Dancău Rareș-Andrei                            *
 *  E-mail:      rares-andrei.dancau@student.tuiasi.ro                    *
 *  Description: Clasă folosită de context în cazul în care se            *
 *               deschis un playlist.                                     *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

namespace StateChange
{
    public class PlaylistState : State
    {
        public bool Handle(Context context)
        {
            // Verificăm dacă starea actuală este deja PlaylistState
            if (context.StateNumber == MP3PlayerStates.PlaylistState)
            {// Dacă da, eliminăm controalele existente și adăugăm cele necesare pentru această stare
                context.Controls.Clear();
                context.Controls.Add(new AxWindowsMediaPlayer());
                context.Controls.Add(new ListBox());
                context.Controls.Add(new CheckBox());
                context.Controls.Add(new CheckBox());
                return true; // Returnăm true pentru a indica că starea este valida
            }
            //  Dacă nu suntem în starea PlaylistState, trecem la altă stare
            switch (context.StateNumber)
            {
                case MP3PlayerStates.SingleFileState:context.State = new SingleFileState(); break;
                case MP3PlayerStates.MakePlaylistState:context.State = new MakePlaylistState(); break;
              //  case MP3PlayerStates.EditPlaylistState: context.State = new EditPlaylistState(); break;
              //  case MP3PlayerStates.RadioState: context.State = new RadioState(); break;
            }
            return false;// Returnăm false pentru a indica că starea a necesitat o schimbare
        }
    }
}
