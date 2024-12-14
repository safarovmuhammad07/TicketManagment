using DoMain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
// English: Creates a builder for setting up the web application with command-line arguments.
// Russian: Создает билдер для настройки веб-приложения с аргументами командной строки.

builder.Services.AddControllers();
// English: Registers services for MVC controllers, which are necessary for building APIs with controllers.
// Russian: Регистрирует службы для контроллеров MVC, которые необходимы для создания API с использованием контроллеров.

builder.Services.AddEndpointsApiExplorer();
// English: Registers services required for exploring API endpoints and generating metadata.
// Russian: Регистрирует службы, необходимые для исследования конечных точек API и генерации метаданных.

builder.Services.AddSwaggerGen();
// English: Registers services for generating Swagger API documentation, which includes a UI for testing API endpoints.
// Russian: Регистрирует службы для генерации документации API Swagger, которая включает интерфейс для тестирования конечных точек API.

builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ITicketLocationService, TicketLocationService>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();

var app = builder.Build();
// English: Builds the web application using the configured services and settings from the builder.
// Russian: Создает веб-приложение, используя настроенные службы и параметры из билдера.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
    // English: If the environment is "Development", enable Swagger to generate API documentation and provide a UI for testing API endpoints.
    // Russian: Если окружение "Разработка", включает Swagger для генерации документации API и предоставляет интерфейс для тестирования конечных точек API.
}

app.UseAuthorization();
// English: Adds authorization middleware to the pipeline, which will enforce authorization policies for incoming requests.
// Russian: Добавляет промежуточное ПО авторизации в конвейер, которое будет применять политики авторизации к входящим запросам.

app.MapControllers();
// English: Maps all the controller actions to the HTTP request pipeline, so the app can handle incoming requests.
// Russian: Отображает все действия контроллеров в конвейер обработки HTTP-запросов, чтобы приложение могло обрабатывать входящие запросы.

app.Run();
// English: Starts the web application and begins listening for incoming HTTP requests.
// Russian: Запускает веб-приложение и начинает прослушивание входящих HTTP-запросов.
