using System;
using System.Collections.Generic;
using System.Linq;

namespace domain.Quotes
{
    public class QuoteRepository : IQuoteRepository
    {
        public List<Quote> quotes { get; protected set; }

        public QuoteRepository()
        {
            quotes = new List<Quote>()
                         {
                             new Quote("Seth Godin","If you can't fail it doesn't count."),
                             new DaxkoSoftwareCraftsmanPrincipalQuote("Do the minimum amount of work to get the job done while creating reuse."),
                             new DaxkoSoftwareCraftsmanPrincipalQuote("Try to suck less each day."),
                             new DaxkoSoftwareCraftsmanPrincipalQuote("Follow the Boy scout rule, Leave the code better than you found it."),
                             new Quote("Jean Paul Boodhoo","Take yourself out of your comfort zone."),
                             new DaxkoSoftwareCraftsmanPrincipalQuote("If the code feels like crap it probably is...so stop, rethink and find a better way."),
                             new DaxkoSoftwareCraftsmanPrincipalQuote("Don't be a Diva."),
                             new DaxkoSoftwareCraftsmanPrincipalQuote("Use the best tool for the job. Be practical and open minded."),
                             new DaxkoSoftwareCraftsmanPrincipalQuote("Use good principles over tooling."),
                             new DaxkoSoftwareCraftsmanPrincipalQuote("Take ownership but take suggestions from other developers."),
                             new DaxkoSoftwareCraftsmanPrincipalQuote("Is what I'm doing adding value for the customer."),
                             new DaxkoSoftwareCraftsmanPrincipalQuote("Before you can solve the problem you must understand it."),
                             new DaxkoSoftwareCraftsmanPrincipalQuote("Just becuse you have always done something that way doesn't mean it isn't incredibly stupid."),
                             new Quote("Steve Jobs","It's not the customers job to know what they want."),
                             new Quote("Steve Blank","On understanding your customers. 'Get out of the building.'"),
                             new UnknownQuote("Life it to short to build something nobody wants."),
                             new Quote("Dave McClure","Customers don't care about your solution. They care about their problems."),
                         };
        }


        public Quote get_random_quote()
        {
            if (quotes.Count == 0)
                return new UnknownQuote("No quotes exist in the repository");

            var random = new Random();
            var number = random.Next(0,quotes.Count-1);

            return quotes.ElementAt(number);
        }
    }
}