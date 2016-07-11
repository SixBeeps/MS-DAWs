using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MSDaws
{
    class Program
    {
        static List<Note> noteData = new List<Note>();
        static string actn;
        static int editID;
        static string ans;
        static int duration;
        static void Main(string[] args)
        {
            Console.WriteLine("MS-DAWs v1.0.1 created by Brandon Lee.");
            Console.WriteLine("PLEASE NOTE: The pitch of a note CANNOT contain a decimal!");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Action: (note, repl, play, new)");
                actn = Console.ReadLine();
                switch (actn)
                {
                    case "note":
                        noteData.Add(new MSDaws.Note());
                        Console.WriteLine("Pitch:");
                        ans = Console.ReadLine();
                        noteData[noteData.ToArray().Length-1].Pitch = (StringToInt(ans));
                        Console.WriteLine("Length:");
                        ans = Console.ReadLine();
                        noteData[noteData.ToArray().Length-1].Length = (StringToInt(ans));
                        Console.WriteLine("Starts At:");
                        ans = Console.ReadLine();
                        noteData[noteData.ToArray().Length-1].StartsAt = (StringToInt(ans));
                        Console.WriteLine("Note Created with value " + noteData.ToArray().Length.ToString());
                        Thread.Sleep(3000);
                        break;
                    case "repl":
                        Console.WriteLine("Note ID to replace");
                        ans = Console.ReadLine();
                        editID = StringToInt(ans)-1;
                        Console.WriteLine("Pitch:");
                        ans = Console.ReadLine();
                        noteData[editID].Pitch = (StringToInt(ans));
                        Console.WriteLine("Length:");
                        ans = Console.ReadLine();
                        noteData[editID].Length = (StringToInt(ans));
                        Console.WriteLine("Starts At:");
                        ans = Console.ReadLine();
                        noteData[editID].StartsAt = (StringToInt(ans));
                        Console.WriteLine("Note Replaced with value " + noteData.ToArray().Length.ToString());
                        Thread.Sleep(3000);
                        break;
                    case "play":
                        foreach (Note note in noteData)
                        {
                            if (note.StartsAt > duration)
                            {
                                duration = note.StartsAt;
                            }
                        }
                        Console.WriteLine("Duration: " + duration.ToString());
                        Console.WriteLine("Song Playing");
                        for (int time = 0; time <= duration; time++)
                        {
                            foreach (Note note in noteData)
                            {
                                if (note.StartsAt == time)
                                {
                                    Console.Beep(note.Pitch, note.Length);
                                }
                                Thread.Sleep(1);
                            }
                        }
                        Console.WriteLine("Song Stopped");
                        break;
                    case "new":
                        Console.WriteLine("Are you sure you want to start over? (Y/N)");
                        ans = Console.ReadLine();
                        ans = ans.ToUpper();
                        if (ans == "Y")
                        {
                            noteData.Clear();
                        }
                        break;
                    default:
                        Console.WriteLine(actn + " isn't an action.");
                        break;
                }
            }
        }
        static int StringToInt(string s)
        {
            int i;
            if (int.TryParse(s, out i) == true)
            {
                return i;
            } else
            {
                return 0;
            }
        }
    }
    class Note
    {
        int pitch;
        public int Pitch
        {
            get
            {
                return pitch;
            } set
            {
                pitch = value;
            }
        }
        int length;
        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }
        int startsAt;
        public int StartsAt
        {
            get
            {
                return startsAt;
            }
            set
            {
                startsAt = value;
            }
        }
    }
}