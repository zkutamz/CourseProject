using LMS.API.Options;
using LMS.API.Providers;
using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.UnitOfWork;
using LMS.Service.Extensions;
using LMS.Service.Options;
using LMS.Service.Services.AnswerServices;
using LMS.Service.Services.AssignmentServices;
using LMS.Service.Services.AssignmentSubmissionServices;
using LMS.Service.Services.AttachmentServices;
using LMS.Service.Services.AuthServices;
using LMS.Service.Services.BillingAddressServices;
using LMS.Service.Services.CategoryServices;
using LMS.Service.Services.CertificateCategoryServices;
using LMS.Service.Services.CertificateTemplateServices;
using LMS.Service.Services.CertificationSevices;
using LMS.Service.Services.ChatServices;
using LMS.Service.Services.CourseManagementService;
using LMS.Service.Services.CourseService;
using LMS.Service.Services.DiscussionServices;
using LMS.Service.Services.EmailServices;
using LMS.Service.Services.FAQServices;
using LMS.Service.Services.FeedbackServices;
using LMS.Service.Services.FileStorageServices;
using LMS.Service.Services.HanleCertificateFilesServices;
using LMS.Service.Services.HanleCertificateServices;
using LMS.Service.Services.HelpArticleServices;
using LMS.Service.Services.HelpServices;
using LMS.Service.Services.HelpTopicServices;
using LMS.Service.Services.InstructorServices;
using LMS.Service.Services.LessonCompletionServices;
using LMS.Service.Services.LessonServices;
using LMS.Service.Services.NoteServices;
using LMS.Service.Services.NotificationServices;
using LMS.Service.Services.NotificationSettingServices;
using LMS.Service.Services.OrderHeaderServices;
using LMS.Service.Services.PrivacySettingServices;
using LMS.Service.Services.QuizQuestionServices;
using LMS.Service.Services.QuizServices;
using LMS.Service.Services.QuizSubmissionServices;
using LMS.Service.Services.ReviewServices;
using LMS.Service.Services.SectionServices;
using LMS.Service.Services.ShoppingCartServices;
using LMS.Service.Services.TemplateServices;
using LMS.Service.Services.UserServices;
using LMS.Service.Services.UserSubscriberServices;
using LMS.Service.Services.VisitorServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace LMS.API.Extensions
{
    public static class StartupExtension
    {
        public const string MyPolicy = "_myAllowSpecificOrigins";

        public static void ConfigureIdentity(this IServiceCollection services)
            => services.AddIdentity<AppUser, IdentityRole<int>>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;
                config.Tokens.ProviderMap.Add("CustomEmailConfirmation",
             new TokenProviderDescriptor(
                 typeof(CustomEmailConfirmationTokenProvider<AppUser>)));
                config.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
            })
                .AddEntityFrameworkStores<LMSApplicationContext>()
                .AddDefaultTokenProviders();

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var customFormOptions = configuration
                .GetSection(CustomFormOptions.CustomForm)
                .Get<CustomFormOptions>();

            services.Configure<DataProtectionTokenProviderOptions>(o =>
                o.TokenLifespan = TimeSpan.FromHours(3));

            services.Configure<FormOptions>(x => x.MultipartBodyLengthLimit = long.Parse(customFormOptions.MultipartBodyLengthLimit));

            /*
             *  DI here
             */
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomEmailConfirmationTokenProvider<AppUser>>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddHttpContextAccessor();

            services.AddTransient<ISectionService, SectionService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<ICourseManagementService, CourseManagementService>();
            services.AddTransient<IAssignmentServices, AssignmentServices>();
            services.AddTransient<IAssignmentSubmissionServices, AssignmentSubmissionServices>();
            services.AddTransient<IQuizServices, QuizServices>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ILessonServices, LessonServices>();
            services.AddTransient<ILessonCompletionServices, LessonCompletionServices>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IOrderHeaderService, OrderHeaderService>();
            services.AddTransient<ICertificationService, CertificationService>();
            services.AddTransient<IUserAccessor, UserAccessor>();
            services.AddTransient<IQuizQuestionServices, QuizQuestionServices>();
            services.AddTransient<IQuizSubmissionServices, QuizSubmissionServices>();
            services.AddTransient<IFileStorageService, FileStorageService>();
            services.AddTransient<ICertificateCategoryService, CertificateCategoryService>();
            services.AddTransient<IUserSubscriberService, UserSubscriberService>();
            services.AddTransient<INotificationSettingService, NotificationSettingService>();
            services.AddTransient<IPrivacySettingService, PrivacySettingService>();
            services.AddTransient<IBillingAddressService, BillingAddressService>();
            services.AddTransient<IFAQService, FAQService>();

            services.AddTransient<IAnswerServices, AnswerServices>();
            services.AddTransient<IVisitorService, VisitorService>();

            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<IHelpService, HelpService>();
            services.AddTransient<IHelpTopicService, HelpTopicService>();
            services.AddTransient<IHelpArticleService, HelpArticleService>();

            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<ICertificateTemplateService, CertificateTemplateService>();
            services.AddTransient<IShoppingCartService, ShoppingCartService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IAttachmentService, AttachmentService>();
            services.AddTransient<IHanleCertificateFilesServices, HandleCertificateFilesService>();
            services.AddTransient<IFeedbackService, FeedbackService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IDiscussionService, DiscussionService>();
            services.AddTransient<IInstructorService, InstructorService>();
            services.AddTransient<ITemplateService, TemplateService>();
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])) //Configuration["JwtToken:SecretKey"]  
                };
            });

        }

        public static void ConfigureOptionsPattern(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ActionOptions>(configuration.GetSection(ActionOptions.Action));
            services.Configure<ResponseMessageOptions>(configuration.GetSection(ResponseMessageOptions.ResponseMessages));
            services.Configure<Repository.Options.ResponseMessageOptions>(configuration.GetSection(ResponseMessageOptions.ResponseMessages));
            services.Configure<AuthMessageSenderOptions>(configuration.GetSection(AuthMessageSenderOptions.EmailSenderSettings));
            services.Configure<JwtTokenOptions>(configuration.GetSection(JwtTokenOptions.JwtToken));
            services.Configure<SwaggerSecurityRequirementOptions>(configuration.GetSection(SwaggerSecurityRequirementOptions.SwaggerSecurityRequirement));
        }
    }
}