using System;

namespace GameOfLife
{
    public class ConsoleOperations:ICommunicationOperations
    {
        public void WriteLine(string content)
        {
            Console.WriteLine(content);
        }
        
        public void Write(string content)
        {
            Console.Write(content);
        }

        public string Read()
        {
            return Console.ReadLine();
        }

        public void Clear()
        { 
            Console.Clear();
        }
    }
}