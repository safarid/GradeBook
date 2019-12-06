using System;
using Xunit;

namespace GradeBook.test
{
    public class TypeTests
    {
        public delegate string WriteLogDelegate(string Message);
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
        //Given
        WriteLogDelegate log;
        log = ReturnMessage;
        //When
        var result = log("Hello");
        
        //Then
        Assert.Equal("Hello", result);
        }
        public string ReturnMessage(String msg)
        {
            return msg;
        } 

        [Fact]
        public void cSharpPassByRef()
        {
            //var book1 = GetBook("Book1");
            InMemoryBook book1;
            getBookSetName(out book1, "new nameout");

            Assert.Equal("namedincallingfunction", book1.Name);
        }

        private void getBookSetName(out InMemoryBook book1, string name)
        {
           
            //x
            book1 = new InMemoryBook(name);
            book1.Name = "namedincallingfunction";

        }
                
        [Fact]
        public void cSharpIsPassByValue()
        {
            var book1 = GetBook("Book1");
            getBookSetName(book1, "new name");

            Assert.Equal("Book1", book1.Name);
        }

        private void getBookSetName(InMemoryBook book1, string name)
        {
            book1 = new InMemoryBook(name);
        }
 
        [Fact]
        public void CanSetNameByReference()
        {
            var book1 = GetBook("Book1");
            setBookName(book1, "name1");

            Assert.Equal("name1", book1.Name);
        }

        private void setBookName(InMemoryBook book1, string name)
        {
            book1.Name = name;

        }

        [Fact]
        public void DiffVariablesCanReferenceSameObject()
        {
            var  book1 = GetBook("Book1");
            var book2 = book1;

            Assert.Same(book2, book1);
            Assert.True(Object.ReferenceEquals(book1, book2));
            //Assert.Equal("Book2", book2.Name);
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var  book1 = GetBook("Book1");
            var book2 = GetBook("Book2");

            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
        }

        InMemoryBook GetBook(String name)
        {
            return (new InMemoryBook(name));
        }
    }
}

