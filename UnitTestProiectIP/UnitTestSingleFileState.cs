/**************************************************************************
 *                                                                        *
 *  File:        UnitTestSingleFileState.cs                               *
 *  Copyright:   (c) 2023, Ganea Luiza-Andreea                            *
 *  E-mail:      luiza-andreea.ganea@student.tuiasi.ro                    *
 *  Description: Clasa destinata testarii unitatilor clasei               *
 *              SingleFileState.cs                                        *
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
    public class UnitTestSingleFileState
    {
        /// <summary>
        /// Testarea starii curente (SingleFileTest)
        /// </summary>
        [TestMethod]
        public void HandleSingleFileStateTrue()
        {
            SingleFileState singleFileState = new SingleFileState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.SingleFileState;

            bool result = singleFileState.Handle(context);

            Assert.IsTrue(result);
            Assert.AreEqual(1, context.Controls.Count);
        }

        /// <summary>
        /// Testarea schimbarii starii, a tipului variabilei State a contextului, a numarului de controale din context
        /// </summary>
        [TestMethod]
        public void HandleSingleFileStateFalsePlaylistState()
        {
            SingleFileState singleFileState = new SingleFileState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.PlaylistState;

            bool result = singleFileState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(PlaylistState));
            Assert.AreEqual(0, context.Controls.Count);
        }

        /// <summary>
        /// Testarea schimbarii starii, a tipului variabilei State a contextului, a numarului de controale din context
        /// </summary>
        [TestMethod]
        public void HandleSingleFileStateFalseMakePlaylistState()
        {
            SingleFileState singleFileState = new SingleFileState();
            Context context = new Context();

            context.StateNumber = MP3PlayerStates.MakePlaylistState;

            bool result = singleFileState.Handle(context);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(context.State, typeof(MakePlaylistState));
            Assert.AreEqual(0, context.Controls.Count);
        }
    }
}
