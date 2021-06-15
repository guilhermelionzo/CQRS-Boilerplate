using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECT_NAME.Domain.Entities;

namespace PROJECT_NAME.Domain.Tests.Entities
{
    [TestClass]
    public class EntityTest
    {

        [TestMethod]
        public void NewObject_ShouldHaveAnValidGuid()
        {
            TestClass obj = new TestClass();
            Debug.Assert(obj.Id != Guid.Empty);
        }

        [TestMethod]
        public void TwoDifferentObjects_ShouldBeDifferent()
        {
            TestClass obj1 = new TestClass();
            TestClass obj2 = new TestClass();
            Debug.Assert(!obj1.Equals(obj2));
        }
    }

    internal class TestClass : Entity { }
}