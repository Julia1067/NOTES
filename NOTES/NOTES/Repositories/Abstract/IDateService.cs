using System.Reflection.Metadata.Ecma335;

namespace NOTES.Repositories.Abstract
{
    public interface IDateService
    {
        public string GetDateFromCreation(DateTime date);
    }
}
