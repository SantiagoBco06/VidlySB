using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Customer customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Uknown 
                || customer.MembershipTypeId == MembershipType.PayAsYouGo) 
                return ValidationResult.Success;
            
            if (customer.Birthday == null)
                return new ValidationResult("Tú fecha de cumpleaños es necesaria.");

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;

            return (age >= 18 
                ? ValidationResult.Success 
                : new ValidationResult("El cliente debe de tener mínimo 18 años para tener una membresía."));

        }
    }
}