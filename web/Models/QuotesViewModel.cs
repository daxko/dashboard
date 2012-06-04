using System.Collections.Generic;

namespace web.Models
{
    public class QuotesViewModel
    {
        public QuoteModel quote { get; set; }
        public long transition_time { get; set; }

        public QuotesViewModel()
        {
            transition_time = 60;
        }
    }

    public class QuoteModel
    {
        public string quote { get; set; }
        public string author { get; set; }
    }
}