using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Context;
using TaskManager.Data.Models;
using Task = TaskManager.Data.Models.Task;


namespace TaskManager.Data.Repositories.Tasks
{
    public class TaskRepository : ITaskRepository
    {
        public readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task CreateTask(Task taskCreated)
        {
            try
            {
                _context.Tasks.Add(taskCreated);
                _context.SaveChanges();

                return taskCreated;
            }
            catch (Exception)
            {
                return new Task();
            }

        }

        public Task DeleteTask(Task taskDelete)
        {
            try
            {
                _context.Remove(taskDelete);
                _context.SaveChanges();

                return taskDelete;
            }
            catch (Exception)
            {
                return new Task();
            }
        }

        public List<Task> GetAllTask()
        {
            try
            {
                return _context.Tasks
                        .Include(ca => ca.Category)
                        .ToList();
            }
            catch (Exception)
            {
                return new List<Task>();
            }

        }

        public Task GetTaskById(int taskId)
        {
            try
            {
                return _context.Tasks
                    .Include(ca => ca.Category)
                    .Where(w => w.TaskId == taskId).FirstOrDefault();
            }
            catch (Exception)
            {
                return new Task();
            }
        }

        public Task UpdateTask(Task taskUpdated)
        {
            try
            {
                var existingEntry = _context.ChangeTracker.Entries<Task>().FirstOrDefault(e => e.Entity.TaskId == taskUpdated.TaskId);

                if (existingEntry != null)
                {
                    existingEntry.CurrentValues.SetValues(taskUpdated);
                }
                else
                {
                    _context.Tasks.Attach(taskUpdated);
                    _context.Entry(taskUpdated).State = EntityState.Modified;
                }

                _context.SaveChanges();
                return taskUpdated;

            }
            catch (Exception)
            {
                return new Task();
            }
        }

        public Task AsignedCategory(Task taskAsigned)
        {
            try
            {
                var taskCurrent = _context.Tasks.FirstOrDefault(o => o.TaskId == taskAsigned.TaskId);

                if (taskCurrent != null)
                {
                    taskCurrent.Category = taskAsigned.Category;
                    _context.SaveChanges();
                }

                return taskAsigned;
            }
            catch (Exception)
            {
                return new Task();
            }
        }
    }
}
