using System;
using System.Diagnostics;

namespace CHADOWN
{
    public class YTDLMethodClass //Module for Youtube-DL support
    {
        string YTDLtype;

        public void YTDL_proper() //Main part of the YTDL module.
        {
            string[] YTDLarr = new string[5];
            YTDLarr[4] = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            Console.Clear();
            Console.WriteLine("Would you like the file to be Audio/Video or just audio?");
            Console.WriteLine("");
            Console.WriteLine("(a) Audio/Video");
            Console.WriteLine("(b) Just Audio");
            YTDLtype = Console.ReadLine();
            Console.Clear();
            if (YTDLtype == "b")
            {
                YTDLarr[0] = "--extract-audio --audio-format mp3 --audio-quality 0";
                YTDLarr[1] = ".mp3";
            }
            else if (YTDLtype == "a")
            {
                YTDLarr[0] = "--format mp4";
                YTDLarr[1] = ".mp4";

            }
            Console.Clear();
            Console.WriteLine("What would you like to name the video (Without file extension)?");
            YTDLarr[2] = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Paste the URL of the Youtube video.");
            YTDLarr[3] = Console.ReadLine();
            Console.Clear();
            string strCmdText;
            strCmdText = "/C youtube-dl "+YTDLarr[0]+" --output "+YTDLarr[4]+@"\"+YTDLarr[2]+YTDLarr[1]+" "+YTDLarr[3];
            Process p = Process.Start("CMD.exe", strCmdText);
            p.WaitForExit();
        }
    }
    public class FMPGMethodClass //Module for ffmpeg (BLOB) support
    {
        string FMPGlink;
        string FMPGvideoname;
        public string FMPGLinkGet() //Asks the user for the link to the playlist and returns it.
        {
            Console.WriteLine("Please paste the link for the playlist (usually a .m3u8) file");
            FMPGlink = Console.ReadLine();
            Console.Clear();
            return FMPGlink;
        }
        public string FMPGNameGet() //Asks the user for what they want the video name to be and returns it.
        {
            Console.WriteLine("What would you like to name the video (Don't include the filetype in the name)?");
            FMPGvideoname = Console.ReadLine();
            Console.Clear();
            return FMPGvideoname;
        }
        public void FMPGmethod() //Main part of the ffmpeg module
        {
            string strCmdText;
            strCmdText = "/C ffmpeg -protocol_whitelist file,http,https,tcp,tls,crypto -i "+FMPGlink+" "+Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)+@"\"+FMPGvideoname+".mp4";
            Process p = Process.Start("CMD.exe", strCmdText);
            p.WaitForExit();
        }
    }
    class CHADOWN
    {
        static bool Continue = true;
        static void TCol(string RText, string WText)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(RText);
            Console.ResetColor();
            Console.Write(WText);
        }
        static void Main(string[] args)
        {
            while (Continue)
            {
                Console.Write("Welcome to Jabs' ");
                TCol("C", "heap ");
                TCol("A", "ss ");
                TCol("Down", "loader!\n");
                Console.WriteLine("Now with 100% less shell scripting!");
                Console.WriteLine("");
                Console.WriteLine("Please select which type of video you wish to *procure*");
                Console.WriteLine("New types will be added as new technologies are discovered.");
                Console.WriteLine("---------------");
                Console.WriteLine("A. Youtube Videos");
                Console.WriteLine("B. BLOB/M3U8 Streams");
                string ConInputType = Console.ReadLine(); //User selects which one they want.
                Console.Clear();
                if (ConInputType == "A") //Method calls for YTDL
                {
                    YTDLMethodClass YTDLObj = new YTDLMethodClass();
                    YTDLObj.YTDL_proper();
                }
                else if (ConInputType == "B") //Method calls for ffmpeg
                {
                    FMPGMethodClass FMPGObj = new FMPGMethodClass();
                    FMPGObj.FMPGLinkGet();
                    FMPGObj.FMPGNameGet();
                    FMPGObj.FMPGmethod();
                }
                else
                {
                    continue;
                }
                Console.WriteLine("Continue? (y/n)");
                string WeGoingAgain = Console.ReadLine(); //The user chooses if they need to do another video
                if (WeGoingAgain == "n")
                {
                    Continue = false; //Once set to false script will kill. Defaults to true.
                }
                Console.Clear();
            }
        }
    }
}
