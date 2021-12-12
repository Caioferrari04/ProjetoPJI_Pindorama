using System;
using System.ComponentModel.DataAnnotations;

namespace Pindorama.Services
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        int _minimumAge;
        int _maximumAge;

        public MinimumAgeAttribute(int minimumAge, int maximumAge)
        {
            _minimumAge = minimumAge;
            _maximumAge = maximumAge;
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                if(date.AddYears(_maximumAge) >= DateTime.Now && date.AddYears(_minimumAge) < DateTime.Now)
                {
                    return true;
                }
                return false;
            }

            return false;
        }
    }
}
