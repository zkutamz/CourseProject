using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request;
using LMS.Model.Request.CertificateDTOs;
using LMS.Model.Request.QuizSubmissionDTOs;
using LMS.Repository.Paging;
using LMS.Service.Services.CertificationSevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    public class CertificatesController : BaseController
    {
        private readonly ICertificationService _certificateService;
        private readonly ILogger _logger;
        public CertificatesController(ICertificationService certificateService, ILogger<CertificatesController> logger)
        {
            _certificateService = certificateService;
            _logger = logger;
        }
        /// <summary>
        /// Find certificate detail by keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pagingRequest"></param>
        /// <returns> Return paginated list of <see cref="CertificateDTO"/> </returns>
        [HttpGet]
        public async Task<IActionResult> Search(string keyword, [FromQuery] PagingRequest pagingRequest)
        {
            return HandleResult(await _certificateService.SearchAsync(keyword, pagingRequest));
        }
        /// <summary>
        /// Create certificate
        /// </summary>
        /// <param name="certificate"></param>
        /// <returns>true if success</returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpPost()]
        public async Task<IActionResult> CreateCertificate(CertificateCreateDTO certificate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return HandleResult(await _certificateService.CreateCertificateAsync(certificate), LmsAction.Add);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Create Certificate In API");
                throw new BadRequestException(ex.Message);
            }
        }
      
        /// <summary>
        ///  Edit existed certificate
        /// </summary>
        /// <param name="certificate"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task<IActionResult> EditCertificate(CertificateEditDTO certificate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return HandleResult(await _certificateService.EditCertificateAsync(certificate), LmsAction.Update);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Create Certificate In API");
                throw new BadRequestException(ex.Message);
            }
        }
        /// <summary>
        /// Get certificate detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCertificateDetail(int id)
        {
            var certificate = await _certificateService.GetCertificateDetailAsync(id);
            return HandleResult(certificate, LmsAction.Get);
        }
        /// <summary>
        /// Delete certificate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificate(int id)
        {
            return HandleResult(await _certificateService.DeleteCertificateAsync(id), LmsAction.Delete);
        }
        /// <summary>
        /// Return list certificate was filltered by category
        /// </summary>
        /// <param name="certificateCategoryId"></param>
        /// <returns> Status code 200 if success, otherwise return status code and error message</returns>

        [HttpGet("FilterByCategory/{certificateCategoryId}")]
        public async Task<IActionResult> FilterByCategory(int certificateCategoryId)
        {
            var result = await _certificateService.FilterByCategoryAsync(certificateCategoryId);
            return HandleResult(result, LmsAction.Get);
        }

        /// <summary>
        /// Return list certificate detail 
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns> Status code 200: list certificate infomation if success, otherwise return status code and error message</returns>
        [HttpGet("GetCertificatesOfStudent")]
        public async Task<IActionResult> GetCertificatesOfStudent([FromQuery] PagingRequest pagingRequest)
        {
            var result = await _certificateService.GetCertificatesDetailOfUserAsync(pagingRequest);
            return HandleResult(result, LmsAction.Get);
        }
        /// <summary>
        /// Get all question test of a certificate 
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <param name="certificateCategory"></param>
        /// <returns> Status code 200: list question test if success, otherwise return status code and error message</returns>
        [HttpGet("GetQuizzQuestionOfCertificate")]
        public async Task<IActionResult> GetQuizzQuestionOfCertificate([FromQuery] PagingRequest pagingRequest, int certificateId, int numberOfQuestion = 20)
        {
            var result = await _certificateService.GetQuizzQuestionForCertificateTestAsync(pagingRequest, certificateId, numberOfQuestion);
            return HandleResult(result, LmsAction.Get);
        }

        /// <summary>
        /// Handle answer and assign certificate if pass the quiz
        /// </summary>
        /// <param name="userAnswersDTO"></param>
        /// <returns>The result of quiz certificate</returns>
        [HttpPost("ProcessingResultAndCertification")]
        public async Task<IActionResult> ProcessingResultAndCertification(UserAnswersDTO userAnswersDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Data is invalid");
            }
            var result = await _certificateService.ProcessingResultAndCertificationAsync(userAnswersDTO);
            return HandleResult(result, LmsAction.Add);
        }
        /// <summary>
        /// Check and assign certificate for complete course
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="courseId"></param>
        /// <returns>True if success, otherwise reutrn false or errors message</returns>
        [HttpGet("CheckAndAssignCertificateForComplatedCourse")]
        public async Task<IActionResult> CheckAndAssignCertificateForComplatedCourse(int userId, int courseId)
        {
            var result = await _certificateService.CheckAndAssignCertificateForCompletedCourseAsync(userId, courseId);
            return HandleResult(result, LmsAction.Get);
        }
    }
}
