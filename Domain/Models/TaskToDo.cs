using System;
using TaskStatus = Domain.ValueObjects.TaskStatus;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{

    public class TaskToDo
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public TaskStatus Status { get; private set; }

        public TaskToDo(Guid id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = TaskStatus.Pending();
        }

        public void MarkCompleted()
        {
            Status = TaskStatus.Completed();
        }
    }


}

