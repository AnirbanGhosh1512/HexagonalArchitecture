using System;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskToDo?> GetByIdAsync(Guid id);
        Task<IEnumerable<TaskToDo>> GetAllAsync();
        Task AddAsync(TaskToDo task);
        Task SaveChangesAsync();
        Task UpdateAsync(TaskToDo task);
        Task DeleteAsync(Guid id);
    }

}

