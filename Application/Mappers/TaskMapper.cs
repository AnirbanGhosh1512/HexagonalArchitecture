using System;
using Application.DTOs;
using Domain.Models;
using TaskToDo = Domain.Models.TaskToDo;

namespace Application.Mappers
{
    public static class TaskMapper
    {
        public static TaskDto ToDto(TaskToDo task)
        {
            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status.Value
            };
        }

        public static TaskToDo ToEntity(TaskDto dto)
        {
            var task = new TaskToDo(dto.Id, dto.Title, dto.Description);
            if (dto.Status == "Completed")
            {
                task.MarkCompleted();
            }
            return task;
        }
    }
}

