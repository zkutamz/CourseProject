using AutoMapper;
using LMS.Model.Request;
using LMS.Model.Request.AnswerDTOs;
using LMS.Model.Request.AppUserDTOs;
using LMS.Model.Request.AssignmentDTOs;
using LMS.Model.Request.AssignmentSubmissionsDTOs;
using LMS.Model.Request.AttachmentDTOs;
using LMS.Model.Request.CategoryDTOs;
using LMS.Model.Request.CertificateCategoryDTOs;
using LMS.Model.Request.CertificateDTOs;
using LMS.Model.Request.CourseCommentDTOs;
using LMS.Model.Request.CourseDiscountDTOs;
using LMS.Model.Request.CourseDTOs;
using LMS.Model.Request.CourseFavoriteDTOs;
using LMS.Model.Request.CoursePromotionDTOs;
using LMS.Model.Request.DiscussionDTOs;
using LMS.Model.Request.EnrollCourseDTOs;
using LMS.Model.Request.FAQDTOs;
using LMS.Model.Request.FeedbackDTOs;
using LMS.Model.Request.HelpArticleDTOs;
using LMS.Model.Request.HelpDTOs;
using LMS.Model.Request.HelpTopicDTOs;
using LMS.Model.Request.LearningPeriodDTOs;
using LMS.Model.Request.LessonCompletionDTOs;
using LMS.Model.Request.LessonDTOs;
using LMS.Model.Request.NotesDTOs;
using LMS.Model.Request.NotificationDTOs;
using LMS.Model.Request.OrderDetailDTOs;
using LMS.Model.Request.OrderHeaderDTOs;
using LMS.Model.Request.QuizDTOs;
using LMS.Model.Request.QuizQuestionDTOs;
using LMS.Model.Request.QuizSubmissionDTOs;
using LMS.Model.Request.ReviewDTOs;
using LMS.Model.Request.SectionCompletionDTOs;
using LMS.Model.Request.SectionDTOs;
using LMS.Model.Request.ShoppingCartDTOs;
using LMS.Model.Request.SpecializationDTOs;
using LMS.Model.Request.TemplateDTOs;
using LMS.Model.Response.AnswerDTOs;
using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.AssignmentDTOs;
using LMS.Model.Response.AssignmentSubmissionsDTOs;
using LMS.Model.Response.AttachmentDTOs;
using LMS.Model.Response.CategoryDTOs;
using LMS.Model.Response.CertificateCategoryDTOs;
using LMS.Model.Response.CertificateDTOs;
using LMS.Model.Response.ChatDTOs;
using LMS.Model.Response.CourseCommentDTOs;
using LMS.Model.Response.CourseDTOs;
using LMS.Model.Response.CourseFavoriteDTOs;
using LMS.Model.Response.CoursePromotionDTOs;
using LMS.Model.Response.DiscussionDTOs;
using LMS.Model.Response.EnrollCourses;
using LMS.Model.Response.FAQs;
using LMS.Model.Response.FeedbackDTOs;
using LMS.Model.Response.HelpArticleDTOs;
using LMS.Model.Response.HelpDTOs;
using LMS.Model.Response.HelpTopicDTOs;
using LMS.Model.Response.InstructorDTOs;
using LMS.Model.Response.LearningPeriodDTOs;
using LMS.Model.Response.LessonCompletions;
using LMS.Model.Response.Lessons;
using LMS.Model.Response.NotesDTOs;
using LMS.Model.Response.NotificationDTOs;
using LMS.Model.Response.OrderDetailDTOs;
using LMS.Model.Response.OrderHeaderDTOs;
using LMS.Model.Response.QuizDTOs;
using LMS.Model.Response.QuizQuestionDTOs;
using LMS.Model.Response.QuizSectionDTOs;
using LMS.Model.Response.QuizSubmissionDTOs;
using LMS.Model.Response.ReviewDTOs;
using LMS.Model.Response.SectionCompletionDTOs;
using LMS.Model.Response.SectionDTOs;
using LMS.Model.Response.ShoppingCartDTOs;
using LMS.Model.Response.SpecializationDTOs;
using LMS.Model.Response.TemplateDTOs;
using LMS.Model.Response.UserCertigicateDTOs;
using LMS.Model.Response.UserSubscriberDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Paging;

namespace LMS.Model.AutoMapper
{
    public class MapperConfig : Profile
    {
        //Config AutoMapper
        public MapperConfig()
        {
            #region AppUser
            //Config user mapper
            CreateMap<AppUser, AppUserBasicDTO>().ReverseMap();
            CreateMap<AppUser, AppUserChangePasswordDTO>().ReverseMap();
            CreateMap<AppUser, AppUserCreateDTO>().ReverseMap();
            CreateMap<AppUser, AppUserDetailDTO>().ReverseMap();
            CreateMap<AppUser, AppUserDTO>().ReverseMap();
            CreateMap<AppUser, AppUserEditDTO>().ReverseMap();
            CreateMap<AppUser, AppUserForCourseDetailDTO>().ReverseMap();
            CreateMap<AppUser, AppUserNameDTO>().ReverseMap();
            CreateMap<AppUser, AppUserReviewDTO>().ReverseMap();
            CreateMap<AppUser, AppUserDetailRoleDTO>().ReverseMap();
            CreateMap<AppUser, AppUserSubscriberDTO>().ReverseMap();
            #endregion

            #region Learning Period

            CreateMap<LearningPeriods, LearningPeriodDTO>().ReverseMap();
            CreateMap<LearningPeriods, LearningPeriodDetailDTO>().ReverseMap();
            CreateMap<LearningPeriods, LearningPeriodCreateDTO>().ReverseMap();
            CreateMap<LearningPeriods, LearningPeriodEditDTO>().ReverseMap();

            #endregion

            #region Section
            CreateMap<Section, SectionDTO>().ReverseMap();
            CreateMap<Section, SectionBasicDTO>().ReverseMap();
            CreateMap<Section, SectionCreateDTO>().ReverseMap();
            CreateMap<Section, SectionEditDTO>().ReverseMap();
            CreateMap<Section, SectionDetailDTO>().ReverseMap();

            #endregion

            #region Certificate
            CreateMap<Certificate, CertificateDetailDTO>().ReverseMap();
            #endregion

            #region Lesson

            CreateMap<Lesson, LessonCreateDTO>().ReverseMap();
            CreateMap<Lesson, LessonEditDTO>().ReverseMap();
            CreateMap<Lesson, LessonDetailDTO>().ReverseMap();
            CreateMap<Lesson, LessonDTO>().ReverseMap();
            CreateMap<Lesson, LessonBasicDTO>().ReverseMap();

            #endregion

            #region Lesson Completion

            CreateMap<LessonCompletion, LessonCompletionCreateDTO>().ReverseMap();
            CreateMap<LessonCompletion, LessonCompletionEditDTO>().ReverseMap();
            CreateMap<LessonCompletion, LessonCompletionDTO>().ReverseMap();
            CreateMap<LessonCompletion, LessonCompletionDetailDTO>().ReverseMap();

            #endregion

            #region Enroll Course

            CreateMap<EnrollCourse, EnrollCourseCreateDTO>().ReverseMap();
            CreateMap<EnrollCourse, EnrollCourseEditDTO>().ReverseMap();
            CreateMap<EnrollCourse, EnrollCourseDetailDTO>().ReverseMap();
            CreateMap<EnrollCourse, EnrollCourseDTO>().ReverseMap();
            CreateMap<EnrollCourse, EnrollCourseReviewDTO>().ReverseMap();
            CreateMap<EnrollCourse, EnrollCourseBasicDTO>().ReverseMap();
            #endregion

            #region FAQ

            CreateMap<FAQ, FAQCreateDTO>().ReverseMap();
            CreateMap<FAQ, FAQEditDTO>().ReverseMap();
            CreateMap<FAQ, FAQDetailDTO>().ReverseMap();
            CreateMap<FAQ, FAQDTO>().ReverseMap();

            #endregion

            #region Assignment
            //Config AssignmentSubmissions mapper
            CreateMap<Assignment, AssignmentCreateDTO>().ReverseMap();
            CreateMap<Assignment, AssignmentEditDTO>().ReverseMap();
            CreateMap<Assignment, AssignmentDTO>().ReverseMap();
            CreateMap<Assignment, AssignmentBasicDTO>().ReverseMap();
            CreateMap<Assignment, AssignmentDetailDTO>().ReverseMap();
            #endregion

            #region AssignmentSubmissions
            //Config AssignmentSubmissions mapper
            CreateMap<AssignmentSubmissions, AssignmentSubmissionsCreateDTO>().ReverseMap();
            CreateMap<AssignmentSubmissions, AssignmentSubmissionsEditDTO>().ReverseMap();
            CreateMap<AssignmentSubmissions, AssignmentSubmissionsDTO>().ReverseMap();
            CreateMap<AssignmentSubmissions, AssignmentSubmissionsDetailDTO>().ReverseMap();
            #endregion

            #region Category
            //Config Category mapper 
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryEditDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryDetailDTO>().ReverseMap();
            #endregion

            #region CourseComment
            //Config CourseComment mapper
            CreateMap<CourseComment, CourseCommentCreateDTO>().ReverseMap();
            CreateMap<CourseComment, CourseCommentEditDTO>().ReverseMap();
            CreateMap<CourseComment, CourseCommentDTO>().ReverseMap();
            CreateMap<CourseComment, CourseCommentDetailDTO>().ReverseMap();
            #endregion

            #region CourseFavorite
            //Config CourseFavorite mapper
            CreateMap<FavoriteCourse, CourseFavoriteCreateDTO>().ReverseMap();
            CreateMap<FavoriteCourse, CourseFavoriteDTO>().ReverseMap();
            #endregion

            #region Notes
            CreateMap<NotesDTO, Notes>().ReverseMap();
            CreateMap<NotesDetailDTO, Notes>().ReverseMap();
            CreateMap<NotesCreateDTO, Notes>().ReverseMap();
            CreateMap<NotesEditDTO, Notes>().ReverseMap();
            #endregion

            #region Quiz
            CreateMap<QuizCreateDTO, Quiz>().ReverseMap();
            CreateMap<QuizEditDTO, Quiz>().ReverseMap();
            CreateMap<QuizDetailDTO, Quiz>().ReverseMap();
            CreateMap<QuizDTO, Quiz>().ReverseMap();
            CreateMap<QuizBasicDTO, Quiz>().ReverseMap();
            CreateMap<QuizAndQuestionDTO, Quiz>().ReverseMap();
            CreateMap<QuizForSectionDTO, Quiz>().ReverseMap();
            #endregion

            #region Quiz Section

            CreateMap<QuizSection, QuizSectionDTO>().ReverseMap();

            #endregion

            #region QuizQuestion
            CreateMap<QuizQuestion, QuizQuestionResponseDTO>().ReverseMap();
            CreateMap<QuizQuestion, QuizQuestionCreateDTO>().ReverseMap();
            CreateMap<QuizQuestion, QuizQuestionEditDTO>().ReverseMap();
            CreateMap<QuizQuestion, QuizQuestionDetailDTO>().ReverseMap();
            CreateMap<QuizQuestion, QuizQuestionMarkDTO>().ReverseMap();
            CreateMap<QuizQuestion, QuizQuestionResponseDTO>().ReverseMap();
            CreateMap<QuizQuestion, QuizQuestionHandleResultQuizDTO>().ReverseMap();
            CreateMap<QuizQuestion, QuizQuestionDTO>()
                .ReverseMap()
                .ForMember(des => des.Answer, act => act.Ignore())
                .ForMember(des => des.Explanation, act => act.Ignore())
                .ForMember(des => des.ExplanationImageURL, act => act.Ignore());

            #endregion

            #region QuizSubmission
            CreateMap<QuizSubmission, QuizSubmissionDTO>().ReverseMap();
            CreateMap<QuizSubmission, QuizSubmissionCreateDTO>().ReverseMap();
            CreateMap<QuizSubmission, QuizSubmissionEditDTO>().ReverseMap();
            CreateMap<QuizSubmission, QuizSubmissionDetailDTO>().ReverseMap();
            CreateMap<QuizSubmission, QuizSubmitResultDTO>().ReverseMap();
            CreateMap<QuizSubmission, QuizSubmissionForCertificateResultDTO>()
                .ReverseMap()
                .ForMember(des => des.Answers, act => act.Ignore());

            #endregion

            #region Review
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<Review, ReviewFeaturedDTO>().ReverseMap();
            CreateMap<Review, ReviewCreateDTO>().ReverseMap();
            CreateMap<Review, ReviewEditDTO>().ReverseMap();
            CreateMap<Review, ReviewDetailDTO>().ReverseMap();
            #endregion

            #region SectionCompletion
            CreateMap<SectionCompletion, SectionCompletionDTO>().ReverseMap();
            CreateMap<SectionCompletion, SectionCompletionCreateDTO>().ReverseMap();
            CreateMap<SectionCompletion, SectionCompletionEditDTO>().ReverseMap();
            CreateMap<SectionCompletion, SectionCompletionDetailDTO>().ReverseMap();
            #endregion

            #region Specialization
            CreateMap<Specializations, SpecializationDTO>().ReverseMap();
            CreateMap<Specializations, SpecializationCreateDTO>().ReverseMap();
            CreateMap<Specializations, SpecializationEditDTO>().ReverseMap();
            CreateMap<Specializations, SpecializationDetailDTO>().ReverseMap();
            #endregion

            #region Notifications
            CreateMap<NotificationsDTO, Notifications>().ReverseMap();
            CreateMap<NotificationsDetailDTO, Notifications>().ReverseMap();
            CreateMap<NotificationsCreateDTO, Notifications>().ReverseMap();
            CreateMap<NotificationsEditDTO, Notifications>().ReverseMap();
            #endregion

            #region OrderDetail
            CreateMap<OrderDetailDTO, OrderDetail>().ReverseMap();
            CreateMap<OrderDetailCreateDTO, OrderDetail>().ReverseMap();
            CreateMap<OrderDetailEditDTO, OrderDetail>().ReverseMap();
            #endregion

            #region OrderHeader
            CreateMap<OrderHeaderDTO, OrderHeader>().ReverseMap();
            CreateMap<OrderHeaderDetailDTO, OrderHeader>().ReverseMap();
            CreateMap<OrderHeaderCreateDTO, OrderHeader>().ReverseMap();
            CreateMap<OrderHeaderEditDTO, OrderHeader>().ReverseMap();
            #endregion

            #region Course

            CreateMap<CourseBasicDTO, Course>().ReverseMap();
            CreateMap<CourseDTO, Course>().ReverseMap();
            CreateMap<CourseOverviewDTO, Course>().ReverseMap();
            CreateMap<CourseDetailStudentDTO, Course>().ReverseMap();
            CreateMap<CourseDetailTeacherDTO, Course>().ReverseMap();
            CreateMap<CourseCreateDTO, Course>().ReverseMap();
            CreateMap<CourseEditDTO, Course>().ReverseMap();
            CreateMap<PurchasedCoursesOfStudentDTO, Course>().ReverseMap();
            CreateMap<CourseDetailDTO, Course>().ReverseMap();
            CreateMap<Course, CourseForInstructorAnlyicDTO>().ReverseMap();
            CreateMap<Course, CourseWithEnrollCoursesDTO>().ReverseMap();
            CreateMap<CourseTitleDTO, Course>().ReverseMap();
            CreateMap<Course, CourseForFavoriteDTO>().ReverseMap();

            #endregion

            #region Answer
            CreateMap<AnswerDTO, Answer>().ReverseMap();
            CreateMap<AnswerCreateDTO, Answer>().ReverseMap();
            CreateMap<AnswerEditDTO, Answer>().ReverseMap();
            #endregion

            #region Feedback
            CreateMap<Feedback, FeedbackDTO>().ReverseMap();
            CreateMap<Feedback, FeedbackDetailDTO>().ReverseMap();
            CreateMap<Feedback, FeedbackCreateDTO>().ReverseMap();
            CreateMap<Feedback, FeedbackEditDTO>().ReverseMap();
            #endregion

            #region PaginatedList

            CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>))
                .ConvertUsing(typeof(PaginatedListTypeConverter<,>));

            #endregion

            #region Certificate
            CreateMap<Certificate, CertificateDTO>().ReverseMap();
            CreateMap<Certificate, CertificateCreateDTO>().ReverseMap();
            CreateMap<Certificate, CertificateEditDTO>().ReverseMap();
            CreateMap<Certificate, CertificateDetailDTO>().ReverseMap();
            #endregion

            #region CertificateCategory
            CreateMap<CertificateCategory, CertificateCategoryDTO>().ReverseMap();
            CreateMap<CertificateCategory, CertificateCategoryCreateDTO>().ReverseMap();
            CreateMap<CertificateCategory, CertificateCategoryEditDTO>().ReverseMap();
            CreateMap<CertificateCategory, CertificateCategoryDetailDTO>().ReverseMap();
            #endregion

            #region Chat
            CreateMap<Chat, ChatDTO>().ReverseMap();
            #endregion

            #region Help
            CreateMap<Help, HelpDTO>().ReverseMap();
            CreateMap<Help, HelpDetailDTO>().ReverseMap();
            CreateMap<Help, HelpCreateDTO>().ReverseMap();
            CreateMap<Help, HelpEditDTO>().ReverseMap();
            #endregion

            #region HelpTopic
            CreateMap<HelpTopic, HelpTopicDTO>().ReverseMap();
            CreateMap<HelpTopic, HelpTopicDetailDTO>().ReverseMap();
            CreateMap<HelpTopic, HelpTopicCreateDTO>().ReverseMap();
            CreateMap<HelpTopic, HelpTopicEditDTO>().ReverseMap();
            #endregion

            #region HelpArticle
            CreateMap<HelpArticle, HelpArticleDTO>();
            CreateMap<HelpArticle, HelpArticleDetailDTO>();
            #endregion
            #region Template
            CreateMap<TemplateCreateDTO, Template>()
                .ReverseMap()
                .ForMember(dest => dest.TemplateData, act => act.Ignore());
            CreateMap<TemplateEditDTO, Template>()
                .ReverseMap()
                .ForMember(dest => dest.TemplateData, act => act.Ignore());
            CreateMap<Template, TemplateDTO>();
            CreateMap<Template, TemplateDetailDTO>();
            #endregion

            #region CourseDiscount
            CreateMap<CourseDiscount, CourseDiscountCreateDTO>().ReverseMap();
            #endregion

            #region CoursePromotion
            CreateMap<CoursePromotion, CoursePromotionCreateDTO>().ReverseMap();
            CreateMap<CoursePromotion, CoursePromotionDTO>().ReverseMap();
            #endregion

            #region ShoppingCart
            CreateMap<ShoppingCart, AddToCartDTO>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartPurchaseOfUserDTO>().ReverseMap();
            #endregion

            #region Attachment

            CreateMap<AttachmentCreateDTO, Attachment>().ReverseMap();
            CreateMap<Attachment, AttachmentDTO>().ReverseMap();

            #endregion
            #region UserCertificate
            CreateMap<UserCertificate, UserCertificateDetailDTO>()
                .ReverseMap();
            #endregion

            #region UserSubscriber

            CreateMap<UserSubcriber, UserSubscriberDTO>().ReverseMap();
            CreateMap<UserSubcriber, UserSubscriberBasicDTO>().ReverseMap();

            #endregion

            #region HelpArticle
            CreateMap<HelpArticle, HelpArticleCreateDTO>().ReverseMap();
            CreateMap<HelpArticle, HelpArticleEditDTO>().ReverseMap();
            #endregion

            #region Discussion
            CreateMap<Discussion, DiscussionCreateDTO>().ReverseMap();
            CreateMap<Discussion, DiscussionEditDTO>().ReverseMap();
            CreateMap<Discussion, DiscussionDTO>().ReverseMap();
            #endregion

            #region Instructor
            CreateMap<AppUser, InstructorPopularDTO>().ReverseMap();
            #endregion
        }
    }
}