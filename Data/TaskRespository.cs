using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolClassCompass.Data
{
    public class TaskRepository
    {
        public Task<List<TaskItem>> ListAsync()
        {
            return Task.FromResult(new List<TaskItem>());
        }

        public Task SaveItemAsync(TaskItem item)
        {
            return Task.CompletedTask;
        }

        public Task DeleteItemAsync(TaskItem item)
        {
            return Task.CompletedTask;
        }

        public Task DropTableAsync()
        {
            return Task.CompletedTask;
        }
    }
}