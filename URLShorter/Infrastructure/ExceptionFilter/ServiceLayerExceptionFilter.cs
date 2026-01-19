using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using URLShorter.Services.ServiceLayerExceptions;

namespace URLShorter.Infrastructure.ExceptionFilter;

public class ServiceLayerExceptionFilter : Attribute, IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var e = context.Exception;
        var statusCode = HttpStatusCode.InternalServerError;
        switch (e)
        {
            case EntityNotFound:
                statusCode = HttpStatusCode.NotFound;
                break;
            case EntityAlreadyExists:
                statusCode = HttpStatusCode.Conflict;
                break;
            case InvalidData:
                statusCode = HttpStatusCode.BadRequest;
                break;
        }

        context.Result = new ObjectResult(new
        {
            message = e.Message,
            error = "ServiceLayerExceptionFilter",
            timestamp = DateTime.UtcNow
        })
        {
            StatusCode = (int)statusCode
        };
        context.ExceptionHandled = true;
    }
}