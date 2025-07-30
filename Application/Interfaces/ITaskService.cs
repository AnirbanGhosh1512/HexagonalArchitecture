using System;
using Application.DTOs;
using Domain.Models;

namespace Application.Interfaces
{
	public interface ITaskService
	{
        Task<TaskToDo?> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<TaskToDo>> GetAllTasksAsync();
        Task<TaskToDo> AddTaskAsync(TaskDto dto, CancellationToken cancellationToken);
    }
}

