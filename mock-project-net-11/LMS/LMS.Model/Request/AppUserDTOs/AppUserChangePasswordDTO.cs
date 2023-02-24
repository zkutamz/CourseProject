﻿using System.ComponentModel.DataAnnotations;

namespace LMS.Model.Request.AppUserDTOs
{
    public class AppUserChangePasswordDTO
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string OldPasswordHash { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(PasswordHash), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
