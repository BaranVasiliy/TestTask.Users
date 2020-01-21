using System;
using System.Net;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Users.Handlers.Abstracts
{
    public abstract class BaseActionHandler<TCommand>
        where TCommand : ICommand<IActionResult>
    {
        public virtual async Task<IActionResult> ExecuteAsync(TCommand command, IActionResult result)
        {
            try
            {
                IActionResult actionResult = await ExecuteAction(command);
                return actionResult;
            }
            catch (Exception exception)
            {
                return ServerError(exception);
            }
        }

        protected abstract Task<IActionResult> ExecuteAction(TCommand command);

        protected IActionResult JsonResult<TModel>(TModel model, HttpStatusCode code)
        {
            JsonResult result = new JsonResult(model)
            {
                StatusCode = (int)code
            };

            return result;
        }

        protected IActionResult Ok<TModel>(TModel model)
        {
            return JsonResult(model, HttpStatusCode.OK);
        }

        protected IActionResult NotFound()
        {
            return new StatusCodeResult((int)HttpStatusCode.NotFound);
        }

        protected IActionResult ServerError(Exception exception)
        {
            return JsonResult(exception, HttpStatusCode.InternalServerError);
        }
    }
}