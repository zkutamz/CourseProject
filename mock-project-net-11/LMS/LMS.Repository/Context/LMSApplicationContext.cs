using LMS.Repository.Context.Configurations;
using LMS.Repository.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LMS.Repository.Context

{
    /// <summary>
    /// 
    /// </summary>
    public class LMSApplicationContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public LMSApplicationContext(DbContextOptions<LMSApplicationContext> options) : base(options)
        {

        }

        /// <summary>

        /// Apply configuration for EF.
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AssignmentSubmissionsConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new CourseCommentConfiguration());
            builder.ApplyConfiguration(new FavoriteCourseConfiguration());
            builder.ApplyConfiguration(new SectionConfiguration());
            builder.ApplyConfiguration(new LessonConfiguration());
            builder.ApplyConfiguration(new AssignmentConfiguration());
            builder.ApplyConfiguration(new QuizConfiguration());
            builder.ApplyConfiguration(new QuizQuestionConfiguration());
            builder.ApplyConfiguration(new SectionCompletionConfiguration());
            builder.ApplyConfiguration(new SpecializationConfiguration());
            builder.ApplyConfiguration(new NotesConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());
            builder.ApplyConfiguration(new EnrollCourseConfiguration());
            builder.ApplyConfiguration(new QuizSubmissionConfiguration());
            builder.ApplyConfiguration(new OrderDetailConfiguration());
            builder.ApplyConfiguration(new OrderHeaderConfiguration());
            builder.ApplyConfiguration(new LessonCompletionConfiguration());
            builder.ApplyConfiguration(new LearningPeriodsConfiguration());
            builder.ApplyConfiguration(new NotificationsConfiguration());
            builder.ApplyConfiguration(new EnrollCourseConfiguration());
            builder.ApplyConfiguration(new AnswersConfiguration());
            builder.ApplyConfiguration(new CourseDiscountConfiguration());
            builder.ApplyConfiguration(new FeedbackConfiguration());
            builder.ApplyConfiguration(new CertificateConfiguration());
            builder.ApplyConfiguration(new CertificateCategoryConfiguration());
            builder.ApplyConfiguration(new ChatConfiguration());
            builder.ApplyConfiguration(new MessagesConfiguration());
            builder.ApplyConfiguration(new ChatUserConfiguration());
            builder.ApplyConfiguration(new UserCertificateConfiguration());
            builder.ApplyConfiguration(new UserSubcriberConfiguration());
            builder.ApplyConfiguration(new NotificationSettingConfiguration());
            builder.ApplyConfiguration(new PrivacySettingConfiguration());
            builder.ApplyConfiguration(new WithdrawalMethodConfiguration());
            builder.ApplyConfiguration(new BillingAddressConfiguration());
            builder.ApplyConfiguration(new CoursePromotionConfiguration());
            builder.ApplyConfiguration(new ShoppingCartConfiguration());
            builder.ApplyConfiguration(new VisitorConfiguration());
            builder.ApplyConfiguration(new FAQConfiguration());
            builder.ApplyConfiguration(new HelpConfiguration());
            builder.ApplyConfiguration(new HelpTopicConfiguration());
            builder.ApplyConfiguration(new HelpArticleConfiguration());
            builder.ApplyConfiguration(new QuizCertificateConfiguration());
            builder.ApplyConfiguration(new CertificateTemlateConfiguration());
            builder.ApplyConfiguration(new UserLoginTokenConfiguration());
            builder.ApplyConfiguration(new AttachmentConfiguration());
            builder.ApplyConfiguration(new UserVotesReviewConfiguration());
            builder.ApplyConfiguration(new ReactionConfiguration());
            builder.ApplyConfiguration(new DiscussionConfiguration());
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new UserVoterConfiguration());
            builder.ApplyConfiguration(new CertificateTemplateConfiguration());


            builder.Seed();
        }

        /*
         * Auto filled the DateCreated and DateModified Dates before saving to the DB.
         */
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var addedEntities =
                base.ChangeTracker
                    .Entries<BaseEntity>()
                    .Where(e =>
                        e.State is EntityState.Added || e.State is EntityState.Modified);

            foreach (var addedEntity in addedEntities)
            {
                addedEntity.Entity.UpdatedAt = DateTime.Now;

                if (addedEntity.State is EntityState.Added)
                    addedEntity.Entity.CreatedAt = DateTime.Now;
            }

            var addedUserVoters = base.ChangeTracker
                .Entries<UserVoter>()
                .Where(u =>
                    u.State is EntityState.Added || u.State is EntityState.Modified
                );

            foreach (var addedUserVoter in addedUserVoters)
            {
                addedUserVoter.Entity.UpdatedAt = DateTime.Now;

                if (addedUserVoter.State is EntityState.Added)
                    addedUserVoter.Entity.CreatedAt = DateTime.Now;
            }

            var addedUserSubscribers = base.ChangeTracker
                .Entries<UserSubcriber>()
                .Where(u =>
                    u.State is EntityState.Added || u.State is EntityState.Modified
                );

            foreach (var addedUserSubscriber in addedUserSubscribers)
            {
                addedUserSubscriber.Entity.UpdatedAt = DateTime.Now;

                if (addedUserSubscriber.State is EntityState.Added)
                    addedUserSubscriber.Entity.CreatedAt = DateTime.Now;
            }


            return base.SaveChangesAsync(cancellationToken);
        }

        #region DbSets

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Specializations> Specializations { get; set; }
        public DbSet<SectionCompletion> SectionCompletions { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<EnrollCourse> EnrollCourses { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<QuizSubmission> QuizSubmissions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<AssignmentSubmissions> AssignmentSubmissions { get; set; }
        public DbSet<CourseComment> CourseComment { get; set; }
        public DbSet<FavoriteCourse> FavoriteCourses { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<LessonCompletion> LessonCompletion { get; set; }
        public DbSet<LearningPeriods> LearningPeriods { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<CourseDiscount> CourseDiscounts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CertificateCategory> CertificateCategories { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatUser> ChatUser { get; set; }
        public DbSet<UserCertificate> UserCertificates { get; set; }
        public DbSet<CoursePromotion> CoursePromotions { get; set; }
        public DbSet<NotificationSetting> NotificationSettings { get; set; }
        public DbSet<PrivacySetting> PrivacySettings { get; set; }
        public DbSet<WithdrawalMethod> WithdrawalMethods { get; set; }
        public DbSet<BillingAddress> BillingAddresses { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<UserSubcriber> UserSubcribers { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Help> Helps { get; set; }
        public DbSet<HelpTopic> HelpTopics { get; set; }
        public DbSet<HelpArticle> HelpArticles { get; set; }
        public DbSet<QuizSection> QuizSections { get; set; }
        public DbSet<QuizzCertificate> QuizzCertificates { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<UserLoginToken> UserLoginTokens { get; set; }
        public DbSet<UserVotesReview> UserVotesReviews { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<UserVoter> UserVoters { get; set; }
        public DbSet<CertificateTemplate> CertificateTemplates { get; set; }


        #endregion
    }
}
