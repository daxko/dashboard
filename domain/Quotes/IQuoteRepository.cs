namespace domain.Quotes
{
    public interface IQuoteRepository
    {
        Quote get_random_quote();
    }
}