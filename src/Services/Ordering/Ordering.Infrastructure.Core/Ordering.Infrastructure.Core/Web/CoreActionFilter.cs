
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Ordering.Application.Infrastructure.Core.Web
{
    public class CoreActionFilter : IActionFilter
    { 
        
        //protected ILog Logger
        //{
        //    get
        //    {
        //        return IOCManager.Instance.Resolve<ILog>();
        //    }
        //}  
        public void OnActionExecuting(ActionExecutingContext context)
        { 
            var coreController = (CoreController)context.Controller;

            //if (!context.ModelState.IsValid)
            //{
            //    List<ValidationError> errors = new List<ValidationError>();

            //    foreach (var state in context.ModelState)
            //    {
            //        foreach (var error in state.Value.Errors)
            //        {
            //            errors.Add(new ValidationError("5002", new LocalizedFieldResult(error.ErrorMessage, error.ErrorMessage)));
            //        }
            //    }
            //    context.Result = coreController.BadRequestResponse(errors);
            //} 
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
