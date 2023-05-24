/**************************************************************************
 *                                                                        *
 *  File:        UnitTestMakePlaylistState.cs                             *
 *  Copyright:   (c) 2023, Ganea Luiza-Andreea                            *
 *  E-mail:      luiza-andreea.ganea@student.tuiasi.ro                    *
 *  Description: Clasa destinata testarii unitatilor clasei               *
 *              MakePlaylistState.cs                                      *
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
    /// <summary>
    /// Clasa destinata testarii unitatilor clasei UnitTestMakePlaylistState.cs
    /// </summary>
    [TestClass]
    public class UnitTestMakePlaylistState
    {
        /// <summary>
        /// Testarea starii curente (MakePlaylistState)
        /// </summary>
        [TestMethod]
        public void HandleMakePlaylistStateTrue()
        {
            MakePlaylistState makePlaylistState = new MakePlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.MakePlaylistState;

            bool result = makePlaylistState.Handle(context);

            Assert.IsTrue(result);
            Assert.AreEqual(3, context.Controls.Count);
        }




        //Testarea schimbarii starii curente:

        /// <summary>
        /// Testarea trecerii din starea curenta in starea SingleFileState. 
        /// Testarea tipului variabilei State a contextului
        /// Testarea numarului de controale din context
        /// </summary>
        [TestMethod]
        public void HandleMakePlaylistStateFalseSingleFileState()
        {
            MakePlaylistState makePlaylistState = new MakePlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.SingleFileState;

            bool result = makePlaylistState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(SingleFileState));
            Assert.AreEqual(0, context.Controls.Count);
        }

        /// <summary>
        /// Testarea trecerii din starea curenta in starea PlaylistState. 
        /// Testarea tipului variabilei State a contextului
        /// Testarea numarului de controale din context
        /// </summary>
        [TestMethod]
        public void HandleMakePlaylistStateFalsePlaylistState()
        {
            MakePlaylistState makePlaylistState = new MakePlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.PlaylistState;

            bool result = makePlaylistState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(PlaylistState));
            Assert.AreEqual(0, context.Controls.Count);
        }

        /// <summary>
        /// Testarea trecerii din starea curenta in starea RadioState. 
        /// Testarea tipului variabilei State a contextului
        /// Testarea numarului de controale din context
        /// </summary>
        [TestMethod]
        public void HandleMakePlaylistStateFalseRadioState()
        {
            MakePlaylistState makePlaylistState = new MakePlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.RadioState;

            bool result = makePlaylistState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(RadioState));
            Assert.AreEqual(0, context.Controls.Count);
        }

        /// <summary>
        /// Testarea trecerii din starea curenta in starea EditPlaylistState. 
        /// Testarea tipului variabilei State a contextului
        /// Testarea numarului de controale din context
        /// </summary>
        [TestMethod]
        public void HandleMakePlaylistStateFalseEditPlaylistState()
        {
            MakePlaylistState makePlaylistState = new MakePlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.EditPlaylistState;

            bool result = makePlaylistState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(EditPlaylistState));
            Assert.AreEqual(0, context.Controls.Count);
        }
    }
}
