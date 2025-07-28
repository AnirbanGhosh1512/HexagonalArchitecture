using System;
using Domain.Models;
using Domain.Interfaces;
using Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskToDo?> GetByIdAsync(Guid id) =>
            await _context.Tasks.FindAsync(id);

        public async Task<IEnumerable<TaskToDo>> GetAllAsync() =>
            await _context.Tasks.ToListAsync();

        public async Task AddAsync(TaskToDo task) =>
            await _context.Tasks.AddAsync(task);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();

        public Task UpdateAsync(TaskToDo task)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }

}

