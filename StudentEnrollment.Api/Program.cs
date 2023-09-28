using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data;

var builder = WebApplication.CreateBuilder(args);


// Add connection string to builder db context
string conn = builder.Configuration.GetConnectionString("StudentEnrollmentDbConnection")!;

builder.Services.AddDbContext<StudentEnrollmentDbContext>(options =>
{
	options.UseSqlServer(conn);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// build CORS policy
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// using CORS policy
app.UseCors("AllowAll");


// GET
///StudentEnrollmentDbContext is from a services above that we already add
app.MapGet("/courses", async (StudentEnrollmentDbContext context) =>
{
	return await context.Courses.ToListAsync();
});

// GET WITH ID
/// This will map id in url parameter into a variable of int id
app.MapGet("/courses/{id}", async (StudentEnrollmentDbContext context, int id) =>
{
	var res = await context.Courses.FindAsync(id);
	return res is Course course ? Results.Ok(res) : Results.NotFound();
});

//POST
app.MapPost("/courses", async (StudentEnrollmentDbContext context, Course course) =>
{
	await context.AddAsync(course);
	await context.SaveChangesAsync();
	return Results.Created($"/api/courses/{course.Id}", course);
});

//PUT
app.MapPut("/courses", async (StudentEnrollmentDbContext context, Course course) =>
{
	bool recordExist = await context.Courses.AnyAsync(row => row.Id == course.Id);
	if (!recordExist) return Results.NotFound();

	context.Update(course);
	await context.SaveChangesAsync();

	return Results.NoContent();
});

//DELETE
app.MapDelete("/courses/{id}", async (StudentEnrollmentDbContext context, int id) =>
{
	Course? record = await context.Courses.FindAsync(id);
	if (record == null) return Results.NotFound();

	context.Remove(record);
	await context.SaveChangesAsync();
	return Results.NoContent();
});

app.Run();

