using TIMSBack.Application.Common.Mappings;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
