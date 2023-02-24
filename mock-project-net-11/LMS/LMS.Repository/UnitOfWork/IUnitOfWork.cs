using LMS.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace LMS.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICourseRepository CourseRepository { get; }
        IAppUserRepository AppUserRepository { get; }
        INotificationRepository NotificationRepository { get; }
        ICourseCommentRepository CourseCommentRepository { get; }
        ICourseFavoriteRepository CourseFavoriteRepository { get; }
        IAssignmentRepository AssignmentRepository { get; }
        IAssignmentSubmissionRepository AssignmentSubmissionRepository { get; }
        IQuizRepository QuizRepository { get; }
        ISectionRepository SectionRepository { get; }
        IChatRepository ChatRepository { get; }
        IChatUserRepository ChatUserRepository { get; }
        ILessonRepository LessonRepository { get; }
        ILessonCompletionRepository LessonCompletionRepository { get; }
        ICertificationRepository CertificationRepository { get; }
        IFeedbackRepository FeedbackRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IQuizQuestionRepository QuizQuestionRepository { get; }
        IQuizSubmissionRepository QuizSubmissionRepository { get; }
        ICertificateCategoryRepository CertificateCategoryRepository { get; }
        IUserSubcriberRepository UserSubcriberRepository { get; }
        INotificationSettingRepository NotificationSettingRepository { get; }
        IPrivacySettingRepository PrivacySettingRepository { get; }
        IBillingAddressRepository BillingAddressRepository { get; }
        IVisitorRepository VisitorRepository { get; }
        IFAQRepository FAQRepository { get; }

        IAnswerRepository AnswerRepository { get; }
        INoteRepository NoteRepository { get;}
        IOrderHeaderRepository OrderHeaderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        ICourseDiscountRepository CourseDiscountRepository { get; }
        ICoursePromotionRepository CoursePromotionRepository { get; }
        IShoppingCartRepository ShoppingCartRepository { get; }
        IEnrollCourseRepository EnrollCourseRepository { get; }

        IHelpRepository HelpRepository { get; }
        IHelpTopicRepository HelpTopicRepository { get; }
        IHelpArticleRepository HelpArticleRepository { get; }
        IQuizSectionRepository QuizSectionRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IUserLoginTokenRepository UserLoginTokenRepository { get; }
        IAttachmentRepository AttachmentRepository { get; }

        ICertificateTemplateRepository CertificateTemplateRepository {get;}
        IUserCertificateReposity UserCertificateRepository { get; }
        IQuizzCertificateRepository QuizzCertificateRepository { get; }
        IUserVotesReviewRepository UserVotesReviewRepository { get; }
        IDiscussionRepository DiscussionRepository { get; }
        IReactRepository ReactRepository { get; }
        IInstructorRespository InstructorRespository { get; }
        IUserVoterRepository UserVoterRepository { get; }
        ITemplateRepository TemplateRepository { get; }
        Task<IDbContextTransaction> BeginTransactionAsync();
        bool CheckAlreadyTransaction();
        Task<int> SaveAsync();
    }
}
