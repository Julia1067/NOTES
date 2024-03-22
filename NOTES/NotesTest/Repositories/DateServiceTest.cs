using Microsoft.Extensions.DependencyInjection;
using NOTES.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesTest.Repositories
{
    public class DateServiceTest
    {
        private readonly IDateService _dateService;

        public DateServiceTest() 
        {
            var helperProvider = Helper.Provider();
            _dateService = helperProvider.GetRequiredService<IDateService>();
        }

        [Test]
        public void DateService_GetDateFromCreation_ReturnsString()
        {
            //Arrange
            DateTime date = DateTime.Now;

            string expectationString = "right now";

            //Act
            string actString = _dateService.GetDateFromCreation(date);

            //Assert
            Assert.That(actString, Is.EqualTo(expectationString));
        }
    }
}
