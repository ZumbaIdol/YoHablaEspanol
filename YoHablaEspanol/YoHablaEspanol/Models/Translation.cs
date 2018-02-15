namespace YoHablaEspanol.Models
{

    public class Rootobject
    {
        public Metadata metadata { get; set; }
        public Result[] results { get; set; }
    }

    public class Metadata
    {
        public string provider { get; set; }
    }

    public class Result
    {
        public string id { get; set; }
        public string language { get; set; }
        public Lexicalentry[] lexicalEntries { get; set; }
        public string type { get; set; }
        public string word { get; set; }
    }

    public class Lexicalentry
    {
        public Entry[] entries { get; set; }
        public string language { get; set; }
        public string lexicalCategory { get; set; }
        public string text { get; set; }
    }

    public class Entry
    {
        public Grammaticalfeature[] grammaticalFeatures { get; set; }
        public string homographNumber { get; set; }
        public Sens[] senses { get; set; }
    }

    public class Grammaticalfeature
    {
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Sens
    {
        public Example[] examples { get; set; }
        public string id { get; set; }
        public Translation1[] translations { get; set; }
    }

    public class Example
    {
        public Note[] notes { get; set; }
        public string text { get; set; }
        public Translation[] translations { get; set; }
    }

    public class Note
    {
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Translation
    {
        public string language { get; set; }
        public string text { get; set; }
        public string[] regions { get; set; }
        public Note1[] notes { get; set; }
    }

    public class Note1
    {
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Translation1
    {
        public string language { get; set; }
        public string text { get; set; }
    }

}
