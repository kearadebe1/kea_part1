
Project name: kea_part1 – Part 2
Student Number: ST10439874
Template: Console App (.NET Framework, C#)

What I Added in Part 2
In Part 2 of my Cybersecurity Awareness Chatbot project, I focused on making the chatbot more intelligent, user-friendly, and realistic in how it responds to people. I used various C# features to expand on Part 1 and meet the following goals:

1. Keyword Recognition
I made the chatbot smarter by teaching it to recognise specific cybersecurity keywords such as "password", "scam", and "privacy".
Whenever the user types a sentence that includes one of these keywords, the chatbot understands the topic and gives a relevant cybersecurity tip.

Example:
User: Tell me about password safety
Chatbot: Make sure to use strong, unique passwords for each account. Avoid using personal details in your passwords.

2. Randomised Responses
To make the conversation less repetitive, I created multiple tips for each topic and stored them in arrays inside a dictionary.
The chatbot randomly picks one of those responses every time a topic is mentioned, so users don’t always get the same answer.

Example:
User: Give me a phishing tip
Chatbot: Avoid clicking on suspicious links.
(or another tip about phishing — it varies each time)

3. Conversation Flow
I designed the chatbot to hold a flowing conversation. It keeps asking follow-up questions and allows the user to continue chatting without restarting the whole process.
The user can exit by typing "exit" at any time, but otherwise, the chatbot continues to chat naturally and keeps the conversation going.

4. Memory and Recall
One of the biggest improvements is that the chatbot now remembers certain user details like their name and their favourite cybersecurity topic.
I use this information later in the conversation to personalise the chatbot's answers.

Example:
User: I'm interested in privacy.
Chatbot: Great! I'll remember that you're interested in privacy. It's a crucial part of staying safe online.
Later...
Chatbot: As someone interested in privacy, you might want to review the security settings on your accounts.

5. Sentiment Detection
I added basic sentiment analysis so the chatbot can understand how the user is feeling.
If someone says they’re worried, frustrated, or curious, the bot responds with supportive, encouraging messages. This makes the chatbot more human-like and empathetic.

Example:
User: I’m worried about online scams.
Chatbot: It’s completely understandable to feel that way. Scammers can be very convincing. Let me share some tips to help you stay safe.

6. Error Handling and Edge Cases
I made sure that the chatbot doesn’t break or behave strangely when given unexpected input.
If a user types something unrelated or confusing, the chatbot simply replies with a message like:

I’m not sure I understand. Can you try rephrasing?

This ensures the program keeps running and gives a better experience, even if the input is unclear.

7. Code Optimisation
I organised all the topic responses into a dictionary of string arrays, and used LINQ to filter and match keywords dynamically.
This helped reduce the number of if statements and made the code cleaner, easier to maintain, and ready to expand later in Part 3 or the final POE.
I also used modular methods for sentiment detection and user responses, which keeps the logic reusable and tidy.
