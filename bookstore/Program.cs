
using bookstore.Data.Services;
using bookstore.Data.Services.CategoryServices;
using bookstore.Data.Services.AuthorServices;
using bookstore.Data.Services.BookServices;
using bookstore.Data.Services.RenterServices;
using bookstore.Data.Services.AuthorBookServices;
using bookstore.Data.Services.CategoryBookServices;
using bookstore.Data.Services.RentOrderServices;
using bookstore.Models;
using bookstore.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<bookstore.Data.ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IRenterService, RenterService>();
builder.Services.AddScoped<IBookService, BookService>();
//builder.Services.AddScoped<ICategoryBookService, CategoryBookService>();
builder.Services.AddScoped<IAuthorBookService, AuthorBookService>();
builder.Services.AddScoped<IRentOrderService,RentOrderService >();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorBookRepository, AuthorBookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryBookRepository, CategoryBookRepository>();
builder.Services.AddScoped<IRenterRepository, RenterRepository>();
builder.Services.AddScoped<IRentOrderRepository, RentOrderRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseWebSockets();

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

/*app.MapControllerRoute(
    name: "allbook",
    pattern: "{controller=Book}/{action=Index}");

app.MapControllerRoute(
    name: "detailbook",
    pattern: "{controller=Book}/{action=Detail}/{id?}"
    );

app.MapControllerRoute(
    name: "categorybook",
    pattern: "{controller=Book}/{action=IndexByCategory}/{id?}"
    );

app.MapControllerRoute(
    name: "allcategory",
    pattern: "{controller=Cateory}/{action=Index}/{id?}");*/



app.Run();
