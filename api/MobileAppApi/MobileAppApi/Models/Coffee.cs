namespace MobileAppApi.Models
{
    public class Coffee
    {
        public class Assets
        {
            public class Large
            {
                public string uri { get; set; }
            }

            public class Thumbnail
            {
                public Large large { get; set; }
            }
            public class FullSize
            {
                public string uri { get; set; }
            }
            public class MasterImage
            {
                public string uri { get; set; }
            }
            public Thumbnail thumbnail { get; set; }   
            public FullSize fullSize { get; set; }
            public MasterImage masterImage { get; set; }
        }
        public string name { get; set; }
        public string formCode { get; set; }
        public int displayOrder { get; set; }
        public string availability { get; set; }
        public Assets assets { get; set; }
        public List<string> sizes { get; set; }   
        public int id { get; set; }
        public string category { get; set; }
    }
}
