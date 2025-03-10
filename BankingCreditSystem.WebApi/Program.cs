using BankingCreditSystem.Application;
using BankingCreditSystem.Core.Application.Authorization;
using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Middlewares;
using BankingCreditSystem.Core.Security.Encryption;
using BankingCreditSystem.Core.Security.JWT;
using BankingCreditSystem.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);


builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection("TokenOptions"));
builder.Services.AddScoped<ITokenHelper, JwtHelper>();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>),typeof(AuthorizationBehavior<,>));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var tokenOptions= builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        options.TokenValidationParameters = new TokenValidationParameters
        { 
            ValidateIssuer=true,        
            ValidateAudience=true,        
            ValidateLifetime=true,        
            ValidIssuer=tokenOptions.Issuer,        
            ValidAudience=tokenOptions.Audience,        
            ValidateIssuerSigningKey=true,
            IssuerSigningKey= SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseCustomExceptionMiddleware();
app.UseAuthorization();
app.MapControllers();

app.Run();

