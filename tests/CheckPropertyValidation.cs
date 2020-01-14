using System;
using NUnit.Framework;
using Baloon_AB.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;    

namespace tests
{

    public class CheckPropertyValidation    
    {    
        public  List<ValidationResult> myValidation(object model)    
        {    
            var result = new List<ValidationResult>();    
            var validationContext = new ValidationContext(model);    
            Validator.TryValidateObject(model, validationContext, result, true);    
            if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);    
            return result;    
        }    

    }    
}
