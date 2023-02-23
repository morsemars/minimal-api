namespace Playlist;

public record Song{
    public string Title {get; set;}
    public string Artist {get; set;}
}

public class PlaylistDB{

    private static List<Song> _songs = new List<Song>(){
        new Song { Title = "Good Parts", Artist="Le Sserafim" },
        new Song { Title = "On My Way", Artist="Epik High" },
        new Song { Title = "Catch", Artist="Epik High" },
    };

    public static List<Song> GetSongs(){
        return _songs;
    }

    // Create, read, update, delete


    public static Song GetSong(int index){
        if(index < 0 || index >= _songs.Count) throw new Exception("Invalid song index.");

        return _songs[index];
    }

    public static Song AddSong(Song song){
        _songs.Add(song);

        return song;
    }

    public static Song UpdateSong(int index, Song song){
        if (index < 0 || index >= _songs.Count) throw new Exception("Invalid song index.");
        _songs[index] = song;

        return song;
    }

    public static void DeleteSong(int index){
        _songs.RemoveAt(index);
    }

}