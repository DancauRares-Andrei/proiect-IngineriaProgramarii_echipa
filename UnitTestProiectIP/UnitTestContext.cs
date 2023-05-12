/**************************************************************************
 *                                                                        *
 *  File:        UnitTestContext.cs                                       *
 *  Copyright:   (c) 2023, Ganea Luiza-Andreea                            *
 *  E-mail:      luiza-andreea.ganea@student.tuiasi.ro                    *
 *  Description: Clasa destinata testarii unitatilor clasei               *
 *              Context.cs                                                *
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
    /// Clasa destinata testarii unitatilor clasei Context.cs
    /// </summary>
    [TestClass]
    public class UnitTestContext
    {
        /// <summary>
        /// Testarea metodei Request din clasa Context.cs (testarea numarului de controale din context)
        /// </summary>
        [TestMethod]
        public void TestRequest()
        {
            Context context = new Context();
            
            context.Request();
            Assert.AreEqual(0, context.Controls.Count);
        }
    }
}
