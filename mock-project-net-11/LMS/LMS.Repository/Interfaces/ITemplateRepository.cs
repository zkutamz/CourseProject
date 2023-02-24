using LMS.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface ITemplateRepository : IRepository<Template>
    {
        Task<Template> GetTemplateBaseOnStatus(bool status);
    }
}
