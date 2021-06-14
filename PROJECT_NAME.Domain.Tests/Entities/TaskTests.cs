using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECT_NAME.Domain.Entities;

namespace PROJECT_NAME.Domain.Tests.Entities
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void ShouldReturnTrue_WhenEntityIsValid()
        {
            Task t = new Task("Ola");
            t.Validate();
            Debug.Assert(t.Valid == true);
        }
    }
}