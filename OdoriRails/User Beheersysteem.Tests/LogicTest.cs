// <copyright file="LogicTest.cs" company="Hewlett-Packard">Copyright © Hewlett-Packard 2017</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using User_Beheersysteem;

namespace User_Beheersysteem.Tests
{
    /// <summary>This class contains parameterized unit tests for Logic</summary>
    [PexClass(typeof(Logic))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class LogicTest
    {
        /// <summary>Test stub for GetAllUsersFromDatabase()</summary>
        [PexMethod]
        internal void GetAllUsersFromDatabaseTest([PexAssumeUnderTest]Logic target)
        {
            target.GetAllUsersFromDatabase();
            // TODO: add assertions to method LogicTest.GetAllUsersFromDatabaseTest(Logic)
        }
    }
}
