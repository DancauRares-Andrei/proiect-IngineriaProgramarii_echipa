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
    /// <summary>
    /// Clasa folosita de context atunci cand se creeaza un playlist
    /// </summary>
    public class MakePlaylistState : IState
    {
        /// <summary>
        /// Functie in care se schimba starea contextului, daca StateNumber nu corespunde, sau se inserează controalele în context, altfel.
        /// <param name="context">Contextul asupra caruia se vor aplica operatiile</param>
        /// <returns>Returneaza true daca starea este valida sau false daca starea necesita o schimbare</returns>
        /// </summary>
        public bool Handle(Context context)
        {
            // Verificăm dacă starea actuală este deja MakePlaylistState
            if (context.StateNumber == MP3PlayerStates.MakePlaylistState)
            {
                // Dacă da, eliminăm controalele existente și adăugăm cele necesare pentru această stare
                context.Controls.Clear();
                context.Controls.Add(new Button());
                context.Controls.Add(new Button());
                context.Controls.Add(new TextBox());
                return true; // Returnăm true pentru a indica că starea este valida
            }

            // Dacă nu suntem în starea MakePlaylistState, trecem la altă stare
            switch (context.StateNumber)
            {
                case MP3PlayerStates.SingleFileState:
                    context.State = new SingleFileState();
                    break;
                case MP3PlayerStates.PlaylistState:
                    context.State = new PlaylistState();
                    break;
                case MP3PlayerStates.EditPlaylistState:
                    //context.State = new EditPlaylistState();
                    break;
                case MP3PlayerStates.RadioState:
                    //context.State = new RadioState();
                    break;
            }

            return false; // Returnăm false pentru a indica că starea a necesitat o schimbare
        }
    }
}

