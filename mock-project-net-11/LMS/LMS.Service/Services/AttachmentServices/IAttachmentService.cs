using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Model.Request.AttachmentDTOs;
using LMS.Model.Response.AttachmentDTOs;

namespace LMS.Service.Services.AttachmentServices
{
    public interface IAttachmentService
    {
        Task<AttachmentDTO> CreateAttachmentAsync(AttachmentCreateDTO request);
    }
}
