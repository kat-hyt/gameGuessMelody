using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_Melody_Framework
{
    static class Victorina
    {
        static public List<string> list = new List<string>();
        static public int gameDuration; //game duration
        static public int musicDuration = 10; //music duration
        static public bool randomStart = false; //the composition will start from a random place
        static public string lastFolder = ""; //folder for saving music
        static public bool allDirectories = false;
        static public int again = list.Count;
        static public string answer = "";

        //songs to file
        static public void ReadMusic()
        {
            try
            {
                string[] music_files = Directory.GetFiles(lastFolder, "*.mp3", allDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                list.Clear();
                list.AddRange(music_files);
            }
            catch
            { 
                
            
            }
        }
        //запишем в реестр Редактор реестра.exe
        static string regKeyName = "SOFTWARE\\MyCompanyName\\GuessMelody";
        //internal static int cbGameDuration;

        public static void WriteParam()
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.CurrentUser.CreateSubKey(regKeyName);
                if (rk == null) return;
                rk.SetValue("LastFolder", lastFolder); //"название", значение
                rk.SetValue("RandomStart", randomStart);
                rk.SetValue("GameDuration", gameDuration);
                rk.SetValue("MusicDuration", musicDuration);
                rk.SetValue("AllDirectories", allDirectories);

            }
            finally 
            {
                if (rk != null) rk.Close();
            };
        
        }
        public static void ReadParam() //читаем из реестра
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.CurrentUser.OpenSubKey(regKeyName);
                if (rk != null)

                {
                    lastFolder = (string)rk.GetValue("LastFolder"); 
                    gameDuration = (int)rk.GetValue("GameDuration");
                    randomStart = Convert.ToBoolean(rk.GetValue("RandomStart", false));
                    musicDuration = (int)rk.GetValue("MusicDuration");
                    allDirectories = Convert.ToBoolean(rk.GetValue("AllDirectories"));
                }
            }
            finally
            {
                if (rk != null) rk.Close();
            };

        }

    }
}
