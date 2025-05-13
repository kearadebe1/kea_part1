using System;
using System.IO;
using System.Media;

namespace kea_part1
{
    internal class voice_over
    {
        public voice_over()
        {
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

        }
    }
}