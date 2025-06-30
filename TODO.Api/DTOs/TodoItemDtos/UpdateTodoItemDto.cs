using System;

namespace TODO.Api.DTOs.TodoItemDtos;

public record UpdateTodoItemDto(Guid Id, string Title, DateTime Date);