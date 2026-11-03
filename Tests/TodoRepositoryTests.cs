using CSharpPracticum.Tasks.Level3;
using Xunit;

namespace CSharpPracticum.Tests;

public sealed class TodoRepositoryTests
{
    [Fact]
    public void TaskService_PersistsCreateCompleteAndDeleteOperations()
    {
        string filePath = Path.Combine(Path.GetTempPath(), $"tasks-{Guid.NewGuid():N}.json");
        try
        {
            TaskService service = new(new TaskRepository(filePath));
            TaskItem added = service.Add("Проверить сохранение");
            Assert.True(service.MarkAsDone(added.Id));

            TaskService reloadedService = new(new TaskRepository(filePath));
            TaskItem persisted = Assert.Single(reloadedService.GetAll());
            Assert.Equal(added.Id, persisted.Id);
            Assert.True(persisted.IsDone);

            Assert.True(reloadedService.Delete(persisted.Id));
            Assert.Empty(new TaskRepository(filePath).GetAll());
        }
        finally
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
