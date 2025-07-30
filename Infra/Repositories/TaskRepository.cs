using System;
using Domain.Models;
using Domain.Interfaces;
using Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Infra.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskToDo?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            await _context.Tasks.FindAsync(id, cancellationToken);

        public async Task<IEnumerable<TaskToDo>> GetAllAsync() =>
            await _context.Tasks.ToListAsync();

        public async Task AddAsync(TaskToDo task, CancellationToken cancellationToken) =>
            await _context.Tasks.AddAsync(task, cancellationToken);

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

