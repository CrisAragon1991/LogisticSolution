﻿using LogisticSolution.Models;

namespace LogisticSolution.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public RoleType Role { get; set; }
    }
}
