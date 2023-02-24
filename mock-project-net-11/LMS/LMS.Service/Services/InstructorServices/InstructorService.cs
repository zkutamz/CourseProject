using AutoMapper;
using LMS.Model.Response.InstructorDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using LMS.Service.Services.UserSubscriberServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Service.Services.InstructorServices
{
    public class InstructorService : IInstructorService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserSubscriberService _userSubscriberService;

        public InstructorService(IUnitOfWork unitOfWork, IMapper mapper, IUserSubscriberService userSubscriberService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userSubscriberService = userSubscriberService;
        }

        public async Task<int> TotalCourseReviewOfAnInstructorAsync(int instructorId)
        {
            var totalCourseReviewOfAnInstructor = await _unitOfWork.AppUserRepository.GetTotalReviewsAsync(instructorId);
            return totalCourseReviewOfAnInstructor;
        }

        public async Task<int> TotalSubcriptionOfAnInstructorAsync(int instructorId)
        {
            var totalSubCriptionOfAnInstructor = await _userSubscriberService.GetTotalSubcriber(instructorId);
            return totalSubCriptionOfAnInstructor;
        }

        public async Task<int> TotalEnrollStudentsOfAnInstructorAsync(int instructorId)
        {
            PagingRequest temp = new PagingRequest();

            var totalStudentEnrollInstructor = await _unitOfWork.CourseRepository.GetTotalStudentStudiedToInstructor(instructorId, temp);
            return totalStudentEnrollInstructor.Count();
        }

        public async Task<int> ToTalCoursesOfAnInstructorAsync(int instructorId)
        {
            var totalCourseOfAnInstructor = await _unitOfWork.CourseRepository.GetAllCoursesOfAnInstructorWithoutPagingAsync(instructorId);
            return totalCourseOfAnInstructor.Count;
        }

        public async Task<List<InstructorPopularDTO>> GetPopularInstructor()
        {
            var popularInstructors = _mapper.Map<List<AppUser>, List<InstructorPopularDTO>>(_unitOfWork.AppUserRepository.GetListPopularInstructor());
            foreach (var item in popularInstructors)
            {
                item.TotalStudent = await TotalEnrollStudentsOfAnInstructorAsync(item.Id);
                item.TotalCourse = await ToTalCoursesOfAnInstructorAsync(item.Id);
            }
            return popularInstructors;
        }
    }
}
