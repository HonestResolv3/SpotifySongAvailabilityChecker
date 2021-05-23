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
        public string Author
        {
            get;
            set;
        }

        public Enums.ObjectType Type
        {
            get;
            set;
        }

        public SearchObject(string title)
        {
            Title = title;
        }

        public string GetCorrectLink()
        {
            return string.IsNullOrWhiteSpace(AlbumLink) ? SongLink : AlbumLink;
        }
    }
}
