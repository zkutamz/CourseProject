using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface ICertificationRepository : IRepository<Certificate>
    {
        /// <summary>
        /// Search by name, number, full name and category
        /// </summary>
        /// <param name="search"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<PaginatedList<Certificate>> SearchAsync(string search, PagingRequest pagingRequest);
        /// <summary>
        /// Get certificate data of student 
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <param name="userId"></param>
        /// <returns>Paginate  certificate</returns>
        Task<PaginatedList<Certificate>> GetCertificatesForStudentAsync(PagingRequest pagingRequest, int userId);
        /// <summary>
        /// Get all quiz of a certificate base on certificate category
        /// </summary>
        /// <param name="categoryCertificate"></param>
        /// <returns>Paginated of quiz question</returns>
        Task<PaginatedList<QuizQuestion>> GetQuizzForCertificateTestAsync(PagingRequest pagingRequest, int categoryCertificate, int numberOfQuestion);
        /// <summary>
        /// Get cerificate result base on certificate id
        /// </summary>
        /// <param name="certificateId"></param>
        /// <returns>Paing of list certification result</returns>
        IQueryable<QuizSubmission> GetCertificateResultSubmition(int certificateId, int currentUserId);
        /// <summary>
        /// Get certification detail of current user
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <param name="userId"></param>
        /// <returns> Get certification result of current user </returns>
        Task<PaginatedList<Certificate>> GetCertificateResultOfCurrentUser(PagingRequest pagingRequest, int userId);
        /// <summary>
        /// Get data from user certificate table
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="certificateId"></param>
        /// <returns>List of user certificate</returns>
        Task<UserCertificate> GetUserCertificate(int userId, int certificateId);
    }
}
