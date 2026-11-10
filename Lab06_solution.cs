// Lab: Playlist Manager (Lists) - SOLUTION (instructor copy)
// Name: ____________________

class Program
{
    static void Main(string[] args)
    {
        List<string> playlist = new List<string>();
        playlist.Add("Yellow");
        playlist.Add("Halo");
        playlist.Add("Believer");

        // Songs that were removed, so they can be brought back (bonus).
        List<string> removedSongs = new List<string>();

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("=== Playlist Manager ===");
            Console.WriteLine("1. Show playlist");
            Console.WriteLine("2. Add a song to the end");
            Console.WriteLine("3. Insert a song at a position");
            Console.WriteLine("4. Remove a song");
            Console.WriteLine("5. Move a song to a new position");
            Console.WriteLine("6. Search for a song");
            Console.WriteLine("7. Sort A to Z");
            Console.WriteLine("8. Reverse the order");
            Console.WriteLine("9. Undo last remove (bonus)");
            Console.WriteLine("0. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                PrintPlaylist(playlist);
            }
            else if (choice == "2")
            {
                Console.Write("Song name: ");
                string song = Console.ReadLine();
                AddSong(playlist, song);
            }
            else if (choice == "3")
            {
                Console.Write("Song name: ");
                string song = Console.ReadLine();
                Console.Write("Position (1 to " + (playlist.Count + 1) + "): ");
                int position = int.Parse(Console.ReadLine());
                InsertSong(playlist, song, position);
            }
            else if (choice == "4")
            {
                Console.Write("Song to remove: ");
                string song = Console.ReadLine();
                RemoveSong(playlist, removedSongs, song);
            }
            else if (choice == "5")
            {
                Console.Write("Song to move: ");
                string song = Console.ReadLine();
                Console.Write("New position (1 to " + playlist.Count + "): ");
                int position = int.Parse(Console.ReadLine());
                MoveSong(playlist, song, position);
            }
            else if (choice == "6")
            {
                Console.Write("Search word: ");
                string word = Console.ReadLine();
                SearchSongs(playlist, word);
            }
            else if (choice == "7")
            {
                playlist.Sort();
                Console.WriteLine("Playlist sorted A to Z.");
            }
            else if (choice == "8")
            {
                playlist.Reverse();
                Console.WriteLine("Playlist reversed.");
            }
            else if (choice == "9")
            {
                UndoRemove(playlist, removedSongs);
            }
            else if (choice == "0")
            {
                running = false;
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Please choose 0 to 9.");
            }
        }
    }

    static void PrintPlaylist(List<string> songs)
    {
        if (songs.Count == 0)
        {
            Console.WriteLine("The playlist is empty.");
        }

        for (int i = 0; i < songs.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + songs[i]);
        }

        Console.WriteLine("Total songs: " + songs.Count);
    }

    static void AddSong(List<string> songs, string song)
    {
        if (songs.Contains(song))
        {
            Console.WriteLine(song + " is already in the playlist.");
        }
        else
        {
            songs.Add(song);
            Console.WriteLine(song + " was added.");
        }
    }

    static void InsertSong(List<string> songs, string song, int position)
    {
        if (songs.Contains(song))
        {
            Console.WriteLine(song + " is already in the playlist.");
        }
        else if (position < 1 || position > songs.Count + 1)
        {
            Console.WriteLine("Position must be from 1 to " + (songs.Count + 1) + ".");
        }
        else
        {
            songs.Insert(position - 1, song);
            Console.WriteLine(song + " was added at position " + position + ".");
        }
    }

    static void RemoveSong(List<string> songs, List<string> removedSongs, string song)
    {
        bool removed = songs.Remove(song);

        if (removed)
        {
            removedSongs.Add(song);
            Console.WriteLine(song + " was removed.");
        }
        else
        {
            Console.WriteLine(song + " is not in the playlist.");
        }
    }

    static void MoveSong(List<string> songs, string song, int newPosition)
    {
        int index = songs.IndexOf(song);

        if (index == -1)
        {
            Console.WriteLine(song + " is not in the playlist.");
        }
        else if (newPosition < 1 || newPosition > songs.Count)
        {
            Console.WriteLine("Position must be from 1 to " + songs.Count + ".");
        }
        else
        {
            songs.RemoveAt(index);
            songs.Insert(newPosition - 1, song);
            Console.WriteLine(song + " moved to position " + newPosition + ".");
        }
    }

    static void SearchSongs(List<string> songs, string word)
    {
        int found = 0;

        for (int i = 0; i < songs.Count; i++)
        {
            if (songs[i].ToLower().Contains(word.ToLower()))
            {
                Console.WriteLine((i + 1) + ". " + songs[i]);
                found++;
            }
        }

        if (found == 0)
        {
            Console.WriteLine("No songs found.");
        }
        else
        {
            Console.WriteLine(found + " song(s) found.");
        }
    }

    // Bonus
    static void UndoRemove(List<string> songs, List<string> removedSongs)
    {
        if (removedSongs.Count == 0)
        {
            Console.WriteLine("Nothing to undo.");
        }
        else
        {
            string last = removedSongs[removedSongs.Count - 1];
            removedSongs.RemoveAt(removedSongs.Count - 1);
            songs.Add(last);
            Console.WriteLine(last + " is back in the playlist.");
        }
    }
}
