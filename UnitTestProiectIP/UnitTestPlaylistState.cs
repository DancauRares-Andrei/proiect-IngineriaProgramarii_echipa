/**************************************************************************
 *                                                                        *
 *  File:        UnitTestPlaylistState.cs                                 *
 *  Copyright:   (c) 2023, Ganea Luiza-Andreea                            *
 *  E-mail:      luiza-andreea.ganea@student.tuiasi.ro                    *
 *  Description: Clasa destinata testarii unitatilor clasei               *
 *              PlaylistState.cs                                          *
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
using StateChange;

namespace UnitTestProiectIP
{
    [TestClass]
    public class UnitTestPlaylistState
    {
        /// <summary>
        /// Testarea starii curente (PlaylistState)
        /// </summary>
        [TestMethod]
        public void HandlePlaylistStateTrue()
        {
            PlaylistState playlistState = new PlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.PlaylistState;

            bool result = playlistState.Handle(context);

            Assert.IsTrue(result);
            Assert.AreEqual(4, context.Controls.Count);
        }

        /// <summary>
        /// Testarea schimbarii starii, a tipului variabilei State a contextului, a numarului de controale din context
        /// </summary>
        [TestMethod]
        public void HandlePlaylistStateFalseSingleFileState()
        {
            PlaylistState playlistState = new PlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.SingleFileState;

            bool result = playlistState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(SingleFileState));
            Assert.AreEqual(0, context.Controls.Count);
        }

        /// <summary>
        /// Testarea schimbarii starii, a tipului variabilei State a contextului, a numarului de controale din context
        /// </summary>
        [TestMethod]
        public void HandlePlaylistStateFalseMakePlaylistState()
        {
            PlaylistState playlistState = new PlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.MakePlaylistState;

            bool result = playlistState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(MakePlaylistState));
            Assert.AreEqual(0, context.Controls.Count);
        }

        /// <summary>
        /// Testarea schimbarii starii, a tipului variabilei State a contextului, a numarului de controale din context
        /// </summary>
        [TestMethod]
        public void HandlePlaylistStateFalseRadioState()
        {
            PlaylistState playlistState = new PlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.RadioState;

            bool result = playlistState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(RadioState));
            Assert.AreEqual(0, context.Controls.Count);
        }
    }
}
