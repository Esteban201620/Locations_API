using LocationsAPI.Dal.Ciudad;
using LocationsAPI.Dal.Departamento;
using LocationsAPI.Dal.Pais;
using LocationsAPI.Resources.Models;
using LocationsAPI.ServiceExtension;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_CorsApiLocations";

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureInterfaces();
builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.AddCors(p => p.AddPolicy(MyAllowSpecificOrigins, build =>
{
    build.WithOrigins("*").WithMethods("PUT", "POST", "GET", "PATCH", "DELETE").AllowAnyHeader();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
	app.UseCors(MyAllowSpecificOrigins);
}

#region Pais

app.MapPost("/api/paises", async (HttpContext context, [FromBody] PaisModel pais, [FromServices] IPaisesDal paisDal)
=> await HandleRequest(() => paisDal.AddPais(pais), context));

app.MapPut("/api/paises/{id}", async (HttpContext context, int id, [FromBody] PaisModel pais, [FromServices] IPaisesDal paisDal)
    => await HandleRequest(() => paisDal.UpdatePais(id, pais), context));

app.MapGet("/api/paises", async (HttpContext context, [FromServices] IPaisesDal processDal)
    => await HandleRequest(() => processDal.GetPaises(), context));

app.MapGet("/api/paises/{id}", async (HttpContext context, int id, [FromServices] IPaisesDal paisDal)
    => await HandleRequest(() => paisDal.GetPaisById(id), context));

app.MapDelete("/api/paises/{id}", async (HttpContext context, int id, [FromServices] IPaisesDal paisDal)
    => await HandleRequest(async () => {
        var deleted = await paisDal.DeletePais(id);
        if (!deleted) throw new Exception("No encontrado");
        return deleted;
    }, context));

#endregion

#region Departamentos

app.MapGet("/api/departamentos/{paisId}", async (HttpContext context, int paisId, [FromServices] IDepartamentosDal dal)
    => await HandleRequest(() => dal.GetDepartamentos(paisId), context));

app.MapPost("/api/departamentos", async (HttpContext context, [FromBody] DepartamentoModel departamento, [FromServices] IDepartamentosDal dal)
    => await HandleRequest(() => dal.AddDepartamento(departamento), context));

app.MapPut("/api/departamentos/{id}", async (HttpContext context, int id, [FromBody] DepartamentoModel departamento, [FromServices] IDepartamentosDal dal)
    => await HandleRequest(() => dal.ModifyDepartamento(id, departamento), context));

app.MapDelete("/api/departamentos/{id}", async (HttpContext context, int id, [FromServices] IDepartamentosDal dal)
    => await HandleRequest(async () => {
        var deleted = await dal.DeleteDepartamento(id);
        if (!deleted) throw new Exception("No encontrado");
        return deleted;
    }, context));

#endregion

#region Ciudades

app.MapGet("/api/ciudades/{departamentoId}", async (HttpContext context, int departamentoId, [FromServices] ICiudadesDal dal)
    => await HandleRequest(() => dal.GetCiudades(departamentoId), context));

app.MapPost("/api/ciudades", async (HttpContext context, [FromBody] CiudadModel ciudad, [FromServices] ICiudadesDal dal)
    => await HandleRequest(() => dal.AddCiudad(ciudad), context));

app.MapPut("/api/ciudades/{id}", async (HttpContext context, int id, [FromBody] CiudadModel ciudad, [FromServices] ICiudadesDal dal)
    => await HandleRequest(() => dal.ModifyCiudad(id, ciudad), context));

app.MapDelete("/api/ciudades/{id}", async (HttpContext context, int id, [FromServices] ICiudadesDal dal)
    => await HandleRequest(async () => {
        var deleted = await dal.DeleteCiudad(id);
        if (!deleted) throw new Exception("No encontrado");
        return deleted;
    }, context));


#endregion

async Task<IResult> HandleRequest<T>(Func<Task<T>> action, HttpContext context)
{
    try
    {
        var result = await action();
        return result != null ? Results.Ok(result) : Results.StatusCode(204);
    }
    catch (Exception e)
    {
        return Results.Problem(detail: e.Message, statusCode: 422, title: "Error General");
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
