namespace kea_part1
{
    public class Program
    {
        private static string userInput;

        static void Main(string[] args)
        {
            //creating instance for voice_over
            new voice_over() { };

            new logo() { };

            //creating an instance for Chatbot
            Chatbot chatbot = new Chatbot();
            string response = chatbot.GenerateResponse(userInput);

            //creating an instance for chatbot*
            new Chatbot() { };

            //creating an instance for security_awe
            new security_awe() { };

            //creating an instance for MemoryRecall_generic
            new MemoryRecall_generics() { };
        }
    }
}


