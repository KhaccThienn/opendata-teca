﻿namespace Application.Features.TodoItems.DTOs
{
    public class TodoItemBriefDto
    {
        public int     Id     { get; init; }
        public int     ListId { get; init; }
        public string? Title  { get; init; }
        public bool    Done   { get; init; }
    }
}
