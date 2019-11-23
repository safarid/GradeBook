using System;
using System.Collections;


namespace GradeBook
{
    public class Statistics
    {

        
       public Statistics ()
       {
            highestGrade = double.MinValue;
            lowestGrade = double.MaxValue;
            averageGrade= 0.0;  
       }
       


        public double averageGrade=0.0;
        public double highestGrade=0.0;
        public double lowestGrade=0.0;
    }
}           