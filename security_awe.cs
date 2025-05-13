using System;
using System.Collections;
using System.IO;


namespace kea_part1
{
    public class security_awe

    {

        private MemoryRecall_generics memory;
        private Chatbot chatbot; //Instance of the Chatbot class
        // rest of your constructor and code

        //Adding the global variable
        private string name = string.Empty;
        private string userInput = string.Empty;
        //constructer
        public security_awe()
        {
            //Creating the memory instance
            memory = new MemoryRecall_generics();



            //Welcome display
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*--------------------------------------------------------------------*");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("|                    CYBERSECURITY AWARENESS CHATBOT:)               |");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*--------------------------------------------------------------------*");



            //AI asking for the username
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Chatbot: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please enter your name:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("User: ");
            Console.ForegroundColor = ConsoleColor.White;
            name = Console.ReadLine();

            //then check if the name is empty
            if (string.IsNullOrEmpty(name))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Chatbot: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid name.");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("User: ");
                Console.ForegroundColor = ConsoleColor.White;
                name = Console.ReadLine(); //Re-ask for the name
            }
            else
            {
                //Name is valid, you can proceed with the rest of the code
                //Create the memory instance and store the name

            }

            // Create the memory instance and store the name
            memory = new MemoryRecall_generics();
            memory.StoreUserData("name", name);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Hello " + name + ", nice to meet you!");


            //Start conversation flow
            StartConversation();


            do
            {
                //prompting the user to ask a question
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Chatbot: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Welcome to the Cyber Space " + name + "How can i assist you today :");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(name + ": ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();

                //recreating the interface
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Chatbot: ");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("I'm here to to keep you safe from Cyber threats. \n providing the following information \n password safety \n Phishing \n safe browsing \n type 'exit' to leave the aplication."
                );

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(name + ": ");
                Console.ForegroundColor = ConsoleColor.White;
                this.userInput = Console.ReadLine();

                if (this.userInput != "exit")
                {
                    // display the answer
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Chatbot: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Here is the responce i have for you....");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Chatbot: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Thank you for using the Cybersecurity Awareness Chatbot. Goodbye!");
                    System.Environment.Exit(0);
                }

                //Genrate a response using the chatbot instance
                string response = chatbot.GenerateResponse(this.userInput);


                //prompting the user to enter question
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("ChatBot: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("How can I assist you:");


                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(name + ": ");
                Console.ForegroundColor = ConsoleColor.White;
                string ask = Console.ReadLine();





                //declare variable and array
                ArrayList respond = new ArrayList();
                ArrayList hidden = new ArrayList();

                //then store
                respond.Add("password safety: create a password atleast 12 characters long. ");
                respond.Add("password safety: Use a combination of lower and upper case and special characters.");
                respond.Add(" password safety: Use auto generated password. ");

                respond.Add("phishing:  Avoid sharing personal information.");
                respond.Add("phishing:  Use a two-facter ");
                respond.Add("phishing:  Use a secure internet connection ");
                respond.Add("phishing:  close unused accounts.");
                respond.Add("phishing:  Keep your and security tools up to date.");

                respond.Add("safe browsing:  use a secure internet connection ");
                respond.Add("safe browsing:  close unused accounts ");
                respond.Add("safe browsing:  keep software and browsing udated");

                hidden.Add("tell");
                hidden.Add("me");
                hidden.Add("about");

                // split the question and store in the 1D array
                string[] filtered_responce = ask.Split(' ');
                ArrayList correct_responce = new ArrayList();


                // then display the answer using the for loop
                //as it search it should filter more

                Boolean found = false;

                for (int count = 0; count < filtered_responce.Length; count++)
                {
                    //then final filter
                    if (!hidden.Contains(filtered_responce[count]))
                    {
                        //then assign to true
                        found = true;
                        //then add the value to the correct filtered
                        correct_responce.Add(filtered_responce[count]);




                    }



                }
                //then check if found
                if (found)
                {
                    for (int counting = 0; counting < correct_responce.Count; counting++)
                    {
                        //then display the answer
                        for (int count = 0; count < respond.Count; count++)

                        {
                            // then final display the found one
                            if (respond[count].ToString().Contains(correct_responce[counting].ToString()))
                            {
                                //output
                                Console.WriteLine(respond[count].ToString());

                            }//end of if statement.
                            //Call design_ui inside this IF so it's not called for every loop iteration unnecessarily
                            design_ui(this.userInput);


                        }//end of inner for loop
                    }//end of outer for loop
                }//end of if (found)




                
                else
                {
                    //then display the answer
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Chatbot: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Sorry, I don't understand your question. Please try again.");
                }


            } while (this.userInput != "exit");




        }//end of class

        private void design_ui(string userInput)
        {
            throw new NotImplementedException();
        }

        private void StartConversation()
        {
           do
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Chatbot: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("How can I assist you today?");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(name + ": ");
                Console.ForegroundColor = ConsoleColor.White;
                userInput = Console.ReadLine();

                if (userInput.ToLower() != "exit")
                {
                    string response = chatbot.GenerateResponse(userInput);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Chatbot: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(response);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Chatbot: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Thank you for chatting. Stay safe online!");
                    break;
                }

            } while (true);
        }
    }
        }

      

        //end of namespace
    

    // End of class security_awe

// End of namespace kea_part1



