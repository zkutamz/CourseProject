using LMS.Repository.Context;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using LMS.Repository.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace LMS.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Attributes

        private readonly LMSApplicationContext _context;
        private readonly IOptionsSnapshot<ResponseMessageOptions> _responseMessage;
        private IAppUserRepository _appUserRepository;
        private INotificationRepository _notificationRepository;
        private ISectionRepository _sectionRepository;
        private ICourseCommentRepository _courseCommentRepository;
        private ICourseFavoriteRepository _courseFavoriteRepository;
        private IAssignmentRepository _assignmentRepository;
        private IAssignmentSubmissionRepository _assignmentSubmissionRepository;
        private ILessonRepository _lessonRepository;
        private ILessonCompletionRepository _lessonCompletionRepository;
        private IFeedbackRepository _feedbackRepository;
        private IReviewRepository _reviewRepository;
        private ICourseRepository _courseRepository;
        private IOrderHeaderRepository _orderHeaderRepository;
        private IQuizRepository _quizRepository;
        private ICertificationRepository _certificationRepository;
        private IChatRepository _chatRepository;
        private IChatUserRepository _chatUserRepository;
        private IQuizQuestionRepository _quizQuestionRepository;
        private IAnswerRepository _answerRepository;
        private IUserVotesReviewRepository _userVotesReviewRepository;
        private IQuizSubmissionRepository _quizSubmissionRepository;
        private ICertificateCategoryRepository _certificateCategoryRepository;
        private IUserSubcriberRepository _userSubcriberRepository;
        private IFAQRepository _fAQRepository;
        private INoteRepository _noteRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private ICourseDiscountRepository _courseDiscountRepository;
        private ICoursePromotionRepository _coursePromotionRepository;
        private IShoppingCartRepository _shoppingCartRepository;
        private INotificationSettingRepository _notificationSettingRepository;
        private IPrivacySettingRepository _privacySettingRepository;
        private IBillingAddressRepository _billingAddressRepository;
        private IVisitorRepository _visitorRepository;
        private IEnrollCourseRepository _enrollCourseRepository;
        private IHelpRepository _helpRepository;
        private IHelpTopicRepository _helpTopicRepository;
        private IHelpArticleRepository _helpArticleRepository;
        private ICertificateTemplateRepository _certificateTemplateRepository;
        private IQuizSectionRepository _quizSectionRepository;
        private ICategoryRepository _categoryRepository;
        private IUserLoginTokenRepository _userLoginTokenRepository;
        private IAttachmentRepository _attachmentRepository;
        private IUserCertificateReposity _userCertificateReposity;
        private IQuizzCertificateRepository _quizzCertificateRepository;
        private IDiscussionRepository _discussionRepository;
        private IReactRepository _reactRepository;
        private IInstructorRespository _instructorRespository;
        private IUserVoterRepository _userVoterRepository;
        private ITemplateRepository _templateRepository;


        #endregion

        #region Logger

        private readonly ILogger<NotificationRepository> _notificationLogger;
        private readonly ILogger<AppUserRepository> _appUserLogger;
        private readonly ILogger<SectionRepository> _sectionRepositoryLogger;
        private readonly ILogger<CourseCommentRepository> _courseCommentRepositoryLogger;
        private readonly ILogger<CourseFavoriteRepository> _courseFavoriteRepositoryLogger;
        private readonly ILogger<AssignmentRepository> _assignmentRepositoryLogger;
        private readonly ILogger<LessonRepository> _lessonRepositoryLogger;
        private readonly ILogger<LessonCompletionRepository> _lessonCompletionRepositoryLogger;
        private readonly ILogger<CourseRepository> _courseRepositoryLogger;
        private readonly ILogger<OrderHeaderRepository> _orderHeaderRepositoryLogger;
        private readonly ILogger<QuizRepository> _quizRepositoryLogger;
        private readonly ILogger<CertificateRepository> _certificateLogger;
        private readonly ILogger<ChatRepository> _chatRepositoryLogger;
        private readonly ILogger<ChatUserRepository> _chatUserRepositoryLogger;
        private readonly ILogger<FeedbackRepository> _feedbackRepositoryLogger;
        private readonly ILogger<ReviewRepository> _reviewRepositoryLogger;
        private readonly ILogger<QuizQuestionRepository> _quizQuestionRepositoryLogger;
        private readonly ILogger<AnswerRepository> _answerRepositoryLogger;
        private readonly ILogger<QuizSubmissionRepository> _quizSubmissionRepositoryLogger;
        private readonly ILogger<AssignmentSubmissionRepository> _assignmentSubmissionRepositoryLogger;
        private readonly ILogger<CertificateCategoryRepository> _certificateCategoryLogger;
        private readonly ILogger<OrderDetailRepository> _orderDetailRepositoryLogger;
        private readonly ILogger<CourseDiscountRepository> _courseDiscountRepositoryLogger;
        private readonly ILogger<UserSubcriberRepository> _userSubscriberRepositoryLogger;
        private readonly ILogger<FAQRepository> _fAQRepositoryLogger;
        private readonly ILogger<NoteRepository> _noteRepositoryLogger;
        private readonly ILogger<CoursePromotionRepository> _coursePromotionRepositoryLogger;
        private readonly ILogger<ShoppingCartRepository> _shoppingCartRepositoryLogger;
        private readonly ILogger<NotificationSettingRepository> _notificationSettingRepositoryLogger;
        private readonly ILogger<PrivacySettingRepository> _privacySettingRepositoryLogger;
        private readonly ILogger<BillingAddressRepository> _billingAddressRepositoryLogger;
        private readonly ILogger<VisitorRepository> _visitorRepositoryLogger;
        private readonly ILogger<EnrollCourseRepository> _enrollCourseRepositoryLogger;
        private readonly ILogger<HelpRepository> _helpRepositoryLogger;
        private readonly ILogger<HelpTopicRepository> _helpTopicRepositoryLogger;
        private readonly ILogger<HelpArticleRepository> _helpArticleRepositoryLogger;
        private readonly ILogger<CertificateTemplateRepository> _certificateTemplateRepositoryLogger;
        private readonly ILogger<QuizSectionRepository> _quizSectionRepositoryLogger;
        private readonly ILogger<CategoryRepository> _categoryRepositoryLogger;
        private readonly ILogger<UserLoginTokenRepository> _userLoginTokenRepositoryLogger;
        private readonly ILogger<AttachmentRepository> _attachmentRepositoryLogger;
        private readonly ILogger<UserCertificateRepsotiry> _userCertificateRepositoryLogger;
        private readonly ILogger<QuizzCertificateRepository> _quizzCertificateReposigoryLogger;
        private readonly ILogger<UserVotesReviewRepository> _userVotesReviewRepositoryLogger;
        private readonly ILogger<DiscussionRepository> _discussionRepositoryLogger;
        private readonly ILogger<ReactRepository> _reactRepositoryLogger;
        private readonly ILogger<InstructorRespository> _instructorRespositoryLogger;
        private readonly ILogger<UserVoterRepository> _userVoterRepositoryLogger;
        private readonly ILogger<TemplateRepository> _templateRepositoryLogger;


        #endregion

        #region Methods

        public UnitOfWork(LMSApplicationContext context,
            ILogger<AppUserRepository> appUserLogger,
            ILogger<CourseCommentRepository> courseCommentRepositoryLogger,
            ILogger<CourseFavoriteRepository> courseFavoriteRepositoryLogger,
            ILogger<SectionRepository> sectionRepositoryLogger,
            ILogger<NotificationRepository> notificationLogger,
            ILogger<CourseRepository> courseRepositoryLogger,
            ILogger<OrderHeaderRepository> orderHeaderRepositoryLogger,
            ILogger<QuizRepository> quizRepositoryLogger,
            ILogger<AssignmentRepository> assignmentRepositoryLogger,
            ILogger<LessonRepository> lessonRepositoryLogger,
            ILogger<LessonCompletionRepository> lessonCompletionRepositoryLogger,
            ILogger<CertificateRepository> certificateLogger,
            ILogger<ChatRepository> chatRepositoryLogger,
            ILogger<ChatUserRepository> chatUserRepositoryLogger,
            ILogger<FeedbackRepository> feedbackLogger,
            ILogger<ReviewRepository> reviewLogger,
            ILogger<QuizQuestionRepository> quizQuestionRepositoryLogger,
            ILogger<QuizSubmissionRepository> quizSubmissionRepositoryLogger,
            ILogger<AssignmentSubmissionRepository> assignmentSubmissionRepositoryLogger,
            ILogger<CertificateCategoryRepository> certificateCategoryLogger,
            ILogger<OrderDetailRepository> orderDetailRepositoryLogger,
            ILogger<CourseDiscountRepository> courseDiscountRepositoryLogger,
            ILogger<UserSubcriberRepository> userSubscriberRepositoryLogger,
            ILogger<FAQRepository> fAQRepositoryLogger,
            ILogger<AnswerRepository> answerRepositoryLogger,
            ILogger<NoteRepository> noteRepositoryLogger,
            ILogger<CoursePromotionRepository> coursePromotionRepositoryLogger,
            ILogger<ShoppingCartRepository> shoppingCartRepositoryLogger,
            ILogger<NotificationSettingRepository> notificationSettingRepositoryLogger,
            ILogger<PrivacySettingRepository> privacySettingRepositoryLogger,
            ILogger<BillingAddressRepository> billingAddressRepositoryLogger,
            ILogger<VisitorRepository> visitorRepositoryLogger,
            ILogger<EnrollCourseRepository> enrollCourseRepository,
            ILogger<HelpRepository> helpRepositoryLogger,
            ILogger<HelpTopicRepository> helpTopicRepositoryLogger,
            ILogger<HelpArticleRepository> helpArticleRepositoryLogger,
            ILogger<CertificateTemplateRepository> certificateTemplateRepositoryLogger,
            ILogger<QuizSectionRepository> quizSectionRepositoryLogger,
            ILogger<UserLoginTokenRepository> userLoginTokenRepositoryLogger,
            ILogger<CategoryRepository> categoryRepositoryLogger,
            ILogger<AttachmentRepository> attachmentRepositoryLogger,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage,
             ILogger<UserCertificateRepsotiry> userCertificateRepositoryLogger,
            ILogger<QuizzCertificateRepository> quizzCertificateRepositoryLogger,
            ILogger<UserVotesReviewRepository> userVotesReviewRepositoryLogger,
            ILogger<DiscussionRepository> discussionRepositoryLogger,
            ILogger<ReactRepository> reactRepositoryLogger,
            ILogger<InstructorRespository> instructorRepositoryLogger,
            ILogger<UserVoterRepository> userVoterRepositoryLogger,
            ILogger<TemplateRepository> templateRepositoryLogger)
        {
            _context = context;
            _assignmentRepositoryLogger = assignmentRepositoryLogger;
            _chatRepositoryLogger = chatRepositoryLogger;
            _chatUserRepositoryLogger = chatUserRepositoryLogger;
            _notificationLogger = notificationLogger;
            _courseCommentRepositoryLogger = courseCommentRepositoryLogger;
            _courseFavoriteRepositoryLogger = courseFavoriteRepositoryLogger;
            _appUserLogger = appUserLogger;
            _sectionRepositoryLogger = sectionRepositoryLogger;
            _lessonRepositoryLogger = lessonRepositoryLogger;
            _lessonCompletionRepositoryLogger = lessonCompletionRepositoryLogger;
            _courseRepositoryLogger = courseRepositoryLogger;
            _orderHeaderRepositoryLogger = orderHeaderRepositoryLogger;
            _quizRepositoryLogger = quizRepositoryLogger;
            _certificateLogger = certificateLogger;
            _lessonRepositoryLogger = lessonRepositoryLogger;
            _feedbackRepositoryLogger = feedbackLogger;
            _reviewRepositoryLogger = reviewLogger;
            _quizQuestionRepositoryLogger = quizQuestionRepositoryLogger;
            _quizSubmissionRepositoryLogger = quizSubmissionRepositoryLogger;
            _assignmentSubmissionRepositoryLogger = assignmentSubmissionRepositoryLogger;
            _certificateCategoryLogger = certificateCategoryLogger;

            _courseRepositoryLogger = courseRepositoryLogger;
            _orderHeaderRepositoryLogger = orderHeaderRepositoryLogger;
            _orderDetailRepositoryLogger = orderDetailRepositoryLogger;
            _courseDiscountRepositoryLogger = courseDiscountRepositoryLogger;

            _userSubscriberRepositoryLogger = userSubscriberRepositoryLogger;
            _fAQRepositoryLogger = fAQRepositoryLogger;
            _answerRepositoryLogger = answerRepositoryLogger;
            _noteRepositoryLogger = noteRepositoryLogger;
            _coursePromotionRepositoryLogger = coursePromotionRepositoryLogger;
            _shoppingCartRepositoryLogger = shoppingCartRepositoryLogger;
            _notificationSettingRepositoryLogger = notificationSettingRepositoryLogger;
            _privacySettingRepositoryLogger = privacySettingRepositoryLogger;
            _billingAddressRepositoryLogger = billingAddressRepositoryLogger;
            _visitorRepositoryLogger = visitorRepositoryLogger;
            _enrollCourseRepositoryLogger = enrollCourseRepository;
            _helpRepositoryLogger = helpRepositoryLogger;
            _helpTopicRepositoryLogger = helpTopicRepositoryLogger;
            _helpArticleRepositoryLogger = helpArticleRepositoryLogger;
            _certificateTemplateRepositoryLogger = certificateTemplateRepositoryLogger;
            _quizSectionRepositoryLogger = quizSectionRepositoryLogger;
            _categoryRepositoryLogger = categoryRepositoryLogger;
            _userLoginTokenRepositoryLogger = userLoginTokenRepositoryLogger;
            _attachmentRepositoryLogger = attachmentRepositoryLogger;
            _userCertificateRepositoryLogger = userCertificateRepositoryLogger;
            _quizzCertificateReposigoryLogger = quizzCertificateRepositoryLogger;
            _userVotesReviewRepositoryLogger = userVotesReviewRepositoryLogger;
            _responseMessage = responseMessage;
            _discussionRepositoryLogger = discussionRepositoryLogger;
            _reactRepositoryLogger = reactRepositoryLogger;
            _instructorRespositoryLogger = instructorRepositoryLogger;
            _userVoterRepositoryLogger = userVoterRepositoryLogger;
            _templateRepositoryLogger = templateRepositoryLogger;
        }

        public INotificationRepository NotificationRepository =>
            _notificationRepository ??= new NotificationRepository(_context, _notificationLogger, _responseMessage);

        public ICourseCommentRepository CourseCommentRepository =>
            _courseCommentRepository ??= new CourseCommentRepository(_context, _courseCommentRepositoryLogger, _responseMessage);

        public ICourseFavoriteRepository CourseFavoriteRepository =>
            _courseFavoriteRepository ??= new CourseFavoriteRepository(_context, _courseFavoriteRepositoryLogger, _responseMessage);

        public IAssignmentRepository AssignmentRepository =>
            _assignmentRepository ??= new AssignmentRepository(_context, _assignmentRepositoryLogger, _responseMessage);

        public IAppUserRepository AppUserRepository =>
            _appUserRepository ??= new AppUserRepository(_context, _appUserLogger, _responseMessage);

        public ISectionRepository SectionRepository =>
            _sectionRepository ??= new SectionRepository(_context, _sectionRepositoryLogger, _responseMessage);

        public ILessonRepository LessonRepository =>
            _lessonRepository ??= new LessonRepository(_context, _lessonRepositoryLogger, _responseMessage);

        public IQuizRepository QuizRepository =>
            _quizRepository ??= new QuizRepository(_context, _quizRepositoryLogger, _responseMessage);

        public IOrderHeaderRepository OrderHeaderRepository
            => _orderHeaderRepository ??= new OrderHeaderRepository(_context, _orderHeaderRepositoryLogger, _responseMessage);

        public IOrderDetailRepository OrderDetailRepository
            => _orderDetailRepository ??= new OrderDetailRepository(_context, _orderDetailRepositoryLogger, _responseMessage);

        public ICourseRepository CourseRepository =>
            _courseRepository ??= new CourseRepository(_context, _courseRepositoryLogger, _responseMessage);

        public ICertificationRepository CertificationRepository =>
            _certificationRepository ??= new CertificateRepository(_context, _certificateLogger, _responseMessage);

        public IChatRepository ChatRepository
            => _chatRepository ??= new ChatRepository(_context, _chatRepositoryLogger, _responseMessage);

        public IChatUserRepository ChatUserRepository
            => _chatUserRepository ??= new ChatUserRepository(_context, _chatUserRepositoryLogger, _responseMessage);

        public IFeedbackRepository FeedbackRepository
            => _feedbackRepository ??= new FeedbackRepository(_context, _feedbackRepositoryLogger, _responseMessage);

        public IReviewRepository ReviewRepository
            => _reviewRepository ??= new ReviewRepository(_context, _reviewRepositoryLogger, _responseMessage);

        public IQuizQuestionRepository QuizQuestionRepository =>
            _quizQuestionRepository ??= new QuizQuestionRepository(_context, _quizQuestionRepositoryLogger, _responseMessage);

        public IAnswerRepository AnswerRepository =>
    _answerRepository ??= new AnswerRepository(_context, _answerRepositoryLogger, _responseMessage);

        public IQuizSubmissionRepository QuizSubmissionRepository =>
             _quizSubmissionRepository ??= new QuizSubmissionRepository(_context, _quizSubmissionRepositoryLogger, _responseMessage);

        public IAssignmentSubmissionRepository AssignmentSubmissionRepository =>
            _assignmentSubmissionRepository ??= new AssignmentSubmissionRepository(_context, _assignmentSubmissionRepositoryLogger, _responseMessage);

        public ICertificateCategoryRepository CertificateCategoryRepository
            => _certificateCategoryRepository ??= new CertificateCategoryRepository(_context, _certificateCategoryLogger, _responseMessage);

        public IUserSubcriberRepository UserSubcriberRepository =>
            _userSubcriberRepository ??= new UserSubcriberRepository(_context, _userSubscriberRepositoryLogger, _responseMessage);

        public IFAQRepository FAQRepository
            => _fAQRepository ??= new FAQRepository(_context, _fAQRepositoryLogger, _responseMessage);

        public ILessonCompletionRepository LessonCompletionRepository
            => _lessonCompletionRepository ??=
                new LessonCompletionRepository(_context, _lessonCompletionRepositoryLogger, _responseMessage);

        public INoteRepository NoteRepository =>
          _noteRepository ??= new NoteRepository(_context, _noteRepositoryLogger, _responseMessage);

        public ICoursePromotionRepository CoursePromotionRepository => _coursePromotionRepository ??= new CoursePromotionRepository(_context, _coursePromotionRepositoryLogger, _responseMessage);

        public IShoppingCartRepository ShoppingCartRepository => _shoppingCartRepository ??= new ShoppingCartRepository(_context, _shoppingCartRepositoryLogger, _responseMessage);

        public INotificationSettingRepository NotificationSettingRepository =>
            _notificationSettingRepository ??= new NotificationSettingRepository(_context, _notificationSettingRepositoryLogger, _responseMessage);

        public IPrivacySettingRepository PrivacySettingRepository =>
            _privacySettingRepository ??= new PrivacySettingRepository(_context, _privacySettingRepositoryLogger, _responseMessage);

        public IBillingAddressRepository BillingAddressRepository =>
            _billingAddressRepository ??= new BillingAddressRepository(_context, _billingAddressRepositoryLogger, _responseMessage);

        public IVisitorRepository VisitorRepository =>
            _visitorRepository ??= new VisitorRepository(_context, _visitorRepositoryLogger, _responseMessage);

        public IEnrollCourseRepository EnrollCourseRepository =>
         _enrollCourseRepository ??= new EnrollCourseRepository(_context, _enrollCourseRepositoryLogger, _responseMessage);

        public IHelpRepository HelpRepository =>
            _helpRepository ??= new HelpRepository(_context, _helpRepositoryLogger, _responseMessage);
        public IHelpTopicRepository HelpTopicRepository =>
            _helpTopicRepository ??= new HelpTopicRepository(_context, _helpTopicRepositoryLogger, _responseMessage);

        public IHelpArticleRepository HelpArticleRepository =>
            _helpArticleRepository ??= new HelpArticleRepository(_context, _helpArticleRepositoryLogger, _responseMessage);
        public ICertificateTemplateRepository CertificateTemplateRepository =>
          _certificateTemplateRepository ??= new CertificateTemplateRepository(_context, _certificateTemplateRepositoryLogger, _responseMessage);

        public ICourseDiscountRepository CourseDiscountRepository
            => _courseDiscountRepository ??= new CourseDiscountRepository(_context, _courseDiscountRepositoryLogger, _responseMessage);

        public IQuizSectionRepository QuizSectionRepository =>
            _quizSectionRepository ??= new QuizSectionRepository(_context, _quizSectionRepositoryLogger, _responseMessage);

        public ICategoryRepository CategoryRepository =>
            _categoryRepository ??= new CategoryRepository(_context, _categoryRepositoryLogger, _responseMessage);

        public IUserLoginTokenRepository UserLoginTokenRepository => _userLoginTokenRepository ??= new UserLoginTokenRepository(_context, _userLoginTokenRepositoryLogger,_responseMessage);

        public IAttachmentRepository AttachmentRepository =>
            _attachmentRepository ??= new AttachmentRepository(_context, _attachmentRepositoryLogger, _responseMessage);

        public IUserCertificateReposity UserCertificateRepository =>
            _userCertificateReposity ??= new UserCertificateRepsotiry(_context, _userCertificateRepositoryLogger, _responseMessage);

        public IQuizzCertificateRepository QuizzCertificateRepository =>
              _quizzCertificateRepository ??= new QuizzCertificateRepository(_context, _quizzCertificateReposigoryLogger, _responseMessage);

        public IUserVotesReviewRepository UserVotesReviewRepository =>
            _userVotesReviewRepository ??=
                new UserVotesReviewRepository(_context, _userVotesReviewRepositoryLogger, _responseMessage);

        public IDiscussionRepository DiscussionRepository =>
            _discussionRepository ??=
                new DiscussionRepository(_context, _discussionRepositoryLogger, _responseMessage);

        public IReactRepository ReactRepository =>
            _reactRepository ??=
                new ReactRepository(_context, _reactRepositoryLogger, _responseMessage);

        public IInstructorRespository InstructorRespository =>
            _instructorRespository ??= new InstructorRespository(_context,_instructorRespositoryLogger, _responseMessage);

        public IUserVoterRepository UserVoterRepository =>
            _userVoterRepository ??= new UserVoterRepository(_context, _userVoterRepositoryLogger, _responseMessage);
        public ITemplateRepository TemplateRepository =>
          _templateRepository ??= new TemplateRepository(_context, _templateRepositoryLogger, _responseMessage);

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return _context.Database.CurrentTransaction ?? await _context.Database.BeginTransactionAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public bool CheckAlreadyTransaction()
        {
            return _context.Database.CurrentTransaction != null;
        }

        #endregion
    }
}