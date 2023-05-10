/**************************************************************************
 *                                                                        *
 *  File:        Context.cs                                               *
 *  Copyright:   (c) 2023, Dancău Rareș-Andrei                            *
 *  E-mail:      rares-andrei.dancau@student.tuiasi.ro                    *
 *  Description: Clasă folosită pentru a determina starea curentă a       *
 *               programului și modificarea în mod corespunzător a        *
 *               facilităților.                                           *
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
{// Clasa Context are rolul de a stoca starea curenta si controalele asociate starii.
    public class Context
    { // Lista de controale pentru starea curenta
        public List<Control> Controls { get; set; }
        // Starea curenta a contextului
        public State State { get; set; }
        // Numarul starii curente
        public MP3PlayerStates StateNumber { get; set; }
        // Constructorul Context initializeaza starea curenta, lista de controale si numarul starii cu "NoState"
        public Context(State state)
        {
            State = state;
            Controls = new List<Control>();
            StateNumber = MP3PlayerStates.NoState;
        }
        // Metoda Request este folosita pentru a solicita incarcarea controalelor
        public void Request()
        {   //Se incearca incarcarea controalelor cu starea curenta         
            bool x= State.Handle(this);
            //Daca s-a revenit pe false, inseamna ca s-a schimbat starea si trebuie facuta incarcarea controalelor
            if(!x)
            {
                x = State.Handle(this);
            }
        }
    }
}
