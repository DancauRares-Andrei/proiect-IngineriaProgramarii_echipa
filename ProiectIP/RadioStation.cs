﻿/**************************************************************************
 *                                                                        *
 *  File:        RadioStation.cs                                          *
 *  Copyright:   (c) 2023, Cojocaru Rareș                                 *
 *  E-mail:      rares.cojocaru@student.tuiasi.ro                         *
 *  Description: Clasa folosită pentru a descrie un canal de Radio        *
 *                                                                        *
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

namespace ProiectIP
{
    /// <summary>
    /// Clasa folosita pentru a descrie un post de radio.
    /// </summary>
    internal class RadioStation
    {
        public string Name { get; set; }
        public string Link { get; set; }

        public RadioStation(string name, string link)
        {
            this.Name = name;
            this.Link = link;
        }
    }
}
