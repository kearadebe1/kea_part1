using System.Collections;
using System.IO;
using System.Media;
using System;
using System.Drawing;
using System.Diagnostics.Eventing.Reader;

namespace kea_part1
{
    public class security_awe
    {
        //Adding the global variable
        private string name = string.Empty;
        private string description = string.Empty;
        //constructer
        public security_awe()
        {
            // 1.Firstly we will add the voice over to welcome the user to our cyber space.

            // get the location of the project
            string right_location = AppDomain.CurrentDomain.BaseDirectory;

            //replacing the bin and the debug
            string new_path = right_location.Replace("bin\\Debug\\", "");

            //try and catch
            try
            {
                //combine the paths
                string right_path = Path.Combine(new_path, "voice_over.wav");

                // creating instance for SoundPlay class
                using (SoundPlayer play = new SoundPlayer(right_path))
                {

                    //play the file
                    play.PlaySync();
                }


            }//end of try
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }//end of catch

            //2. We select the Image

            //get full location of the project

            string full_location = AppDomain.CurrentDomain.BaseDirectory;

            //replace the bin and debug
            string new_location = full_location.Replace("bin\\Debug\\", "");

            //combining the path
            string full_path = Path.Combine(new_location, "pic.png");

            //then time to use ascii

            //creating the BitMap class
            Bitmap image = new Bitmap(full_path);

            //then set the size
            image = new Bitmap(image, new Size(150, 100));

            //enter the inner loop
            for (int height = 0; height < image.Height; height++)
            {
                for (int width = 0; width < image.Width; width++)
                {
                    Color pixelColor = image.GetPixel(width, height);
                    int grey = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    char asciiChar = grey > 200 ? '.' : grey > 150 ? '*' : grey > 100 ? '0' : grey > 150 ? '#' : '@';
                    Console.Write(asciiChar);


                }

                // end of inner for loop
                Console.WriteLine();
            }



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
                name = Console.ReadLine();
            }
          




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
                description = Console.ReadLine();

                if (description != "exit")
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
                respond.Add("password safety: \n create a password atleast 12 characters long. \n Use a combination of lower and upper case and special characters. \n Use auto generated password. ");
                respond.Add("phishing: \n Avoid sharing personal information. \n Use a two-facter authentification \n keep your and security tools up to date.");
                respond.Add("safe browsing: \n use a secure internet connection \n close unused accounts \n keep software and browsing udated");

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
                            design_ui(description);




                        }//end of for loop nested
                    }



                }
                else
                {
                    //then display the answer
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Chatbot: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Sorry, I don't understand your question. Please try again.");
                }


            } while (description != "exit");




        }//end of class

        private void design_ui(string asked) {
          if(asked != "exit")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Chatbot: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("I hope this response was helpful.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Chatbot: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Thank you for using our chatbot, Bye");
                System.Environment.Exit(0);
            }

        }//end of namespace
    } }