using System;

namespace kea_part1
{
    public class Chatbot
    {
        // Constructor
        public Chatbot()
        {
            // Optional: Add constructor logic if needed
        }

        // Method to generate chatbot responses based on user input
        public string GenerateResponse(string userInput)
        {
            // Error handling: Check for empty or null input
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return "I didn't catch that. Could you please rephrase your question?";
            }

            try
            {
                // Sentiment detection first
                string sentimentResponse = DetectSentiment(userInput);
                if (!string.IsNullOrEmpty(sentimentResponse))
                {
                    return sentimentResponse;
                }

                //  Normalize input
                string loweredInput = userInput.ToLower();

                // Specific keyword checks
                if (loweredInput.Contains("password"))
                {
                    return "Make sure to use strong, unique passwords for each account. Avoid using personal details in your passwords.";
                }

                if (loweredInput.Contains("phishing"))
                {
                    return "Be cautious with emails asking for personal information. Always verify links before clicking.";
                }

                if (loweredInput.Contains("privacy"))
                {
                    return "Privacy is crucial! Adjust your settings and avoid oversharing online.";
                }

                // Default response for unknown topics
                return "I'm not sure how to help with that. Try asking about password safety, phishing, or privacy.";
            }
            catch (Exception ex)
            {
                //  Gracefully catch any unexpected errors
                return $"Oops! Something went wrong: {ex.Message}";
            }
        }

        internal string GenerateResponse(object userInput)
        {
            throw new NotImplementedException();
        }

        // Method to detect sentiment and return an empathetic response
        private string DetectSentiment(string userInput)
        {
            string lowered = userInput.ToLower();

            if (lowered.Contains("worried") || lowered.Contains("scared") || lowered.Contains("concerned"))
            {
                return "It's completely understandable to feel that way. Cyber threats can be scary, but I’m here to help you stay safe!";
            }

            if (lowered.Contains("curious") || lowered.Contains("interested"))
            {
                return "I’m glad you’re curious! Staying informed is key to protecting your data. What would you like to learn about?";
            }

            if (lowered.Contains("frustrated") || lowered.Contains("confused"))
            {
                return "I know cybersecurity can be confusing sometimes, but you're doing great! Let's take it one step at a time.";
            }

            return string.Empty; // No sentiment detected
        }
    }
}

