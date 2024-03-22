using Microsoft.Extensions.DependencyInjection;
using NOTES.Data.Domain;
using NOTES.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesTest.Repositories
{
    [TestFixture]
    public class SearchServiceTest
    {
        private readonly ISearchService _searchService;
        private readonly DatabaseContext _dbContext;

        public SearchServiceTest()
        {
            var serviceProvider = Helper.Provider();

            _searchService = serviceProvider.GetRequiredService<ISearchService>();
            _dbContext = serviceProvider.GetRequiredService<DatabaseContext>();
        }

        [Test]
        public async Task SearchService_SearchNotesByNameAsync_ReturnsListOfNotes()
        {
            //Arrange
            NoteModel note1 = new()
            {
                NoteId = "3c03452e-57b8-4fc3-8e90-5c1c21b0b5b1",
                Name = "Test1",
                Description = "Test Description",
                CreationDate = new DateTime(2024, 3, 21, 9, 50, 22),
                LastUpdateDate = new DateTime(2024, 3, 21, 9, 50, 22)
            };

            NoteModel note2 = new()
            {
                NoteId = "d7c09777-1a84-4e05-9c6a-47d1d88f0112",
                Name = "Test2",
                Description = "Test Description",
                CreationDate = new DateTime(2024, 3, 21, 9, 50, 22),
                LastUpdateDate = new DateTime(2024, 3, 21, 9, 50, 22)
            };

            NoteModel note3 = new()
            {
                NoteId = "b5481a02-9235-43b3-af31-36d4e94659ad",
                Name = "Test3",
                Description = "Test Description",
                CreationDate = new DateTime(2024, 3, 21, 9, 50, 22),
                LastUpdateDate = new DateTime(2024, 3, 21, 9, 50, 22)
            };

            await _dbContext.Notes.AddRangeAsync(note1, note2, note3);

            await _dbContext.SaveChangesAsync();

            var count = 3;

            //Act
            var notes = await _searchService.SearchNotesByNameAsync("Test");

            //Assert
            Assert.That(notes.Count, Is.EqualTo(count));
        }
        
        [Test]
        public async Task SearchService_SearchNotesByDescriptionAsync_ReturnsListOfNotes()
        {
            //Arrange
            var count = 3;

            //Act
            var notes = await _searchService.SearchNotesByDescriptionAsync("Test");

            //Assert
            Assert.That(notes.Count, Is.EqualTo(count));
        }
    }
}
