using System;

namespace TODO.Api.DTOs.TodoItemDtos;

public record CreateTodoItemDto(string Title, DateTime Date);