using System;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappers;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskToDo?> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<TaskToDo>> GetAllTasksAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TaskToDo> AddTaskAsync(TaskDto dto, CancellationToken cancellationToken)
        {
            var task = new TaskToDo(Guid.NewGuid(), dto.Title, dto.Description);
            await _repository.AddAsync(task, cancellationToken);
            await _repository.SaveChangesAsync();
            return task;
        }
    }
}

