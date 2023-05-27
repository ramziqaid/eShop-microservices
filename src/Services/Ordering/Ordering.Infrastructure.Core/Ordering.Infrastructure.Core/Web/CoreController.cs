
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Linq;
namespace Ordering.Application.Infrastructure.Core.Web
{
    [ServiceFilter(typeof(CoreActionFilter))]
    public class CoreController : ControllerBase
    {

        //protected ILog Logger
        //{
        //    get
        //    {
        //        return IOCManager.Instance.Resolve<ILog>();
        //    }
        //}


        //protected IActionResult HandleResponse<T>(ExecutionResponse<T> response) =>
        //     HandleResponse(response, () =>
        //     {
                
        //         IActionResult action = null;

        //         switch (response.Type)
        //         {
        //             case ResponseState.Success:
        //                 return SucceedResponse(response.Result);


        //             case ResponseState.ValidationError:
        //                 action = BadRequestResponse(response.ValidationErrors, false);
        //                 break;

        //             case ResponseState.Failure:
        //                 action = ErrorResponse(HttpStatusCode.InternalServerError);
        //                 break;

        //             default:
        //                 action = ErrorResponse(HttpStatusCode.InternalServerError);
        //                 break;
        //         } 
        //         return action;
        //     });

        //protected IActionResult HandleResponse<T>(ExecutionResponse<T> response, Func<IActionResult> succeedFunc = null)
        //{ 
        //    IActionResult action = null;

        //    switch (response.Type)
        //    {
        //        case ResponseState.Success:
        //            if (succeedFunc != null)
        //            {
        //                action = succeedFunc();
        //            }
        //            break;

        //        case ResponseState.SuccessWithWarning:
        //            if (succeedFunc != null)
        //            {
        //                action = succeedFunc();
        //            }
        //            break;

        //        case ResponseState.ValidationError:
        //            action = BadRequestResponse(response.ValidationErrors, false);
        //            break;

        //        case ResponseState.Failure:
        //            if (response.ValidationErrors != null && response.ValidationErrors.Count > 0)
        //            {
        //                action = BadRequestResponse(response.ValidationErrors, false);
        //                break;
        //            }
        //            action = ErrorResponse(HttpStatusCode.InternalServerError);
        //            break;

        //        default:
        //            action = ErrorResponse(HttpStatusCode.InternalServerError);
        //            break;
        //    }

        //    return action;
        //}
        //string GetValueFromRequestHeader(string key)
        //{
        //    string defaultValue = null;
        //    if (HttpContext.Request.Headers.TryGetValue(key, out StringValues headerValues) && headerValues.Any())
        //    {
        //        return headerValues;
        //    }
        //    return defaultValue;
        //}
        //public IActionResult ErrorResponse(HttpStatusCode statusCode)
        //{
        //    var response = buildResponseStructure();
        //    response.IsSuccess = false;
        //    var result = new ObjectResult(response)
        //    {
        //        StatusCode = (int)statusCode
        //    };

        //    return result;
        //}
        //public IActionResult SucceedResponse(object result = null)
        //{
        //    var response = buildResponseStructure(result: result);
        //    response.IsSuccess = true;
        //    return Ok(response);
        //}

        //public IActionResult BadRequestResponse(List<ValidationError> errors, bool logErrors = true)
        //{

        //    if (logErrors)
        //        this.Logger.Error("Validations Error", new { Errors = errors });

        //    var response = buildResponseStructure(errors: errors);
        //    response.IsSuccess=false;
            

        //    return Ok(response);
        //}



        //private PortalResponse buildResponseStructure(object result = null, List<ValidationError> errors = null)
        //{
        //    PortalResponse response = new PortalResponse();

        //    if (result != null)
        //        response.ResultData = result;
        //    response.MessageId = GetValueFromRequestHeader("messageId");
        //    if (errors != null)
        //    { 
        //        response.ErrorCode = errors[0].Code;
        //        response.ErrorMessage = errors[0].Message;
        //    }
             
        //    return response;
        //} 
    } 

}
