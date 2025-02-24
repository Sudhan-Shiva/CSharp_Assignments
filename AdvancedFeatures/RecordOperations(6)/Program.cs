using ConsoleTables;

public class Program
{
    public record Book(string Title, string Author, int ISBN);
    static void Main()
    {
        Console.WriteLine("---- SubTask : Defining Records and Printing to Console ----\n");
        var harryPotterBook = new Book("Harry Potter", "J.K.Rowling", 123);
        var originBook = new Book("Origin", "Dan Brown", 12345);
        var programmingBook = new Book("Let Us C", "Yashwant Kanetkar", 1234567);

        ConsoleTable consoleTable = new ConsoleTable("Title", "Author", "ISBN");
        consoleTable.AddRow(harryPotterBook.Title, harryPotterBook.Author, harryPotterBook.ISBN);
        consoleTable.AddRow(originBook.Title, originBook.Author, originBook.ISBN);
        consoleTable.AddRow(programmingBook.Title, programmingBook.Author, programmingBook.ISBN);
        consoleTable.Write();

        Console.WriteLine("\n---- SubTask : Defining new same valued record and applying equality operator ----\n");
        var duplicateHarryPotterBook = new Book("Harry Potter", "J.K.Rowling", 123);
        Console.WriteLine($"Equality operation result : {harryPotterBook == duplicateHarryPotterBook}");

        Console.WriteLine("\n---- SubTask : Check Immutability of record ----\n");
        //harryPotterBook.Author = "Dan Brown";
        Console.WriteLine("The record cannot be modified !!!");

        Console.WriteLine("\n---- SubTask : using with keyword ----\n");
        var daVinciCodeBook = originBook with
        {
            Title = "The Da Vinci Code"
        };

        ConsoleTable newConsoleTable = new ConsoleTable("Title", "Author", "ISBN");
        newConsoleTable.AddRow(originBook.Title, originBook.Author, originBook.ISBN);
        newConsoleTable.AddRow(daVinciCodeBook.Title, daVinciCodeBook.Author, daVinciCodeBook.ISBN);
        newConsoleTable.Write();

        Console.WriteLine("\n---- SubTask : DeConstructing the record ----\n");
        DisplayBook(harryPotterBook);
        DisplayBook(originBook);
        Console.WriteLine(harryPotterBook.Author); 
        Console.ReadKey();
    }

    static void DisplayBook(Book book)
    {
        book.Deconstruct(out string Title,out string Author,out int ISBN);
        Console.WriteLine($"Title : {Title}, Author : {Author}, ISBN : {ISBN}");
    }
}
