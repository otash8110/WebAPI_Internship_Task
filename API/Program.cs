using API;
using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Options;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Configuration;

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddRazorPages();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));

            builder.Services.AddScoped<ApplicationDbContextInitialiser>();

            builder.Services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, AppDbContext>()
            .AddProfileService<ProfService>();

            builder.Services.AddAuthentication()
            .AddIdentityServerJwt()
            .AddGoogle(options =>
            {
                options.ClientId = "dasdasd";
                options.ClientSecret = "asdasd";
            });

            builder.Services.AddAuthorization(options =>
            options.AddPolicy("IsAdmin", 
            policy => policy.RequireClaim(ClaimTypes.Role, "Administrator")));

            builder.Services.AddTransient<IIdentityService, IdentityService>();
            //builder.Services.AddTransient<IProfileService, ProfService>();
            //builder.Services.AddTransient<IEmailSender, EmailSender>();

            builder.Services.AddCors();
            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                using (var scope = app.Services.CreateScope())
                {
                    var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
                    await initialiser.InitialiseAsync();
                    await initialiser.SeedAsync();
                }
            }

            app.UseCors(opt =>
            {
                opt.AllowAnyHeader();
                opt.AllowAnyMethod();
                opt.AllowAnyOrigin();
            });
            app.UseRouting();
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }




    public class ApplicationUser : IdentityUser
    {

    }

    public class AppDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        private OperationalStoreOptions operationalStoreOptions;

        public AppDbContext(DbContextOptions<AppDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
            this.operationalStoreOptions = operationalStoreOptions.Value;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<DeviceFlowCodes>();
            //modelBuilder.Ignore<IdentityRoleClaim<string>>();
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
        }
    }

    //public class EmailSender : IEmailSender
    //{
    //    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    //    {
    //        var emailClient = new SmtpClient("localhost");
    //        var message = new MailMessage
    //        {
    //            From = new MailAddress("otash_baxadirov@mail.ru"),
    //            Subject = subject,
    //            Body = htmlMessage
    //        };
    //        message.To.Add(new MailAddress(email));
    //        await emailClient.SendMailAsync(message);
    //    }
    //}


    public class ProfService : IProfileService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ProfService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var email = context.Subject.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(email);
            var roles = await userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, roles.First()),
                new Claim("role", roles.First())
            };

            context.IssuedClaims.AddRange(claims);
            return;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}








public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly AppDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, AppDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole("Administrator");

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

    }
}