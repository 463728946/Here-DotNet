using System.Collections.Generic;

namespace HereDotNet.Core.Response
{
    public class AutoSuggestRequestResponse
    {
    }

    public class AutoSuggestResponseItem
    {
        public string Title { get; set; }
        public string Id { get; set; }
        public ResultType? ResultType { get; set; }
        public string Href { get; set; }
        public Highlight Highlights { get; set; }

    }
    public class QueryTerm : Codepoint
    {
        public string Term { get; set; }
        public string Replaces { get; set; }

    }
    public class Highlight
    {
        public IList<Codepoint> Title { get; set; }
    }

    public class Codepoint
    {
        public IList<int> Start { get; set; }
        public IList<int> End { get; set; }
    }

}
