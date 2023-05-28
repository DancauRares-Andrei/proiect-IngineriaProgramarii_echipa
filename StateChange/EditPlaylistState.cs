/**************************************************************************
 *                                                                        *
 *  File:        EditPlaylistState.cs                                     *
 *  Copyright:   (c) 2023, Andra-Teodora Samachis                         *
 *  E-mail:      andra-teodora.samachis@student.tuiasi.ro                 *
 *  Description: Clasa folosită de context în cazul în care se alege      *
 *               opțiunea de a edita un playlist                          *
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StateChange
{
    /// <summary>
    /// Clasa folosita de context atunci cand se editeaza un playlist
    /// </summary>
    public class EditPlaylistState : IState
    {
        /// <summary>
        /// Functie in care se schimba starea contextului, daca StateNumber nu corespunde, sau se inserează controalele în context, altfel.
        /// </summary>
        /// <param name="context">Contextul asupra caruia se vor aplica operatiile</param>
        /// <returns>Returneaza true daca starea este valida sau false daca starea necesita o schimbare</returns>
        public bool Handle(Context context)
        {
            // Verificăm dacă starea actuală este deja EditPlaylistState
            if (context.StateNumber == MP3PlayerStates.EditPlaylistState)
            {
                // Dacă da, eliminăm controalele existente și adăugăm cele necesare pentru această stare
                context.Controls.Clear();
                context.Controls.Add(new AxWindowsMediaPlayer());
                context.Controls.Add(new ListBox());
                context.Controls.Add(new Button());
                context.Controls.Add(new Button());
                context.Controls.Add(new Button());

                return true; // Returnăm true pentru a indica că starea este valida
            }
            // Dacă nu suntem în starea RadioState, trecem la altă stare
            switch (context.StateNumber)
            {
                case MP3PlayerStates.PlaylistState: context.State = new PlaylistState(); break;
                case MP3PlayerStates.MakePlaylistState: context.State = new MakePlaylistState(); break;
                case MP3PlayerStates.RadioState: context.State = new RadioState(); break;
                case MP3PlayerStates.SingleFileState: context.State = new SingleFileState(); break;

            }
            return false;
        }
    }
}
