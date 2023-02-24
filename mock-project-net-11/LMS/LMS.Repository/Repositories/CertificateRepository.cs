using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository.Repositories
{
    public class CertificateRepository : Repository<Certificate>, ICertificationRepository
    {
        public CertificateRepository(LMSApplicationContext context, ILogger<CertificateRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage)
            : base(context, logger, responseMessage)
        {

        }
        public async Task<PaginatedList<Certificate>> SearchAsync(string search, PagingRequest pagingRequest)
        {
            //table relationship: Certificate | CertificateCategory

            var query = from c in Context.Certificates
                        join cc in Context.CertificateCategories
                        on c.CertificateCategoryId equals cc.Id
                        where c.IsDelete == false
                        && cc.IsDelete == false
                        select new { c, cc };

            //filter || search by CertificateName and CertficateCategoryName
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.c.CertificateName.Contains(search)
              || x.cc.CertificateCatgoryName.Contains(search));
            }
            return await PaginatedList<Certificate>.ToPaginatedListAsync(query.Select(x => x.c),
                   pagingRequest.PageNumber,
                   pagingRequest.PageSize);
        }

        public async Task<PaginatedList<Certificate>> GetCertificatesForStudentAsync(PagingRequest pagingRequest, int userId)
        {
            var certificatesCurrentUser = from u in Context.AppUsers
                                          join uc in Context.UserCertificates
                                          on u.Id equals uc.UserId
                                          join c in Context.Certificates
                                          on uc.CertificateId equals c.Id
                                          where u.Id == userId
                                          && c.IsDelete == false
                                          && uc.IsDelete == false
                                          select c;

            return await PaginatedList<Certificate>.ToPaginatedListAsync(certificatesCurrentUser, pagingRequest.PageNumber, pagingRequest.PageSize);
        }

        public async Task<PaginatedList<QuizQuestion>> GetQuizzForCertificateTestAsync(PagingRequest pagingRequest, int certificateId, int numberOfQuestion)
        {
            var quizQuestions = (from c in Context.Certificates
                                 join qc in Context.QuizzCertificates
                                 on c.Id equals qc.CertificateId
                                 join q in Context.Quizzes
                                 on qc.QuizzId equals q.Id
                                 join qq in Context.QuizQuestions
                                 on q.Id equals qq.QuizId
                                 where qq.IsDelete == false
                                 && c.IsDelete == false
                                 && qc.IsDelete == false
                                 && q.IsDelete == false
                                 && c.Id == certificateId
                                 select qq).Take(numberOfQuestion);

            return await PaginatedList<QuizQuestion>.ToPaginatedListAsync(quizQuestions, pagingRequest.PageNumber, pagingRequest.PageSize);
        }

        public IQueryable<QuizSubmission> GetCertificateResultSubmition(int certificateId, int currentId)
        {
            var certificateResult = from c in Context.Certificates
                                    join qc in Context.QuizzCertificates
                                    on c.Id equals qc.CertificateId
                                    join q in Context.Quizzes
                                    on qc.QuizzId equals q.Id
                                    join qs in Context.QuizSubmissions
                                    on q.Id equals qs.QuizId
                                    where qs.IsDelete == false
                                    && c.IsDelete == false
                                    && qc.IsDelete == false
                                    && q.IsDelete == false
                                    && qs.IsDelete==false
                                    && qs.IsPassed==true
                                    && c.Id == certificateId
                                    && qs.UserId == currentId
                                    select qs;
            return certificateResult;
        }

        public async Task<PaginatedList<Certificate>> GetCertificateResultOfCurrentUser(PagingRequest pagingRequest, int userId)
        {
            var certificates = from u in Context.AppUsers
                               join us in Context.UserCertificates
                               on u.Id equals us.UserId
                               join c in Context.Certificates
                               on us.CertificateId equals c.Id
                               where u.Id == userId
                               && us.IsDelete == false
                               && c.IsDelete == false
                               select c;

            return await PaginatedList<Certificate>.ToPaginatedListAsync(certificates, pagingRequest.PageNumber, pagingRequest.PageSize); ;
        }

        public async Task<UserCertificate> GetUserCertificate(int userId, int certificateId)
        {
            var userCertificate =await (from uc in Context.UserCertificates
                               join c in Context.Certificates
                               on uc.CertificateId equals c.Id
                               where uc.UserId == userId
                               select uc).FirstOrDefaultAsync();
            return userCertificate;
        }


    }
}
