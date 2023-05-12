/**************************************************************************
 *                                                                        *
 *  File:        UnitTestIState.cs                                        *
 *  Copyright:   (c) 2023, Ganea Luiza-Andreea                            *
 *  E-mail:      luiza-andreea.ganea@student.tuiasi.ro                    *
 *  Description: Clasa destinata testarii unitatilor proiectului.         *
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
using System;

namespace UnitTestProiectIP
{
    [TestClass]
    public class UnitTestIState
    {

        /// <summary>
        /// Testarea starii curente
        /// </summary>
        [TestMethod]
        public void HandleMakePlaylistStateTrue()
        {
            MakePlaylistState makePlaylistState = new MakePlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.MakePlaylistState;

            bool result = makePlaylistState.Handle(context);

            Assert.IsTrue(result);
            // Assert.AreEqual(context.Controls.Count, 3);
        }

        [TestMethod]
        public void HandlePlaylistStateTrue()
        {
            PlaylistState playlistState = new PlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.PlaylistState;

            bool result = playlistState.Handle(context);

            Assert.IsTrue(result);
            // Assert.AreEqual(context.Controls.Count, 4);
        }

        [TestMethod]
        public void HandleSingleFileStateTrue()
        {
            SingleFileState singleFileState = new SingleFileState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.SingleFileState;

            bool result = singleFileState.Handle(context);

            Assert.IsTrue(result);
            // Assert.AreEqual(context.Controls.Count, 4);
        }


        /// <summary>
        /// Testarea schimbarii starii (si a tipului variabilei State a contextului)
        /// </summary>

        //pentu metoda MakePlaylistState
        [TestMethod]
        public void HandlMakePlaylistStateFalseSingleFileState()
        {
            MakePlaylistState makePlaylistState = new MakePlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.SingleFileState;

            bool result = makePlaylistState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(SingleFileState));
            // Assert.AreEqual(context.Controls.Count, 3);
        }

        [TestMethod]
        public void HandlMakePlaylistStateFalsePlaylistState()
        {
            MakePlaylistState makePlaylistState = new MakePlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.PlaylistState;

            bool result = makePlaylistState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(PlaylistState));
            // Assert.AreEqual(context.Controls.Count, 3);
        }

        //pentu metoda MakePlaylistState
        [TestMethod]
        public void HandlePlaylistStateFalseSingleFileState()
        {
            PlaylistState playlistState = new PlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.SingleFileState;

            bool result = playlistState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(SingleFileState));
            // Assert.AreEqual(context.Controls.Count, 4);
        }

        [TestMethod]
        public void HandlePlaylistStateFalseMakePlaylistState()
        {
            PlaylistState playlistState = new PlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.MakePlaylistState;

            bool result = playlistState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(MakePlaylistState));
            // Assert.AreEqual(context.Controls.Count, 4);
        }

        //pentu metoda SingleFileState
        [TestMethod]
        public void HandleSingleFileStateFalsePlaylistState()
        {
            SingleFileState singleFileState = new SingleFileState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.PlaylistState;

            bool result = singleFileState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(PlaylistState));
            // Assert.AreEqual(context.Controls.Count, 4);
        }

        [TestMethod]
        public void HandleSingleFileStateFalseMakePlaylistState()
        {
            SingleFileState singleFileState = new SingleFileState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.MakePlaylistState;

            bool result = singleFileState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(MakePlaylistState));
            // Assert.AreEqual(context.Controls.Count, 4);
        }

    }
}
