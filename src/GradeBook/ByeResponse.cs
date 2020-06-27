using System;


namespace GradeBook
{
    public class ByeResponse
    {
        private string noAnswer = "no";
        private string yesAnswer = "yes";
        private readonly string _message;
        public ByeResponse(string message)
        {
             _message = message;

            Console.WriteLine("All done now? yes/no\n");
            var byeResponse = Console.ReadLine().ToLower();
            Console.WriteLine(" ...very well\n");
            
            if (byeResponse == yesAnswer)
            {
                Console.WriteLine("press any key to exit\n");
                Console.ReadLine();
            }
            else if (byeResponse == noAnswer)
            {
                Console.WriteLine("How about a nice game of chess then?\n");
                Console.WriteLine("press enter to exit\n");
                Console.ReadLine();
            }

        }
    }
}