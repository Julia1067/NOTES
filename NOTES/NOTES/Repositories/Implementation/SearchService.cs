using Microsoft.EntityFrameworkCore;
using NOTES.Data.Domain;
using NOTES.Repositories.Abstract;

namespace NOTES.Repositories.Implementation
{
    public class SearchService : ISearchService
    {
        private readonly DatabaseContext _dbContext;

        public SearchService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<NoteModel>> SearchNotesByNameAsync(string namePart)
        {
            var notes = await _dbContext.Notes.Where(x => x.Name.Contains(namePart)).ToListAsync();

            return notes;
        }

        public async Task<List<NoteModel>> SearchNotesByDescriptionAsync(string descriptionPart)
        {
            var notes = await _dbContext.Notes.Where(x => x.Description.Contains(descriptionPart)).ToListAsync();

            return notes;
        }
    }
}
