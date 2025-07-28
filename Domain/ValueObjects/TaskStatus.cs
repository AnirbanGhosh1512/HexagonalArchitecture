using System;
using Microsoft.EntityFrameworkCore;

namespace Domain.ValueObjects
{
    [Owned]
    public class TaskStatus
	{
        public string Value { get; private set; }

        private TaskStatus() { } // EF needs a parameterless ctor

        private TaskStatus(string value) => Value = value;

        public static TaskStatus Pending() => new TaskStatus("Pending");
        public static TaskStatus Completed() => new TaskStatus("Completed");

        public override string ToString() => Value;
    }
}


