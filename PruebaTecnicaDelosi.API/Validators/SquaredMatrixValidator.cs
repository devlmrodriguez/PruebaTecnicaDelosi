using FluentValidation;

namespace PruebaTecnicaDelosi.API.Validators;

public class SquaredMatrixValidator : AbstractValidator<int[][]>
{
    public SquaredMatrixValidator()
    {
        RuleFor(x => x).NotNull().NotEmpty().WithName("Matriz");
        RuleFor(x => x).Custom((matrix, context) =>
        {
            var matrixLength = matrix.Length;
            for (int i = 0; i < matrixLength; i++)
            {
                if (matrix[i].Length != matrixLength)
                {
                    context.AddFailure("Matriz", "'Matriz' debería ser cuadrada.");
                    break;
                }
            }
        });
    }
}
