using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FulStackDeveloperTask.App.Validation
{
    public class MaxLongValidationAttribute : ValidationAttribute
    {
        private readonly long _maxValue;

        public MaxLongValidationAttribute(long maxValue)
        {
            _maxValue = maxValue;
        }

        public override bool IsValid(object value)
        {
            return (long)value <= _maxValue;
        }
    }
}