using LMS.Model.Response.AppUserDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.InstructorDTOs
{
    public class InstructorPopularDTO:AppUserBasicDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Headline { get; set; }
        public string ProfileImageUrl { get; set; }
        public string ProfileLink { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }
        public string YoutubeLink { get; set; }
        //Total student enrolled instructor
        public int TotalStudent { get; set; }
        //Total course of instructor
        public int TotalCourse { get; set; }
    }
}
