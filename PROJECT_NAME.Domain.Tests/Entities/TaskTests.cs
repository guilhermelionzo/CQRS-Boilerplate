using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using PROJECT_NAME.Domain.Entities;
using PROJECT_NAME.Domain.ExternalServices;

namespace PROJECT_NAME.Domain.Tests.Entities
{
    [TestClass]
    public class TaskTests
    {
        Task validTask;
        Task invalidTask;
        private const string _validTaskName = "Valid Task Name";
        private readonly IDateTimeProvider _dateTimeProvider = Substitute.For<IDateTimeProvider>();

        public TaskTests()
        {
            invalidTask = new Task();
            validTask = new Task(_validTaskName);

            _dateTimeProvider.DateTimeNow.Returns(new DateTime(2021, 03, 10));
        }

        [TestMethod]
        public void ShouldReturnTrue_WhenTaskIsValid()
        {
            validTask.Validate();
            Debug.Assert(validTask.Valid);
        }

        [TestMethod]
        public void ShouldReturnFalse_WhenTaskIsInvalid()
        {
            invalidTask.Validate();
            Debug.Assert(!invalidTask.Valid);
        }

        [TestMethod]
        public void StatusShouldBeStarted_WhenTaskIsStared()
        {
            var task = new Task(_validTaskName);
            task.Start(_dateTimeProvider.DateTimeNow);
            Debug.Assert(task.Status == ETaskStatus.Started);
        }

        [TestMethod]
        public void StatusShouldBeStopped_WhenTaskIsStopped()
        {
            var task = new Task(_validTaskName);
            task.Stop();
            Debug.Assert(task.Status == ETaskStatus.Stopped);
        }

        [TestMethod]
        public void StatusShouldBeResumed_WhenStoppedTaskIsResumed()
        {
            var task = new Task(_validTaskName);
            task.Resume();
            Debug.Assert(task.Status == ETaskStatus.Resumed);
        }

        [TestMethod]
        public void StatusShouldBeFinished_WhenTaskIsFinished()
        {
            var task = new Task(_validTaskName);
            task.Finish(_dateTimeProvider.DateTimeNow);
            Debug.Assert(task.Status == ETaskStatus.Finished);
        }
    }
}