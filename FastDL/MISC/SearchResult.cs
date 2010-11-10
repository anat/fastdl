using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastDL.MISC
{
    public class SearchResult
    {
        public SearchResult(string paramURL)
        {
            url = paramURL;
        }

        public string url;
        public string desc;
        public string name;
    }
}
