using System;
using System.Collections.Generic;
using System.Linq;

namespace kea_part1
{
    public class SecurityAwe
    {
        string name = string.Empty;
        public SecurityAwe()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*--------------------------------------------------------------------*");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("|                    CYBERSECURITY AWARENESS CHATBOT :)              |");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*--------------------------------------------------------------------*");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Chatbot: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please enter your name:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{name}: ");
            Console.ForegroundColor = ConsoleColor.White;

            
            while (string.IsNullOrWhiteSpace(name))
            {
                name = Console.ReadLine();
                name = string.IsNullOrWhiteSpace(name) ? "" : name;
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Please enter a valid name:");
                }
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Hello " + name + ", nice to meet you!");

            string favoriteTopic = string.Empty;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("What is your favorite topic in cybersecurity?");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{name}: ");
            Console.ForegroundColor = ConsoleColor.White;

            while (string.IsNullOrWhiteSpace(favoriteTopic))
            {
                favoriteTopic = Console.ReadLine();
                favoriteTopic = string.IsNullOrWhiteSpace(favoriteTopic) ? "" : favoriteTopic;
                if (string.IsNullOrEmpty(favoriteTopic))
                {
                    Console.WriteLine("Please enter a valid topic:");
                }
            }

            Console.WriteLine($"Great to know that you're interested in {favoriteTopic}. Let's get started!");
            ConversationLoop(name, favoriteTopic);
        }

        public void ConversationLoop(string name, string favoriteTopic)
        {
            string[] skipWords = new[] { "tell", "me", "about" };
            Random rand = new Random();

            Dictionary<string, string[]> topicResponses = new Dictionary<string, string[]>
            {
                { "password safety", new[] {
                    "Create a password at least 12 characters long.",
                    "Use a combination of lowercase, uppercase, numbers, and special characters.",
                    "Use a password manager to generate and store passwords."
                }},
                { "phishing", new[] {
                    "Avoid clicking on suspicious links.",
                    "Always verify the sender's email address.",
                    "Never share personal info over email."
                }},
                { "safe browsing", new[] {
                    "Always check for HTTPS in the URL.",
                    "Don’t download software from untrusted sources.",
                    "Avoid visiting suspicious websites."
                }},
                { "privacy", new[] {
                    "Adjust your social media privacy settings regularly.",
                    "Avoid oversharing personal information online.",
                    "Use privacy-focused search engines like DuckDuckGo."
                }},
                { "ransomware", new[] {
                    "Regularly back up important files.",
                    "Avoid opening attachments from unknown senders.",
                    "Keep your operating system up to date."
                }},
                { "identity theft", new[] {
                    "Shred documents with personal information before discarding.",
                    "Use credit monitoring services.",
                    "Check your bank statements regularly."
                }},
                { "scam", new[] {
                    "Don’t trust messages asking for urgent money transfers.",
                    "Double-check with the source before acting on strange requests.",
                    "Report scams to authorities."
                }},
                { "malware", new[] {
                    "Use antivirus software and keep it updated.",
                    "Be cautious when downloading from the internet.",
                    "Avoid clicking unknown links."
                }},
                { "social engineering", new[] {
                    "Don’t give out personal info without verification.",
                    "Learn how attackers manipulate trust.",
                    "Always verify before taking action on suspicious messages."
                }}
            };

            string[] greetings = {
                "What would you like to learn about today?",
                "Need help with something specific in cybersecurity?",
                "Ask me anything about digital safety!",
                "Which cybersecurity topic can I assist you with?",
                "Let’s explore how you can stay safe online!"
            };

            string[] followUps = {
                "Anything else you'd like to ask?",
                "Would you like more tips?",
                "Feel free to ask about another topic.",
                "Want to explore another cybersecurity area?",
                "I'm here if you have more questions!"
            };

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Chatbot: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(greetings[rand.Next(greetings.Length)]);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(name + ": ");
                Console.ForegroundColor = ConsoleColor.White;
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "exit")
                    break;

                string sentimentResponse = DetectSentiment(userInput);
                if (!string.IsNullOrEmpty(sentimentResponse))
                {
                    RespondToUser(sentimentResponse);
                }

                string cleanedInput = string.Join(" ", userInput.Split(' ')
                    .Where(w => !skipWords.Contains(w.ToLower()))).ToLower();

                string matchedTopic = topicResponses.Keys
                    .FirstOrDefault(topic => cleanedInput.Contains(topic));

                string response = matchedTopic != null
                    ? topicResponses[matchedTopic][rand.Next(topicResponses[matchedTopic].Length)]
                    : "Sorry, I didn't understand. Please ask about a cybersecurity topic like 'phishing' or 'ransomware'.";

                if (cleanedInput.Contains(favoriteTopic.ToLower()))
                {
                    response = $"Great choice! You're interested in {favoriteTopic}. Here's a tip: {response}";
                }

                RespondToUser(response);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Chatbot: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(followUps[rand.Next(followUps.Length)]);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(name + ": ");
                Console.ForegroundColor = ConsoleColor.White;
                string continueInput = Console.ReadLine();
                if (continueInput.ToLower() == "exit")
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Chatbot: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Thank you for using the Cybersecurity Awareness Chatbot. Stay safe!");
        }

        private void RespondToUser(string message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Chatbot: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }

        private string DetectSentiment(string input)
        {
            string lowerInput = input.ToLower();

            if (lowerInput.Contains("worried") || lowerInput.Contains("scared") || lowerInput.Contains("overwhelmed"))
            {
                return "It's totally okay to feel that way. Cybersecurity can seem overwhelming, but you're not alone—I'm here to help you feel confident and protected.";
            }

            if (lowerInput.Contains("curious") || lowerInput.Contains("interested") || lowerInput.Contains("keen"))
            {
                return "I love that you're curious! Learning about cybersecurity is a powerful step toward protecting yourself online.";
            }

            if (lowerInput.Contains("frustrated") || lowerInput.Contains("confused"))
            {
                return "It’s normal to feel confused sometimes. Cybersecurity has a lot of jargon, but I’ll guide you through it step by step!";
            }

            return string.Empty;
        }
    }
}
