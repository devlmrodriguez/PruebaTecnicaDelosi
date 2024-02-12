using FluentValidation;
using PruebaTecnicaDelosi.API.Validators;
using PruebaTecnicaDelosi.Domain.Factories;
using PruebaTecnicaDelosi.Domain.Factories.Interfaces;
using PruebaTecnicaDelosi.Domain.Handlers;
using PruebaTecnicaDelosi.Domain.Models;
using PruebaTecnicaDelosi.Domain.Services;
using PruebaTecnicaDelosi.Domain.Services.Interfaces;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Globalization;

namespace PruebaTecnicaDelosi.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAppServices(this IServiceCollection services)
    {
        // Add rotate matrix factory and handlers
        services.AddTransient<IRotateMatrixFactory>(_ =>
        {
            return new RotateMatrixFactory(new()
            {
                { MatrixRotation.Clockwise, new RotateMatrixClockwiseHandler() },
                { MatrixRotation.CounterClockwise, new RotateMatrixCounterClockwiseHandler() }
            });
        });

        // Add rotate matrix service
        services.AddTransient<IRotateMatrixService, RotateMatrixService>();

        // Add validation config and services
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("es");
        services.AddFluentValidationAutoValidation(configuration =>
        {
            configuration.DisableBuiltInModelValidation = true;
        });
        services.AddScoped<IValidator<int[][]>, SquaredMatrixValidator>();
    }
}
