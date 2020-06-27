using System;
using System.Collections.Generic;


namespace GradeBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book 
    {
        
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public  string _name;
        public  List<double> grades; //field
        

        public Book(string name)
        {
            _name = name;
            grades = new List<double>();
        }
        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

            } else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public event GradeAddedDelegate? GradeAdded;

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average =0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            
            var i = 0;
            while(i < grades.Count)
            {
                result.High = Math.Max(grades[i], result.High);
                result.Low = Math.Min(grades[i], result.Low);
                result.Average += grades[i];
                i++;
            } 
            result.Average /= grades.Count;

            switch(result.Average)
            {
                case var g when g >= 90.0:
                    result.Letter =  'A';
                    break;

                case var g when g >= 80.0:
                    result.Letter =  'B';
                    break;

                 case var g when g >= 70.0:
                    result.Letter =  'C';
                     break;

                 case var g when g >= 60.0:
                    result.Letter =  'D';
                    break;

                default:
                     result.Letter = 'F';
                    break;
            }

            return result;
        }
    }
}