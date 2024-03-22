using NOTES.Repositories.Abstract;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NOTES.Repositories.Implementation
{
    public class DateService : IDateService
    {
        public string GetDateFromCreation(DateTime date)
        {
            DateTime dateTime = DateTime.Now;

            TimeSpan difference = dateTime - date;

            int differenceInHours = (int)difference.TotalHours;
            
            if(differenceInHours <= 24 && differenceInHours >= 1) 
            {
                if(differenceInHours == 1)
                    return $"{differenceInHours} hour ago";
                return $"{differenceInHours} hours ago";
            }
            if(differenceInHours >= 0 && differenceInHours < 1)
            {
                return "right now";
            }
            else
            {
                int differenceInDays = (int)difference.TotalDays;

                if(differenceInDays <= 60) 
                {
                    if(differenceInDays == 1)
                        return $"{differenceInDays} day ago";
                    return $"{differenceInDays} days ago";
                }
                else
                {
                    return $"{date.Year} {date.Month} {date.Day}";
                }
            } 
        }
    }
}
