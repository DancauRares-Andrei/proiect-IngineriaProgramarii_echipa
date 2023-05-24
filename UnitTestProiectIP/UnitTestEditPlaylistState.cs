/**************************************************************************
 *                                                                        *
 *  File:        UnitTestEditPlaylistState.cs                             *
 *  Copyright:   (c) 2023, Ganea Luiza-Andreea                            *
 *  E-mail:      luiza-andreea.ganea@student.tuiasi.ro                    *
 *  Description: Clasa destinata testarii unitatilor clasei               *
 *              EditPlaylistState.cs                                      *
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
    public class UnitTestEditPlaylistState
    {
        /// <summary>
        /// Testarea starii curente (EditPlaylistState)
        /// </summary>
        [TestMethod]
        public void HandleEditPlaylistStateTrue()
        {
            EditPlaylistState editPlaylistState = new EditPlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.EditPlaylistState;

            bool result = editPlaylistState.Handle(context);

            Assert.IsTrue(result);
            Assert.AreEqual(5, context.Controls.Count);
        }


        //Testarea schimbarii starii curente:

        /// <summary>
        /// Testarea trecerii din starea curenta in starea PlaylistState. 
        /// Testarea tipului variabilei State a contextului
        /// Testarea numarului de controale din context
        /// </summary>
        [TestMethod]
        public void HandleEditPlaylistStateFalsePlaylistState()
        {
            EditPlaylistState editPlaylistState = new EditPlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.PlaylistState;

            bool result = editPlaylistState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(PlaylistState));
            Assert.AreEqual(0, context.Controls.Count);
        }

        /// <summary>
        /// Testarea trecerii din starea curenta in starea MakePlaylistState. 
        /// Testarea tipului variabilei State a contextului
        /// Testarea numarului de controale din context
        /// </summary>
        [TestMethod]
        public void HandleEditPlaylistStateFalseMakePlaylistState()
        {
            EditPlaylistState editPlaylistState = new EditPlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.MakePlaylistState;

            bool result = editPlaylistState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(MakePlaylistState));
            Assert.AreEqual(0, context.Controls.Count);
        }

        /// <summary>
        /// Testarea trecerii din starea curenta in starea RadioState. 
        /// Testarea tipului variabilei State a contextului
        /// Testarea numarului de controale din context
        /// </summary>
        [TestMethod]
        public void HandleEditPlaylistStateFalseRadioState()
        {
            EditPlaylistState editPlaylistState = new EditPlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.RadioState;

            bool result = editPlaylistState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(RadioState));
            Assert.AreEqual(0, context.Controls.Count);
        }

        /// <summary>
        /// Testarea trecerii din starea curenta in starea SingleFileState. 
        /// Testarea tipului variabilei State a contextului
        /// Testarea numarului de controale din context
        /// </summary>
        [TestMethod]
        public void HandleEditPlaylistStateFalseSingleFileState()
        {
            EditPlaylistState editPlaylistState = new EditPlaylistState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.SingleFileState;

            bool result = editPlaylistState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(SingleFileState));
            Assert.AreEqual(0, context.Controls.Count);
        }
    }
}
