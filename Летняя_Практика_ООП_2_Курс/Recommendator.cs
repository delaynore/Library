using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Летняя_Практика_ООП_2_Курс
{
    public static class Recommendator
    {
        public static LibraryDB Database = new LibraryDB();
        public static double SimilarityCoef = 0.65;
        public static List<Book>? AlternateBook(int bookId)
        {
            var book = GetBookFromId(bookId);
            if (book == null) return null;
            if (book.KeyWords == null) return null;
            var books = GetBooksWithSameGenre(book, (w,z) => w.Author != z.Author);
            if (books == null) return null;
            var alternate = new List<Book>();
            foreach (var e in books)
            {
                if (IsSimilarBooks(book, e))
                    alternate.Add(e);
            }
            return alternate;
        }
        public static bool IsSimilarBooks(Book book1, Book book2)
        {
            double sumKeys = book1.KeyWords.Count + book2.KeyWords.Count;
            var sameKeys = 0;
            for (int i = 0; i < book1.KeyWords.Count; i++)
                for (int j = 0; j < book2.KeyWords.Count; j++)
                {
                    if (book1.KeyWords[i].Id == book2.KeyWords[j].Id)
                        sameKeys++;
                }
            return sameKeys * 2 / sumKeys >= SimilarityCoef;
        }

        public static List<Book>? AdditionalBooks(int bookId)
        {
            var book = GetBookFromId(bookId);
            if (book == null) return null;
            if (book.KeyWords == null) return null;
            var books = GetBooksWithSameGenre(book, (w,z) => true);
            if (books == null) return null;
            var alternate = new List<Book>();
            
            foreach (var e in books)
            {
                if (IsSimilarBooks(book, e) || HaveSameKeywords(book, e))
                    alternate.Add(e);
            }
            return alternate;
        }

        private static List<Book> GetBooksWithSameGenre(Book book, Func<Book, Book, bool> isSameAuthor)
        {
            return Database.Books.Include(x => x.KeyWords).Where(x => x.Genre == book.Genre && isSameAuthor(x,book) && !x.CurrentReaderId.HasValue).ToList();
        }
        private static Book? GetBookFromId(int id)
        {
            return Database.Books.Include(x => x.KeyWords).FirstOrDefault(x => x.BookID == id);
        }
        private static bool HaveSameKeywords(Book book1, Book book2)
        {
            if (book1.KeyWords.Count > book2.KeyWords.Count) return false;
            for (int i = 0; i < book1.KeyWords.Count; i++)
            {
                bool flag = false;
                for (int j = 0; j < book2.KeyWords.Count; j++)
                {
                    if (book1.KeyWords[i].Id == book2.KeyWords[j].Id)
                    {
                        flag = true;
                        break;
                    }   
                }
                if (!flag) return false;
            }
                
            return true;
        }
    }
}
