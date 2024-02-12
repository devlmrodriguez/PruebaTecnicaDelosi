using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaDelosi.Domain.Models;
using PruebaTecnicaDelosi.Domain.Services.Interfaces;

namespace PruebaTecnicaDelosi.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Consumes("application/json")]
[Produces("application/json")]
public class RotateMatrixController : ControllerBase
{
    private readonly IRotateMatrixService _rotateMatrixService;
    private readonly ILogger<RotateMatrixController> _logger;

    public RotateMatrixController(IRotateMatrixService rotateMatrixService, ILogger<RotateMatrixController> logger)
    {
        _rotateMatrixService = rotateMatrixService;
        _logger = logger;
    }

    [HttpPost(Name = "Clockwise")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<int[][]> Clockwise([FromBody] int[][] matrix)
    {
        try
        {
            var rotatedMatrix = _rotateMatrixService.Rotate(matrix, MatrixRotation.Clockwise);
            return Ok(rotatedMatrix);
        }
        catch (Exception ex)
        {
            _logger.LogError("InternalServerError: {ExceptionMessage}", ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost(Name = "CounterClockwise")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<int[][]> CounterClockwise([FromBody] int[][] matrix)
    {
        try
        {
            var rotatedMatrix = _rotateMatrixService.Rotate(matrix, MatrixRotation.CounterClockwise);
            return Ok(rotatedMatrix);
        }
        catch (Exception ex)
        {
            _logger.LogError("InternalServerError: {ExceptionMessage}", ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
