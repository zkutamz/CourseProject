using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface ICertificateRepository: IRepository<Certificate>
    {
        Task<PaginatedList<Certificate>> Search(string search, PagingRequest pagingRequest);
    }
}
