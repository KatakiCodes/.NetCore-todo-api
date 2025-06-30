using System;

namespace TODO.Api.DTOs.TodoItemDtos;

public class CreateTodoItemDto
{
    public CreateTodoItemDto()
    {}
    public CreateTodoItemDto(string title, DateTime date)
    {
        Title = title;
        Date = date;
    }

    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
