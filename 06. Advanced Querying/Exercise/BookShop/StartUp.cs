namespace BookShop
{
    using Data;
    using System;
    using System.Text;
    using System.Linq;
    using System.Globalization;
    using BookShop.Models.Enums;
    using Z.EntityFramework.Plus;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BookShopContext();
            // DbInitializer.ResetDatabase(dbContext);



            // P02: 
            /*
            string ageRestriction = Console.ReadLine();
            Console.WriteLine(GetBooksByAgeRestriction(dbContext, ageRestriction));
            */

            // P03: Console.WriteLine(GetGoldenBooks(dbContext));
            // P04: Console.WriteLine(GetBooksByPrice(dbContext));

            // P05: 
            /*
            Console.WriteLine(GetBooksNotReleasedIn(dbContext, 2000));
            Console.WriteLine(GetBooksNotReleasedIn(dbContext, 1998));
            */

            // P06: Console.WriteLine(GetBooksByCategory(dbContext, "horror mystery drama"));
            // P07: Console.WriteLine(GetBooksReleasedBefore(dbContext, "12-04-1992"));
            // P08: Console.WriteLine(GetAuthorNamesEndingIn(dbContext, "e"));
            // P09: Console.WriteLine(GetBookTitlesContaining(dbContext,"sK"));
            // P10: Console.WriteLine(GetBooksByAuthor(dbContext, "R"));
            // P15: IncreasePrices(dbContext);
            // P16: Console.WriteLine(RemoveBooks(dbContext)); // 34


            dbContext.Dispose();
        }


        // Problem 2: Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder output = new StringBuilder();

            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            ICollection<string> targetBooksByGivenRestriction = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            foreach (var book in targetBooksByGivenRestriction)
            {
                output.AppendLine($"{book}");
            }

            return output.ToString().TrimEnd();
        }

        // Problem 3: Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            ICollection<string> goldenBooks = context.Books
                .Where(b => b.EditionType == Enum.Parse<EditionType>("Gold", true) && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            foreach (var book in goldenBooks)
            {
                output.AppendLine(book);
            }

            return output.ToString().TrimEnd();
        }

        // Problem 4: 
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var targetBooksByPrice = context.Books
                .Where(b => b.Price > 40m)
                .Select(b => new { b.Title, b.Price })
                .OrderByDescending(b => b.Price);

            foreach (var book in targetBooksByPrice)
            {
                output.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return output.ToString().TrimEnd();
        }

        // Problem 5: Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder output = new StringBuilder();

            var targetBooks = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title).ToList();

            targetBooks.ForEach(b => output.AppendLine(b));

            return output.ToString().TrimEnd();
        }

        // Problem 6: Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder output = new StringBuilder();

            string[] bookCategories = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var targetBooksByCategories = context.Books
                .Where(b => b.BookCategories.Any(c => bookCategories.Contains(c.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();
           
            targetBooksByCategories.ForEach(b => output.AppendLine(b));
    
            return output.ToString().TrimEnd();
        }

        // Problem 7: Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {

            DateTime dateInput = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var booksReleasedBefore = context
                .Books
                .Where(b => b.ReleaseDate < dateInput)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                .ToArray();

            return string.Join(Environment.NewLine, booksReleasedBefore);
        }

        // Problem 8: Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNamesEndingIn = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName).ThenBy(a => a.LastName)
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray();

            return string.Join(Environment.NewLine, authorNamesEndingIn);
        }

        // Problem 9: Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b);

            return String.Join(Environment.NewLine, books);
        }

        // Problem 10: Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder output = new StringBuilder();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new { b.Title, Author = $"{b.Author.FirstName} {b.Author.LastName}" })
                .ToList();

            books.ForEach(b => output.AppendLine($"{b.Title} ({b.Author})"));

            return output.ToString().TrimEnd();
        }

        // Problem 15: Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // Problem 16: Remove Books
        public static int RemoveBooks(BookShopContext context) // Install Z.EntityFramework.Plus.EFCore package
        {
            var removedBooks = context.Books
                .Where(b => b.Copies < 4200).Delete();

            return removedBooks;
        }
    }
}