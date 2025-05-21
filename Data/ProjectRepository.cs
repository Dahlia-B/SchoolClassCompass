using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolClassCompass.Models;

namespace SchoolClassCompass.Data
{
    public class ProjectRepository
    {
        public Task<List<Project>> ListAsync()
        {
            return Task.FromResult(new List<Project>());
        }

        public Task<Project> GetAsync(int id)
        {
            return Task.FromResult(new Project());
        }

        public Task SaveItemAsync(Project project)
        {
            return Task.CompletedTask;
        }

        public Task DeleteItemAsync(Project project)
        {
            return Task.CompletedTask;
        }

        public Task DropTableAsync()
        {
            return Task.CompletedTask;
        }
    }
}