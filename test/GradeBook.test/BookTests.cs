using System;
using Xunit;

namespace GradeBook.test
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arrange
            var book = new InMemoryBook("");
            book.AddGrade(90.0);
            book.AddGrade(80.0);
            book.AddGrade(70.0);
           
                       
        
            //act
              var stats = book.GetStatistics();

            //assert
            Assert.Equal(80, stats.averageGrade);
            Assert.Equal(90.0, stats.highestGrade);
            Assert.Equal(70, stats.lowestGrade);

        }
    }
}

