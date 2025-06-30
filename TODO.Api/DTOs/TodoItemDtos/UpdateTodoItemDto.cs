using System;

namespace TODO.Api.DTOs.TodoItemDtos;

public class UpdateTodoItemDto
{
    public UpdateTodoItemDto()
    {}
    public UpdateTodoItemDto(Guid id, string title, DateTime date)
    {
        Id = id;
        Title = title;
        Date = date;
    }

    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
