using System.Collections.Generic;
internal class Task4
{

    class Song
    {
        private string artistname;
        private string songname;
        private int minutes;
        private int seconds;
        
        public Song (string artistname, string songname, int minutes, int seconds)
        {
            this.Artistname = artistname;
            this.Songname = songname;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public string Artistname
        {
            get { return artistname; }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
                }
                artistname = value;
            }

        }
        public string Songname
        {
            get { return songname; }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentException("Song name should be between 3 and 30 symbols.");
                }
                songname = value;
            }
        }
        public int Minutes 
        {
            get { return minutes; }
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new ArgumentException("Song minutes should be between 0 and 14.");
                }
                minutes = value;
            }
        }
        public int Seconds
        {
            get
            {
                return seconds;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("\"Song seconds should be between 0 and 59.");
                }
                seconds = value;
            }
        }
    }


    static void Main()
    {
        
        Console.WriteLine("Enter a count of song: ");
        int k = int.Parse(Console.ReadLine());

        List<Song> songs = new List<Song>();

        for (int i = 0; i < k; i++)
        {
            Console.WriteLine("Enter an artist name: ");
            string artistname = Console.ReadLine();
            Console.WriteLine("Enter a song name: ");
            string songname = Console.ReadLine();
            Console.WriteLine("Enter a minutes");
            int minutes = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a second: ");
            int seconds = int.Parse(Console.ReadLine());
            
            try
            {
                Song song = new Song(artistname, songname, minutes, seconds);
                songs.Add(song);
                Console.WriteLine("\nSong added\n");
                
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
        int hours = 0;
        int min = 0;
        int sec = 0;
        foreach (Song s in songs)
        {
            min += s.Minutes;
            sec += s.Seconds;
        }
        while (min >= 60 || sec >= 60)
        {
            if (sec >= 60)
            {
                sec -= 60;
                min += 1;
            }
            if (min >= 60)
            {
                min -= 60;
                hours++;
            }
        }
        Console.WriteLine("\nPlaylist lenght: " + hours + "h " + min + "m " + sec + "s");
    }
}