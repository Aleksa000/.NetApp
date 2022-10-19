using Microsoft.AspNetCore.Identity;
using USP.Data;
using USP.Repositories;
using USP.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(typeof(MapperService));
// Add services to the container.
builder.Services.AddControllersWithViews();

#region Usp services
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();
//nacin zivota odredjenog servisa
#endregion


#region Identity services
//identity service
builder.Services.AddIdentity<User,Role>().AddMongoDbStores<User,Role,Guid>(
    builder.Configuration.GetSection("MongoSettings:Connection").Value,
    builder.Configuration.GetSection("MongoSettings:DatabaseName").Value
).AddSignInManager().AddDefaultTokenProviders();//konfiguracija user i sign in managera
//Identity options
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 5;
    options.Password.RequiredUniqueChars = 5;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

    // Required unique email
    options.User.RequireUniqueEmail = true;

    // Email confirmation settings
    options.SignIn.RequireConfirmedEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie Settings
    options.Cookie.HttpOnly = false;
    options.ExpireTimeSpan = TimeSpan.FromDays(354);

    options.LoginPath = "/user/identity/login";
    options.LogoutPath = "/user/identity/logout";
    options.AccessDeniedPath = "/user/identity/accessdenied";
    options.SlidingExpiration = true;
});
#endregion

#region Authorize services
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));
});
#endregion

#region Class custom services
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name : "areas",
        pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();