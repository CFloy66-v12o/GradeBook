using System;



namespace GradeBook
{
    public class Program  
    {
        
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine($"Hello, {args[2]}!");
            }
            else
            {
                Console.WriteLine("Hello!\n");
            }

           

            Book book = new Book("Chris's Gradebook");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            
            
            while(true)
            {
                Console.WriteLine("Enter a grade or press 'q' to quit and calculate grades: \t");
                var userInput = Console.ReadLine();
                    if(userInput == "q")
                    {
                        break;
                    } 
             try
             {
                var grade = double.Parse(userInput);
                book.AddGrade(grade);
                //....
             }
             catch(ArgumentException)
             {
                 Console.WriteLine("Keep it between 0-100");
             }
             catch(FormatException)
             {
                 Console.WriteLine("Numbers please");
             }
                
            }   
            
            
            
            var stats = book.GetStatistics();
            
            Console.WriteLine($"For the book named: {book.Name}");
            Console.WriteLine($"The high grade is:  {stats.High:n1}\n");
            Console.WriteLine($"The low grade is: {stats.Low:n1}\n");
            Console.WriteLine($"The average grade is: {stats.Average:n1}\n");
            Console.WriteLine($"This averages out to a letter grade of: {stats.Letter}");
            
            ByeResponse goodbye = new ByeResponse("Goodbye");
            static void OnGradeAdded(object sender, EventArgs e)
            {
                Console.WriteLine("A grade was added..");
            }
            
        }
    }
}
