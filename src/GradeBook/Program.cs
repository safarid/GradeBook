using System;
using System.Collections.Generic;

namespace GradeBook
{

        class Program
    {

        static void Main(string[] args)
        {
            IBook book = new InMemoryBook("Samin book");
            book.GradeAdded += OnGradeAdded;
            System.Console.WriteLine("after book.gradeadded delegate attached");

            EnterGrades(book);
            var stats = new Statistics();
            //book.Name = "Samin new book";
            stats = book.GetStatistics();

            Console.WriteLine($"The book name {book.Name}");
            Console.WriteLine($"Highest grade is {stats.highestGrade:N1}");
            Console.WriteLine($"Lowest grade is {stats.lowestGrade:N1}");
            Console.WriteLine($"Average grade for {book.Name} is {stats.averageGrade:N2}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {

                System.Console.WriteLine("Please enter a grade or'q' to quit");
                string input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    System.Console.WriteLine("in program - after book.addgradecalled ");
                    //book.AddGrade('A');
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine($"Invalid Argument {ex}");
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine($"Can only enter grades between 0 and 100 {ex}");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex);
                }
            }
        }

        static void OnGradeAdded(object o, EventArgs e){
            System.Console.WriteLine("A grade was added...");
        }           
                
    }
}
