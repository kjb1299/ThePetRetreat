﻿using NUnit.Framework;

namespace ThePetRetreatTests
{
    [TestFixture]
    public class BaseTests
    {
        [Test]
        public void BaseTest()
        {
            Assert.That(1 == 1, "Pass condition");
        }
    }
}