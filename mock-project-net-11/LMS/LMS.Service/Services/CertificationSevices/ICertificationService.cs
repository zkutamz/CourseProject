using LMS.Model.Request;
using LMS.Model.Request.CertificateDTOs;
using LMS.Model.Request.QuizSubmissionDTOs;
using LMS.Model.Response.CertificateDTOs;
using LMS.Model.Response.QuizQuestionDTOs;
using LMS.Model.Response.QuizSubmissionDTOs;
using LMS.Model.Response.UserCertigicateDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Threading.Tasks;

namespace LMS.Service.Services.CertificationSevices
{
    public interface ICertificationService
    {
        /// <summary>
        /// Get detail certificate 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>CertificateDetailDTO</returns>
        Task<CertificateDetailDTO> GetCertificateDetailAsync(int id);
        /// <summary>
        /// Delete certificate
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if success</returns>
        Task<bool> DeleteCertificateAsync(int id);
        /// <summary>
        /// Search certificate by name and category
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pagingRequest"></param>
        /// <returns>List of <see cref="CertificateDTO"/></returns>
        Task<PaginatedList<CertificateDTO>> SearchAsync(string keyword, PagingRequest pagingRequest);
        /// <summary>
        /// Create new certificate 
        /// </summary>
        /// <param name="certificateCreateDTO"></param>
        /// <returns>Return true if success, otherwise throw error message</returns>
        Task<bool> CreateCertificateAsync(CertificateCreateDTO certificateCreateDTO);
        /// <summary>
        /// Hard delete certificate from database
        /// </summary>
        /// <param name="certificateEditDTO"></param>
        /// <returns>Return true if success otherwise rerurn throw error message</returns>
        Task<bool> HardDeleteCertificateAsync(int certificateId);
        /// <summary>
        /// Edit existed certificate 
        /// </summary>
        /// <param name="certificateEditDTO"></param>
        /// <returns>Return true if success otherwise rerurn throw error message</returns>
        Task<bool> EditCertificateAsync(CertificateEditDTO certificateEditDTO);
        /// <summary>
        /// Filter certificates by category
        /// </summary>
        /// <param name="certificateCategoryId"></param>
        /// <returns>PaginateList of CertificateDTO</returns>
        Task<PaginatedList<CertificateDTO>> FilterByCategoryAsync(int certificateCategoryId);
        /// <summary>
        /// Get all quizz question of cerificate base on certificate category
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <param name="certificateCatetgory"> Pag </param>
        /// <returns>PagingResult of QuizzQuestionDetailDTO</returns>
        Task<PagingResult<QuizQuestionDTO>> GetQuizzQuestionForCertificateTestAsync(PagingRequest pagingRequest, int certificateCatetgory, int numberOfQuestion);
        /// <summary>
        /// Get certificates data of current student
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns>PaginateResult of CertificateDetailDTO</returns>
        Task<PagingResult<MyCertificateModel>> GetCertificatesDetailOfUserAsync(PagingRequest pagingRequest);
        /// <summary>
        /// Assign  certificate for user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="certificate"></param>
        /// <returns>Return true if success, ortherwise throw error message</returns>
        Task<AssignToCertificateResult> AssignCertificateToUseAsync(AppUser user, Certificate certificate);
        /// <summary>
        /// Check answer submission and assign certificate
        /// </summary>
        /// <param name="userAnswersDTO"></param>
        /// <returns></returns>
        Task<QuizzCertificateResultDTO> ProcessingResultAndCertificationAsync(UserAnswersDTO userAnswersDTO);
        /// <summary>
        /// Check whether the course is completed or not
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="courseId"></param>
        /// <returns>Return true if course completed, otherwise return false</returns>
        Task<bool> CheckAndAssignCertificateForCompletedCourseAsync(int userId, int courseId);

    }
}
