namespace SpotifySongAvailabilityChecker
{
    public class SearchObject
    {
        public string SongLink 
        {
            get;
            set;
        }
        public string AlbumLink
        {
            get;
            set;
        }
        public string Title 
        {
            get;
            set;
        }

        public SearchObject(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return $"Title: {Title} - {(string.IsNullOrWhiteSpace(AlbumLink) ? $"Song: {SongLink}" : $"Album: {AlbumLink}")}";
        }
    }
}
