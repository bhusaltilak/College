using COLLEGE.Data;
<<<<<<< HEAD
using COLLEGE.Filters;
=======
>>>>>>> 5572f4de444e80214a0e803bd53aa8e9f592e0f5
using COLLEGE.Repository;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
<<<<<<< HEAD
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<AdminOnlyAttribute>();
}).AddRazorRuntimeCompilation();
=======
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
>>>>>>> 5572f4de444e80214a0e803bd53aa8e9f592e0f5

builder.Services.AddDbContext<CollegeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentFeeRepository, StudentFeeRepository>();


<<<<<<< HEAD


builder.Services.AddSession();



=======
>>>>>>> 5572f4de444e80214a0e803bd53aa8e9f592e0f5
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

<<<<<<< HEAD





app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseSession();

=======
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

>>>>>>> 5572f4de444e80214a0e803bd53aa8e9f592e0f5
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
