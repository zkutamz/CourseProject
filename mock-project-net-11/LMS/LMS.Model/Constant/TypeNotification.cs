using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Constant
{
    public enum TypeNotification
    {
        RegisterCourse,     // Student or instructor register the course.
        CommentCourse,      // Student or instructor comment the course.
        ReviewCourse,       // Student or instructor review the course.       
        UpdateCourse,       // Instructor update the course.
        DeleteCourse,       // Instructor delete the course.

        LikeComment,        // Student like comment of instructor in the course.
        ReplyComment,       // Student or instructor reply comment in the video.

        ReceiveCertificate, // Student completed Course.

        UploadVideo,        // Student or instructor approved upload video.
        ActivedMembership,  // Student actived membership.
    }
}
