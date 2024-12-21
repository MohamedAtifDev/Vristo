
using System.Text;

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace VristoAPI.Application.Services
{
    public static  class ErrorsHandler 
    {
      
        public static string HandleErrors(ModelStateDictionary Model)
        {

            var message = string.Empty;
            foreach (var entry in Model)
            {
                // entry.Key represents the name of the property
                // entry.Value.Errors contains a collection of errors for that property
                foreach (var error in entry.Value.Errors)
                {
                    // Display the error message
                    string errorMessage = error.ErrorMessage;
                    // You can log this error or add it to a list to show in the view
                    message += $"{entry.Key}: {errorMessage};";
                }
            }
            return message;
        }
    }
}
