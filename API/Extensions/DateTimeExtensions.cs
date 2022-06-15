using System;

namespace API.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateTime dude)
        {
           var today = DateTime.Today; 
           var age = today.Year - dude.Year;

           if (dude.Date > today.AddYears(-age)) 
            age--;

           return age;
        }
        
    }
}