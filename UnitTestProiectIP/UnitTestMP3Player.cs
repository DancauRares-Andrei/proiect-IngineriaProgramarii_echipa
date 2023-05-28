/**************************************************************************
 *                                                                        *
 *  File:        UnitTestMP3Player.cs                                     *
 *  Copyright:   (c) 2023, Ganea Luiza-Andreea                            *
 *  E-mail:      luiza-andreea.ganea@student.tuiasi.ro                    *
 *  Description: Clasa destinata testarii unitatilor clasei               *
 *              MP3Player.cs                                              *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProiectIP;
using StateChange;

namespace UnitTestProiectIP
{
    /// <summary>
    /// Clasa destinata testarii unitatilor clasei UnitTestMP3Player
    /// </summary>
    [TestClass]
    public class UnitTestMP3Player
    {
        /// <summary>
        /// Testarea metodei InitializeMakePlailistContext, a tipului variabilei State a contextului, a numarului de controale din context
        /// </summary>
        [TestMethod]
        public void TestInitializeMakePlaylistContext()
        {
            MP3Player mp3player = new MP3Player();
            Context context = new Context();

            mp3player.InitializeMakePlaylistContext(context);
            Assert.AreEqual(3, context.Controls.Count);
            Assert.AreEqual(MP3PlayerStates.MakePlaylistState, context.StateNumber);
        }
        /// <summary>
        /// Testarea metodei de initializare a radioului
        /// </summary>
        [TestMethod]
        public void TestInitializeRadioContext()
        {
            MP3Player mp3player = new MP3Player();
            Context context = new Context();

            mp3player.InitializeRadioContext(context);
            Assert.AreEqual(3, context.Controls.Count);
            Assert.AreEqual(MP3PlayerStates.RadioState, context.StateNumber);
        }
    }
}
