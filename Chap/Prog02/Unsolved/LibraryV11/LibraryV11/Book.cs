
/// <summary>
/// This class represent a book, with ISBN, title, author
/// and the number of pages in the book
/// </summary>
public class Book
{
    #region Properties
    public string ISBN { get; }
    public string Title { get; }
    public string Author { get; }
    public int NoOfPages { get; }
    #endregion

    #region Constructor
    public Book(string isbn, string title, string author, int noOfPages)
    {
        ISBN = isbn;
        Title = title;
        Author = author;
        NoOfPages = noOfPages;
    }
    #endregion
}
