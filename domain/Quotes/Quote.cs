namespace domain.Quotes
{
    public class Quote
    {
        public string message { get; protected set; }
        public string author { get; protected set; }

        public Quote(string author, string message)
        {
            this.author = author;
            this.message = message;
        }
    }
}