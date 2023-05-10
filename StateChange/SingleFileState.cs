/**************************************************************************
 *                                                                        *
 *  File:        SingleFileState.cs                                       *
 *  Copyright:   (c) 2023, Dancău Rareș-Andrei                            *
 *  E-mail:      rares-andrei.dancau@student.tuiasi.ro                    *
 *  Description: Clasă folosită de context în cazul în care este          *
 *               deschis un singur fișier mp3.                            *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/
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
        {// Verificăm dacă starea actuală este deja SingleFileState
            if (context.StateNumber == MP3PlayerStates.SingleFileState)
            {// Dacă da, eliminăm controalele existente și adăugăm cele necesare pentru această stare
                context.Controls.Clear();
                AxWindowsMediaPlayer axWindowsMediaPlayer = new AxWindowsMediaPlayer();
                context.Controls.Add(axWindowsMediaPlayer);
                return true;
            }
            //  Dacă nu suntem în starea SingleFileState, trecem la altă stare
            switch (context.StateNumber)
            {
                case MP3PlayerStates.PlaylistState:context.State = new PlaylistState(); break;
                case MP3PlayerStates.MakePlaylistState:context.State = new MakePlaylistState();break;
               // case MP3PlayerStates.EditPlaylistState: context.State = new EditPlaylistState(); break;
               // case MP3PlayerStates.RadioState: context.State = new RadioState(); break;
            }
            return false;// Returnăm false pentru a indica că starea a necesitat o schimbare
        }
    }
}
