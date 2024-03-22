using NOTES.Data.Domain;

namespace NOTES.Repositories.Abstract
{
    public interface ISearchService
    {
        public Task<List<NoteModel>> SearchNotesByNameAsync(string namePart);
       
        public Task<List<NoteModel>> SearchNotesByDescriptionAsync(string descriptionPart);
    }
}
