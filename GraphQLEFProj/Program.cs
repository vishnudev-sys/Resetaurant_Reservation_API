using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphQLEFProj.Data;
using GraphQLEFProj.Interfaces;
using GraphQLEFProj.Mutation;
using GraphQLEFProj.Queries;
using GraphQLEFProj.Schema;
using GraphQLEFProj.Services;
using GraphQLEFProj.Type;
using Microsoft.EntityFrameworkCore;
using GraphQLEFProj.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//DB Declaration
//UseSqlServer is used for SQL Server, UseNpgsql is used for PostgreSQL
builder.Services.AddDbContext<GraphQLDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


//Service Declaration
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IReservationRepository, ReservationRepository>();
builder.Services.AddTransient<IMenuRepository, MenuRepository>();

//Register the types
builder.Services.AddTransient<MenuType>();
builder.Services.AddTransient<CategoryType>();
builder.Services.AddTransient<ReservationTypes>();

builder.Services.AddTransient<MenuQuery>();
builder.Services.AddTransient<CategoryQuery>();
builder.Services.AddTransient<ReservationQuery>();
builder.Services.AddTransient<RootQuery>();

//The below is not needed as we are using RootSchema which handles everything
//builder.Services.AddTransient<MenuMutation>();
//builder.Services.AddTransient<ISchema, MenuSchema>();

//Mutation types
builder.Services.AddTransient<MenuMutation>();
builder.Services.AddTransient<CategoryMutation>();
builder.Services.AddTransient<ReservationMutation>();
builder.Services.AddTransient<RootMutation>();

//Input Types
builder.Services.AddTransient<MenuInputType>();
builder.Services.AddTransient<CategoryInputType>();
builder.Services.AddTransient<ReservationInputType>();

//Here Ischema interface defines the types of schemas we have
builder.Services.AddTransient<ISchema, RootSchema>();

//AddGraphQL will enabled the GraphQL support in .Net Core
builder.Services.AddGraphQL(b => b.AddAutoSchema<ISchema>().AddSystemTextJson());

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder =>
	builder.WithOrigins("http://localhost:4200")
		   .AllowAnyHeader()
		   .AllowAnyMethod());

app.UseHttpsRedirection();


app.UseGraphiQl("/graphql");
//app.MapGraphQL("/graphql");  // Required: exposes the API endpoint

app.UseGraphQL<ISchema>();
app.UseAuthorization();

app.MapControllers();
app.Run();