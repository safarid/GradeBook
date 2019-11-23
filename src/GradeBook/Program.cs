using System;
using System.Collections.Generic;

namespace GradeBook
{
        class Program
    {
        static void Main(string[] args)
        {
             
            double grade;
            string input;

            Book book = new Book("Samin book");
            while(true){
                
                System.Console.WriteLine("Please enter a grade or'q' to quit");
                input = Console.ReadLine();
                if(input == "q"){
                    break;
                }
                try{
                    grade = double.Parse(input);
                    book.AddGrade(grade);
                    book.AddGrade('A');
                }
                catch(ArgumentException ex){
                    System.Console.WriteLine( $"Invalid Argument {ex}");
                }
                catch(FormatException ex){
                    System.Console.WriteLine($"Can only enter grades between 0 and 100 {ex}");
                }
                catch(Exception ex){
                    System.Console.WriteLine(ex);
                }
            }
                       
                                 
            // var book = new Book("Sam's Gradebook");
            // book.AddGrade(80.1);
            // book.AddGrade(60.1);
            // book.AddGrade(77.1);
            // book.AddGrade(88.1);
            // book.AddGrade(80.1);
            // book.AddGrade(90.9);
           
            var stats = new Statistics();
            //book.Name = "Samin new book";
            stats =  book.GetStatistics();
            System.Console.WriteLine($"The book name {book.Name}");
            Console.WriteLine($"Highest grade is {stats.highestGrade:N1}");
            Console.WriteLine($"Lowest grade is {stats.lowestGrade:N1}");
            Console.WriteLine($"Average grade for {book.Name} is {stats.averageGrade:N2}");
        }            
                
    }
}
