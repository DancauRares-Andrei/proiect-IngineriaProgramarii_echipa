/**************************************************************************
 *                                                                        *
 *  File:        MP3PlayerStates.cs                                       *
 *  Copyright:   (c) 2023, Dancău Rareș-Andrei                            *
 *  E-mail:     rares-andrei.dancau@student.tuiasi.ro                     *
 *  Description: Enumerație ce descrie stările posibile ale               *
 *               contextului.                                             *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/
// Enum-ul MP3PlayerStates defineste starile posibile ale obiectului Context
// Fiecare stare are o valoare numerica asociata, incepand cu 0 pentru NoState
// Aceste valori numerice sunt utilizate in logica de schimbare a starilor din clasa Context
namespace StateChange
{
    public enum MP3PlayerStates
    {
        NoState = 0, // Stare inexistenta, folosita inainte de a se face initializarea
        SingleFileState = 1, // Stare pentru redarea unui singur fisier audio
        PlaylistState = 2, // Stare pentru redarea unei liste de fisiere audio
        MakePlaylistState = 3, // Stare pentru crearea unei liste de fisiere audio
        EditPlaylistState = 4, // Stare pentru editarea unei liste de fisiere audio
        RadioState = 5 // Stare pentru redarea unui post de radio
    }
}
