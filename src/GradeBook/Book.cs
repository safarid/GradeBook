using System;
using System.Collections.Generic;
namespace GradeBook
{
    public class Book
    {
        //Adding  new comments to try commit
        
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
            category = "";

        }
        
        public void AddGrade(double grade)
        {
               
               //category = "testing";
               if (grade>=0 && grade <=100) {
                grades.Add(grade);
               }
               else {
                   //System.Console.WriteLine("Add a valid grade");
                   throw new ArgumentException($"Invalid {nameof(grade)}");
               }
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {   
                case 'A':
                    AddGrade(90.0);
                    break;
                
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        
        public Statistics GetStatistics()
        {

            var stats = new Statistics();
              
            var result = 0.0;
            foreach(var grade in grades)
            {
                
                stats.highestGrade = Math.Max(stats.highestGrade, grade);
                stats.lowestGrade = Math.Min(stats.lowestGrade, grade);
                // if(grade> highestGrade){
                //     highestGrade = grade;
                // }
                // if(grade<lowestGrade){
                //     lowestGrade = grade;
                // }
                result+=grade;
            }
               
            stats.averageGrade = result/grades.Count;
            return stats;
        }
     
        //instance fields      
        public   List <double> grades;

        public string Name
        {   
            get; 
            set;
        }
        private readonly string category;
    }   
}
    
