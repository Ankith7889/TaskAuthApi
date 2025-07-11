﻿using System.ComponentModel.DataAnnotations;

namespace TaskAuthApi.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }


        public string? UserId { get; set; }
        public AppUser? User { get; set; }
    }
}
