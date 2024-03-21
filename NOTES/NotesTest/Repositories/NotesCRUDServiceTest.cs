using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NOTES.Data.Domain;
using NOTES.Data.DTO;
using NOTES.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NotesTest.Repositories
{
    [TestFixture]
    public class NoteCRUDService
    {
        private readonly INotesCRUDService _notesCRUDService;
        private readonly DatabaseContext _dbContext;
        static int counter = 0; //To count creation of new Notes

        public NoteCRUDService()
        {
            var serviceProvider = Helper.Provider();
            _dbContext = serviceProvider.GetRequiredService<DatabaseContext>();
            _notesCRUDService = serviceProvider.GetRequiredService<INotesCRUDService>();
            InitializePrimaryNotes();
        }

        private async void InitializePrimaryNotes()
        {
            NoteModel note1 = new()
            {
                NoteId = "3c03452e-57b8-4fc3-8e90-5c1c21b0b5b1",
                Name = "Test",
                Description = "Test Description",
                CreationDate = new DateTime(2024, 3, 21, 9, 50, 22),
                LastUpdateDate = new DateTime(2024, 3, 21, 9, 50, 22)
            };
            counter++;

            NoteModel note2 = new()
            {
                NoteId = "d7c09777-1a84-4e05-9c6a-47d1d88f0112",
                Name = "Test",
                Description = "Test Description",
                CreationDate = new DateTime(2024, 3, 21, 9, 50, 22),
                LastUpdateDate = new DateTime(2024, 3, 21, 9, 50, 22)
            };
            counter++;

            NoteModel note3 = new()
            {
                NoteId = "b5481a02-9235-43b3-af31-36d4e94659ad",
                Name = "Test",
                Description = "Test Description",
                CreationDate = new DateTime(2024, 3, 21, 9, 50, 22),
                LastUpdateDate = new DateTime(2024, 3, 21, 9, 50, 22)
            };
            counter++;

            await _dbContext.Notes.AddRangeAsync(note1, note2, note3);

            await _dbContext.SaveChangesAsync();
        }

        [Test]
        public async Task NoteCRUDService_CreateNoteAsync_ReturnsStatusModel()
        {
            //Arrange
            CreateNoteModel note = new()
            {
                Id = "e56d91d2-4b29-4b79-b4c0-894a6b2cd23f",
                Name = "Test",
                Description = "Test Description",
                CreationDate = new DateTime(2024, 3, 21, 9, 50, 22),
                LastUpdateDate = new DateTime(2024, 3, 21, 9, 50, 22)
            };

            //Act
            var result = await _notesCRUDService.CreateNoteAsync(note);
            counter++;

            //Assert
            StatusModel model = new()
            {
                Status = true,
                Message = "Note successfully created"
            };

            Assert.Multiple(() =>
            {
                Assert.That(result.Status, Is.EqualTo(model.Status));
                Assert.That(result.Message, Is.EqualTo(model.Message));
            });
        }

        [Test]
        public async Task NoteCRUDService_UpdateNoteAsync_ReturnsStatusModel()
        {
            //Arrange
            CreateNoteModel note = new()
            {
                Id = "3c03452e-57b8-4fc3-8e90-5c1c21b0b5b1",
                Name = "Test1",
                Description = "Test Description1"
            };

            //Act
            var result = await _notesCRUDService.UpdateNoteAsync(note);

            //Assert
            StatusModel model = new()
            {
                Status = true,
                Message = "Note successfully updated"
            };
            Assert.Multiple(() =>
            {
                Assert.That(result.Message, Is.EqualTo(model.Message));
                Assert.That(result.Status, Is.EqualTo(model.Status));
            });
        }

        [Test]
        public async Task NoteCRUDService_DeleteNoteAsync_ReturnsStatusModel()
        {
            //Arrange
            var idToDelete = "d7c09777-1a84-4e05-9c6a-47d1d88f0112";

            //Act
            var result = await _notesCRUDService.DeleteNoteAsync(idToDelete);
            counter--;

            //Assert
            StatusModel model = new()
            {
                Status = true,
                Message = "Note successfully deleted"
            };
            Assert.Multiple(() =>
            {
                Assert.That(result.Message, Is.EqualTo(model.Message));
                Assert.That(result.Status, Is.EqualTo(model.Status));
            });
        }

        [Test]
        public async Task NoteCRUDService_GetNotesAsync_ReturnsNoteModel()
        {
            //Arrange
            int notesCount = counter;

            //Act
            var notesList = await _notesCRUDService.GetNotesAsync();

            //Assert
            Assert.That(notesList, Has.Count.EqualTo(notesCount));
        }

        [Test]
        public async Task NoteCRUDService_GetCurretNoteAsync_ReturnsNoteModel()
        {
            //Arrange
            NoteModel model = new()
            {
                NoteId = "b5481a02-9235-43b3-af31-36d4e94659ad",
                Name = "Test",
                Description = "Test Description",
                CreationDate = new DateTime(2024, 3, 21, 9, 50, 22),
                LastUpdateDate = new DateTime(2024, 3, 21, 9, 50, 22)
            };

            //Act
            var note = await _notesCRUDService.GetCurretNoteAsync(model.NoteId);

            //Assert
            Assert.That(note.NoteId, Is.EqualTo(model.NoteId));
        }
    }
}


