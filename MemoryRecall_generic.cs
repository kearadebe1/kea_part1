using System;
using System.Collections.Generic;
using System.Linq;

namespace kea_part1
{
    public class MemoryRecall_generics
    {
        private Dictionary<string, string> memoryStore;
        private Dictionary<string, List<string>> responses;
        private string lastTopic = string.Empty;
        private Random rand = new Random();

        // Constructor
        public MemoryRecall_generics()
        {
            memoryStore = new Dictionary<string, string>();
            responses = new Dictionary<string, List<string>>();

            // Initialize the responses dictionary
            responses.Add("password", new List<string>
            {
                "Use strong and unique passwords.",
                "Don't include personal info in your password.",
                "Use a password manager to keep track securely."
            });

            responses.Add("phishing", new List<string>
            {
                "Be cautious with emails asking for info.",
                "Verify links before clicking.",
                "Check sender emails for fraud."
            });

            responses.Add("privacy", new List<string>
            {
                "Limit what you post on social media.",
                "Review app permissions regularly.",
                "Use secure browsers and VPNs."
            });
        }

        // Store user data
        public void StoreUserData(string key, string value)
        {
            if (memoryStore.ContainsKey(key))
                memoryStore[key] = value;
            else
                memoryStore.Add(key, value);
        }

        // Retrieve user data
        public string RetrieveUserData(string key)
        {
            return memoryStore.ContainsKey(key) ? memoryStore[key] : "Unknown";
        }

        // Store user name specifically
        public void StoreUserName(string userName)
        {
            StoreUserData("userName", userName);
        }

        // Generate a chatbot response
        public string GenerateResponse(string userInput)
        {
            string loweredInput = userInput.ToLower();

            if (loweredInput.Contains("privacy"))
            {
                if (memoryStore.ContainsKey("userName"))
                {
                    return $"As someone interested in privacy, {memoryStore["userName"]}, you might want to review the security settings on your accounts.";
                }
                return "Privacy is a crucial part of staying safe online.";
            }

            if (loweredInput.Contains("password"))
            {
                return "Make sure to use strong, unique passwords for each account.";
            }

            if (loweredInput.Contains("phishing"))
            {
                return "Watch out for suspicious emails and links. Verify sources before clicking.";
            }

            if (lastTopic != string.Empty && (loweredInput.Contains("more") || loweredInput.Contains("details")))
            {
                return ProvideMoreDetails(lastTopic);
            }

            var match = responses.FirstOrDefault(kvp => loweredInput.Contains(kvp.Key));
            if (match.Key != null)
            {
                lastTopic = match.Key;
                return match.Value[rand.Next(match.Value.Count)];
            }

            return "I'm not sure how to help with that. Try asking about password, phishing, or privacy.";
        }

        // Provide more details based on last topic
        private string ProvideMoreDetails(string topic)
        {
            switch (topic)
            {
                case "password":
                    return "Try using a password manager and avoid reusing passwords.";
                case "phishing":
                    return "Always double-check email senders and URLs to avoid scams.";
                case "privacy":
                    return "Use encrypted apps and secure your social media settings.";
                default:
                    return "I can only give more info about password safety, phishing, or privacy.";
            }
        }
    }
}



