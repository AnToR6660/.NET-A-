using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormDataRetrive.Models
{
    public class EmailAttribute :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string email) 
            {
                var indexProperty=validationContext.ObjectType.GetProperty("index");
                if (indexProperty == null)
                {
                    return new ValidationResult("Index property not found.");
                }

                
                var indexValue=indexProperty.GetValue(validationContext.ObjectInstance)?.ToString();
                if (email.StartsWith(indexValue))
                {
                    return ValidationResult.Success;
                }
                else 
                {
                    return new ValidationResult("Invalid Email");
                }
            
            
            }
            return ValidationResult.Success;
        }
    }
}