using System;
using System.Collections.Generic;
using System.IO;
//using IBook;
namespace GradeBook
{
    public delegate void GradeAddedDelegate(object o, EventArgs e);
    public class NamedObject
    {
         
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {   
            get; 
            set;
        }  
    }
     public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        event GradeAddedDelegate GradeAdded;
        string Name{get;}
    
    }
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
        public virtual event GradeAddedDelegate GradeAdded;      
    }
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }
        public override event GradeAddedDelegate GradeAdded;
        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine();
            }
            if (GradeAdded != null){
                GradeAdded(this, new EventArgs());
            }
       }
        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }

    #region InMemoryClass
    public class InMemoryBook : Book
    {
        //Adding  new comments to try commit
        public InMemoryBook(string name):base(name)
        {
            grades = new List<double>();
            Name = name;
            category = "";
        }

        public override void AddGrade(double grade)
        {
               
               //category = "testing";
               if (grade>=0 && grade <=100) {
                grades.Add(grade);

                GradeAdded(this, new EventArgs());
                System.Console.WriteLine("in bookclass after gradeadded event ");
               }
               else {
                   //System.Console.WriteLine("Add a valid grade");
                   throw new ArgumentException($"Invalid {nameof(grade)} added, please add valid grade");
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
        
        public override Statistics GetStatistics()
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
        public override event GradeAddedDelegate GradeAdded;
        //instance fields      
        public   List <double> grades;     
        private readonly string category;
    }   
}
#endregion

    
