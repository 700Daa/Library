using System;
using System.Collections.Generic; // to uses Lists<> 
using System.IO; // to use File, StreamWriter, StreamReader
using System.Linq; // to use LINQ methods like Where, ToList
using System.Threading; // to use Thread.Sleep


class LibrarySystem
{
    private static List<string> arBorrowedBooks = new List<string>();
    private static List<string> enBorrowedBooks = new List<string>();
    private static List<string> EnglishBooks = new List<string> {
        "The Way to Happiness",
        "Romeo and Juliet",
        "To Kill A Mockingbird",
        "Visual C# How to Program",
        "Fundamentals-of-Computer-Programming-with-CSharp",
        "Clean Code and Writing Better Code",
        "Dracula",
        };

   private static List<string> enBooksDetails = new List<string> 
   {
        "A self-help book by L. Ron Hubbard promoting ethical living and personal improvement.",
        "A classic tragedy by William Shakespeare about love and fate.",
        "A Pulitzer Prize-winning novel by Harper Lee about racial injustice in the Deep South.",
        "An introductory programming book using Visual C# as the primary language.",
        "A comprehensive guide to computer programming concepts using C#.",
        "A book on software craftsmanship focusing on writing clean and maintainable code.",
        "A Gothic horror novel by Bram Stoker featuring the iconic character Dracula.",
        };

    private static List<string> enBookLinks = new List<string> {
        "https://heyzine.com/flip-book/5285919977.html",
        "https://heyzine.com/flip-book/a7ccb60e93.html",
        "https://heyzine.com/flip-book/7f81761ea2.html",
        "https://heyzine.com/flip-book/d9634d117d.html",
        "https://heyzine.com/flip-book/98d5dd69ea.html",
        "https://heyzine.com/flip-book/59dff7238e.html",
        "https://heyzine.com/flip-book/a7894b2eb2.html",
        };


    private static List<string> ArabicBooks = new List<string> { 
        Reverse("ارض زيكولا 1"),
        Reverse("ارض زيكولا 2"),
        Reverse("ارض زيكولا 3"),
        Reverse("ما وراء الكواليس الدحيح"),
        Reverse("خوف 1"),
        Reverse("خوف 2"),
        Reverse("خوف 3"),
        Reverse("نادر فوده -الوقاد- 1"),
        Reverse("نادر فوده -كساب- 2"),
        Reverse("نادر فوده -النقش الملعون- 3"),
        Reverse("نادر فوده -عمارة الفزع- 4"),
        Reverse("نادر فوده -العين الثالة- 5"),
        Reverse("نادر فوده -العذراء والجحيم- 6"),
        Reverse("نادر فوده -الاعوان- 7"),
        Reverse("نادر فوده -الآثم- 8")
        };
    
    private static List<string> arBorrowedBooksDetails = new List<string> 
    {
        Reverse("رواية خيالية تتحدث عن مغامرات في عالم زيكولا"),
        Reverse("تكملة مغامرات زيكولا"),
        Reverse("الجزء الثالث من سلسلة زيكولا"),
        Reverse("كتاب يتحدث عن كواليس برنامج الدحيح"),
        Reverse("رواية رعب تتحدث عن الخوف"),
        Reverse("تكملة رواية الخوف"),
        Reverse("الجزء الثالث من سلسلة الخوف"),
        Reverse("الجزء الأول من سلسلة نادر فوده"),
        Reverse("الجزء الثاني من سلسلة نادر فوده"),
        Reverse("الجزء الثالث من سلسلة نادر فوده"),
        Reverse("الجزء الرابع من سلسلة نادر فوده"),
        Reverse("الجزء الخامس من سلسلة نادر فوده"),
        Reverse("الجزء السادس من سلسلة نادر فوده"),
        Reverse("الجزء السابع من سلسلة نادر فوده"),
        Reverse("الجزء الثامن من سلسلة نادر فوده")
    };

    private static List<string> arBookLinks = new List<string> {
        "https://heyzine.com/flip-book/199202c88a.html",
        "https://heyzine.com/flip-book/65cd4ebb98.html",
        "https://heyzine.com/flip-book/b78ab34897.html",
        "https://heyzine.com/flip-book/7f72b1f2d1.html",
        "https://online.fliphtml5.com/dorsa/vmzx/#p=1",
        "https://heyzine.com/flip-book/cab65f368f.html",
        "https://heyzine.com/flip-book/93d12995d9.html",
        "https://heyzine.com/flip-book/7331a5dc27.html",
        "https://heyzine.com/flip-book/c961b23b07.html",
        "https://heyzine.com/flip-book/d444789d9f.html",
        "https://heyzine.com/flip-book/7baf603671.html",
        "https://heyzine.com/flip-book/e83d20e49d.html",
        "https://heyzine.com/flip-book/cda68d78e2.html",
        "https://heyzine.com/flip-book/f718fc8691.html",
        "https://heyzine.com/flip-book/b3555f6e4f.html"
        };
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        //WelcomeScreen();

        // login or create account
        int yourChoice = choseSignInOrUp();
        Choice(yourChoice);
    }

    static void WelcomeScreen()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\n");

        int startLeft = 10;
        int startTop = Console.CursorTop;
        // Print the welcome message with animated letters
        PrintE(startLeft, startTop); 
        PrintL(startLeft + 8, startTop);
        Print3(startLeft + 16, startTop);
        PrintO(startLeft + 25, startTop);
        PrintM(startLeft + 33, startTop);
        PrintA(startLeft + 44, startTop);
        PrintN(startLeft + 52, startTop);
        PrintY(startLeft + 61, startTop);
        Console.ForegroundColor = ConsoleColor.White;
    }

    static int choseSignInOrUp()
    {
        int your_choice; 
        bool isValidInput; 

        do
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nPlease choose an option:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Sign in");
            Console.WriteLine("2. Create a new account");
            Console.Write("\nEnter your choice (1 or 2): ");
            string input = Console.ReadLine();
            isValidInput = int.TryParse(input, out your_choice);

            if (!isValidInput || (your_choice != 1 && your_choice != 2))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input! Please enter 1 or 2.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        while (!isValidInput || (your_choice != 1 && your_choice != 2));

        return your_choice;
    }

    static void Choice(int choice)
    {
        if (choice == 1)
        {
            SignIn();
        }
        else if (choice == 2)
        {
            CreateNewAccount();
        }
    }

    static void SignIn()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("SignIn");
        Console.ForegroundColor = ConsoleColor.White;
        int trayes = 3;
        bool loginOk = false;
        int forgetPassword;
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();   
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (File.Exists("users.txt"))
            {
                string[] lines = File.ReadAllLines("users.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(' ');

                    if (parts.Length >= 2 && parts[0] == username && parts[1] == password)
                    {
                        loginOk = true;
                        break;
                    }
                }

                if (loginOk)
                {
                    Console.WriteLine("Login successful! Welcome to the library.");
                    Console.ForegroundColor = ConsoleColor.White;
                    MainMenu();
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    trayes--;
                    if (trayes > 0)
                    {
                        Console.WriteLine($"Invalid username or password! You have {trayes} trayes remaining.");
                    }
                    else
                    {
                        do
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("Enter 1 if you Forget your Password \nEnter 2 to try sign in\nEnter 0 to Exit");
                            points(".\n", 1, 5, false);
                            Console.ForegroundColor = ConsoleColor.White;
                            bool isValidInput;
                            isValidInput = int.TryParse(Console.ReadLine(), out forgetPassword);
                            if (isValidInput)
                            {
                                if (forgetPassword == 1)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("1- Open the project folder\n2- Open folder 📁(bin) ---->📁(Debug) ---->📁(net8.0) ---->🗃️(users.txt)");
                                    Console.ReadKey();
                                    Exit_Message();
                                }
                                else if (forgetPassword == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Exiting");
                                    points(".", 1, 4, false);
                                    Thread.Sleep(1000);
                                    Exit_Message();
                                }
                                else if (forgetPassword == 2)
                                {
                                    Console.Clear();
                                    SignIn();
                                    return;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Invalid input! Please enter a number.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        } while (true);
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Failed to open the file 'users.txt' ❌❌\nPlease Create a new account");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("if you need to creat enter 1 ");
                points(".", 1, 5, false);
                if (int.TryParse(Console.ReadLine(), out int createAccount) && createAccount == 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Creating a new account...");
                    points(".", 1, 5, false);
                    Thread.Sleep(1000);
                    CreateNewAccount();
                    Console.Clear();
                    return; // مهم حتى لا يكمل تنفيذ الدالة الأصلية
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Exiting");
                    points(".", 1, 4, false);
                    Thread.Sleep(1000);
                    Exit_Message();
                }
            }
        }
        while (!loginOk && trayes > 0);
    }

    static void CreateNewAccount()
    {
        bool createAccountOk = false;
        do
        {
            Console.Write("Enter a new username: ");
            string username = Console.ReadLine();
            Console.Write("Enter a new password: ");
            string password = Console.ReadLine();
            if (username.Length < 3 || password.Length < 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Username and password must be at least 3 characters long. Please try again.");
                Console.ForegroundColor = ConsoleColor.White;
                continue;
            }
            else
            {
                using (StreamWriter file = new StreamWriter("users.txt", true))
                {
                    file.WriteLine($"{username} {password}");
                    Console.WriteLine("Account created successfully!");
                }
                SignIn();
            }
        }while (!createAccountOk);
    }

    static void MainMenu()
    {
        int choice;
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("\n-->Main Menu<--");
            Console.WriteLine("1. English library");
            Console.WriteLine("2. Arabic library");
            Console.WriteLine("3. Exit");
            Console.WriteLine("\t\t\t\t\t\t--------------------------");
            Console.WriteLine("\t\t\t\t\t\tChoose from the Menu (1-3)");
            Console.WriteLine("\t\t\t\t\t\t--------------------------");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    mainEnglishLibrary();
                    break;
                case 2:
                    mainArabicLibrary();
                    break;
                case 3:
                    Exit_Message();
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid choice! Please select 1-3.");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
        while (true);
    }

    static void Exit_Message()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(@" 
                                             ╔════════════════════════════╗
                                             ║       LIBRARY SYSTEM       ║
                                             ╚════════════════════════════╝");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n\t\t\t\t\t Thank you for using our library system!");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.White;
        Environment.Exit(0);
    }

    static void mainEnglishLibrary()
    {
        int bookChoice;
        do
        {
            Console.Clear();
            Console.WriteLine("\nEnglish Library Menu");
            Console.WriteLine("1. View Books");
            Console.WriteLine("2. Borrow a book");
            Console.WriteLine("3. View Borrowed books");
            Console.WriteLine("4. Return a book");
            Console.WriteLine("5. Back to main menu");
            Console.WriteLine("----------------------");
            Console.WriteLine("Choose an action (1-5):");
            Console.WriteLine("----------------------");

            if (!int.TryParse(Console.ReadLine(), out bookChoice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            switch (bookChoice)
            {
                case 1:
                    ViewEnglishBooks();
                    break;
                case 2:
                    BorrowEnglishBook();
                    break;
                case 3:
                    ViewBorrowedEnglishBooks();
                    break;
                case 4:
                    ReturnEnglishBook();
                    break;
                case 5:
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid choice!");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
        while (bookChoice != 5);
    }

    static void ViewEnglishBooks()
    {
        Console.Clear();
        Console.WriteLine("\nAvailable English Books:");
        if (EnglishBooks.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("No books available in English library.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            int bookChose;
            bool validInput;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < EnglishBooks.Count; i++)
                {
                    Console.WriteLine($"({i + 1}).  {EnglishBooks[i]}");
                }
                Console.ResetColor();

                Console.Write("\nEnter the number of the book to view details\nor 0 to cancel: ");
                string input = Console.ReadLine();
                validInput = int.TryParse(input, out bookChose);

                if (!validInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid input! Please enter a number only.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (bookChose < 0 || bookChose > EnglishBooks.Count)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid choice!");
                    Console.ForegroundColor = ConsoleColor.White;
                    validInput = false;
                }
            } while (!validInput);

            if (bookChose > 0 && bookChose <= EnglishBooks.Count)
            {
                Console.WriteLine("\nYou chose: " + EnglishBooks[bookChose - 1]);
                if (bookChose <= enBooksDetails.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(enBooksDetails[bookChose - 1]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("No available Details for this book.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.White;
    }

    static void BorrowEnglishBook()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < EnglishBooks.Count; i++)
        {
            Console.WriteLine($"({i + 1}). {EnglishBooks[i]}");
        }
        Console.ResetColor();
        Console.WriteLine("Enter number of book you want to borrow: ");
        if (int.TryParse(Console.ReadLine(), out int bookIndex))
        {
            
            if (bookIndex > 0 && bookIndex <= EnglishBooks.Count)
            {
                
                int correctedIndex = bookIndex - 1;

                
                while (enBorrowedBooks.Count <= correctedIndex)
                {
                    enBorrowedBooks.Add(null); 
                }

                
                enBorrowedBooks[correctedIndex] = EnglishBooks[correctedIndex];

                Console.Write("Borrowed ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(enBorrowedBooks[correctedIndex]);
                Console.ResetColor();
                Console.WriteLine("Total borrowed English books: " + enBorrowedBooks.Where(b => b != null).Count());
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid book number.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Invalid input!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    static void ViewBorrowedEnglishBooks()
    {
        Console.Clear();
        Console.WriteLine("Borrowed English Books:\n");
        var borrowed = enBorrowedBooks.Where(b => b != null).ToList();
        if (borrowed.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("No books are currently borrowed.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < borrowed.Count; i++)
            {
                Console.WriteLine($"({i + 1}). {borrowed[i]}");
            }
        }
        Console.ForegroundColor = ConsoleColor.White;
        if (borrowed.Count != 0)
        {
            Console.WriteLine("\nEnter the number of the book need Read");
            Console.WriteLine("or 0 to cancel: ");
            if (int.TryParse(Console.ReadLine(), out int bookChose))
            {
                if (bookChose > 0 && bookChose <= borrowed.Count)
                {
                    string selectedBook = borrowed[bookChose - 1];
                    int originalIndex = enBorrowedBooks.FindIndex(b => b == selectedBook);

                    Console.Write("\nYou chose: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(selectedBook);
                    Console.ForegroundColor = ConsoleColor.White;
                    if (originalIndex >= 0 && originalIndex < enBookLinks.Count)
                    {
                        Console.WriteLine("Link to Read:");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(enBookLinks[originalIndex]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No available link for this book.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (bookChose != 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid choice!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    static void ReturnEnglishBook()
    {
        var borrowed = enBorrowedBooks
            .Select((book, idx) => new { book, idx })
            .Where(x => x.book != null)
            .ToList();

        if (borrowed.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No books are currently borrowed.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Borrowed English Books:");
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < borrowed.Count; i++)
        {
            Console.WriteLine($"({i + 1}). {borrowed[i].book}");
        }
        Console.ForegroundColor = ConsoleColor.White;

        int bookIndex;
        bool validInput;
        do
        {
            Console.Write("\nEnter the number of the book to return (0 to cancel): ");
            string input = Console.ReadLine();
            validInput = int.TryParse(input, out bookIndex);

            if (!validInput)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input! Please enter a valid number.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (bookIndex < 0 || bookIndex > borrowed.Count)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid book number.");
                Console.ForegroundColor = ConsoleColor.White;
                validInput = false;
            }
        } while (!validInput);

        if (bookIndex == 0)
            return;

        int originalIndex = borrowed[bookIndex - 1].idx;
        string returnedBook = enBorrowedBooks[originalIndex];
        enBorrowedBooks[originalIndex] = null;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Book '{returnedBook}' \nhas been returned successfully.");
        Console.ForegroundColor = ConsoleColor.White;

        int remaining = enBorrowedBooks.Count(b => b != null);
        Console.WriteLine($"Remaining borrowed books: {remaining}");

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.White;
    }

    static void mainArabicLibrary()
    {
        int bookChoice;
        do
        {
            Console.Clear();
            Console.WriteLine(Reverse("\nقائمة الكتب العربيه"));
            Console.WriteLine(Reverse("1. عرض الكتب"));
            Console.WriteLine(Reverse("2. استعارة كتاب"));
            Console.WriteLine(Reverse("3. عرض الكتب المستعارة"));
            Console.WriteLine(Reverse("4. اعادة كتاب"));
            Console.WriteLine(Reverse("5. العوده الي القائمه الرئيسيه"));
            Console.WriteLine("-----------------------");
            Console.WriteLine(Reverse("اختر من القائمه= )1-5(:"));
            Console.WriteLine("-----------------------");

            if (int.TryParse(Console.ReadLine(), out bookChoice))
            {
                switch (bookChoice)
                {
                    case 1:
                        ViewArabicBooks();
                        break;
                    case 2:
                        BorrowArabicBook();
                        break;
                    case 3:
                        ViewBorrowedArabicBooks();
                        break;
                    case 4:
                        ReturnArabicBook();
                        break;
                    case 5:
                        MainMenu();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(Reverse("اختيار خاطئ!"));
                        Console.ResetColor();
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(Reverse("اختيار خاطئ!"));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(Reverse("\nاضغط أي مفتاح للمتابعة..."));
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        while (bookChoice != 5);
    }

    static void ViewArabicBooks()
    {
        Console.Clear();
        Console.WriteLine(Reverse("\nالكتب العربيه المتاحه:"));
        if (ArabicBooks.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Reverse("لا يوجد كتب متاحه في المكتبه العربيه."));
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            int book_choice;
            bool validInput;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < ArabicBooks.Count; i++)
                {
                    Console.WriteLine($"({i + 1}). {ArabicBooks[i]}");
                }
                Console.ResetColor();

                Console.Write(Reverse("   اختر رقم الكتاب لعرض التفاصيل او ختر 0 للالغاء \n"));
                string input = Console.ReadLine();
                validInput = int.TryParse(input, out book_choice);

                if (!validInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(Reverse("ادخال خاطئ! يجب إدخال رقم فقط."));
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (book_choice < 0 || book_choice > ArabicBooks.Count)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(Reverse("اختيار خاطئ!"));
                    Console.ForegroundColor = ConsoleColor.White;
                    validInput = false;
                }
            } while (!validInput);

            if (book_choice > 0 && book_choice <= ArabicBooks.Count)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(ArabicBooks[book_choice - 1]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(Reverse(" لقد اخترت : "));
                if (book_choice <= arBookLinks.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(arBorrowedBooksDetails[book_choice - 1]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(Reverse("لا تفاصيل متاحه لهذا الكتاب."));
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(Reverse("\nاضغط أي مفتاح للمتابعة..."));
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.White;
    }

    static void BorrowArabicBook()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < ArabicBooks.Count; i++)
        {
            Console.WriteLine($"({i + 1}). {ArabicBooks[i]}");
        }
        Console.ResetColor();
        Console.Write(Reverse(" ادخل رقم الكتاب المراد استعارته:"));
        if (int.TryParse(Console.ReadLine(), out int bookIndex))
        {
            if (bookIndex > 0 && bookIndex <= ArabicBooks.Count)
            {
                int correctedIndex = bookIndex - 1;

                while (arBorrowedBooks.Count <= correctedIndex)
                {
                    arBorrowedBooks.Add(null); // أو string.Empty حسب احتياجك
                }
                arBorrowedBooks[correctedIndex] = ArabicBooks[correctedIndex];
               
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(arBorrowedBooks[correctedIndex]);
                Console.ResetColor();
                Console.WriteLine(Reverse("تم استعارة:  "));
                Console.WriteLine( arBorrowedBooks.Where(b => b != null).Count()+ Reverse("الكتب المستعاره الكليه: "));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(Reverse("\nاضغط أي مفتاح للمتابعة..."));
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(Reverse("عدد كتب خاطئ"));
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Reverse("ادخال خاطئ!"));
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    static void ViewBorrowedArabicBooks()
    {
        Console.Clear();
        Console.WriteLine(Reverse("الكتب المستعارة العربيه:"));
        var borrowed = arBorrowedBooks.Where(b => b != null).ToList();
        if (borrowed.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Reverse("لا يوجد كتب مستعارة حاليا."));
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < borrowed.Count; i++)
            {
                Console.WriteLine($"({i + 1}). {borrowed[i]}");
            }
        }
        Console.ForegroundColor = ConsoleColor.White;
        if (borrowed.Count != 0)
        {
            Console.Write(Reverse("\nادخل رقم الكتاب المراد قراءته او 0 للالغاء: "));
            if (int.TryParse(Console.ReadLine(), out int bookChose))
            {
                if (bookChose > 0 && bookChose <= borrowed.Count)
                {
                    string selectedBook = borrowed[bookChose - 1];
                    int originalIndex = arBorrowedBooks.FindIndex(b => b == selectedBook);

                    Console.Write(Reverse("\nلقد اخترت: "));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(selectedBook);
                    Console.ForegroundColor = ConsoleColor.White;
                    if (originalIndex >= 0 && originalIndex < arBookLinks.Count)
                    {
                        Console.WriteLine(Reverse("رابط القراءه: "));
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(arBookLinks[originalIndex]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(Reverse("لا روابط متاحه لهذا الكتاب."));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (bookChose != 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(Reverse("اختيار خاطئ!"));
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(Reverse("ادخال خاطئ!"));
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(Reverse("\nاضغط أي مفتاح للمتابعة..."));
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(Reverse("\nاضغط أي مفتاح للمتابعة..."));
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    static void ReturnArabicBook()
    {
        var borrowed = arBorrowedBooks
            .Select((book, idx) => new { book, idx })
            .Where(x => x.book != null)
            .ToList();

        if (borrowed.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Reverse("\nلا يوجد كتب مستعارة"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Reverse("\nاضغط أي مفتاح للمتابعة..."));
            Console.ReadKey();
            return;
        }

        Console.WriteLine(Reverse("الكتب المستعارة"));
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < borrowed.Count; i++)
        {
            Console.WriteLine($"({i + 1}). {borrowed[i].book}");
        }
        Console.ForegroundColor = ConsoleColor.White;

        int bookIndex;
        bool validInput;
        do
        {
            Console.WriteLine(Reverse("\nأدخل رقم الكتاب للاعادة "));
            Console.Write(Reverse("(0 لإلغاء العملية): "));
            string input = Console.ReadLine();
            validInput = int.TryParse(input, out bookIndex);

            if (!validInput)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(Reverse("إدخال غير صحيح! الرجاء إدخال رقم صحيح..."));
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (bookIndex < 0 || bookIndex > borrowed.Count)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(Reverse("رقم الكتاب غير صالح أو الكتاب غير مستعار..."));
                Console.ForegroundColor = ConsoleColor.White;
                validInput = false;
            }
        } while (!validInput);

        if (bookIndex == 0)
            return;

        int originalIndex = borrowed[bookIndex - 1].idx;
        string returnedBook = arBorrowedBooks[originalIndex];
        arBorrowedBooks[originalIndex] = null;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(Reverse($"تم اعادته بنجاح... كتاب {returnedBook}"));
        Console.ForegroundColor = ConsoleColor.White;

        int remaining = arBorrowedBooks.Count(b => b != null);
        Console.WriteLine(Reverse($"الكتب المستعارة المتبقية: {remaining}"));

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(Reverse("\nاضغط أي مفتاح للمتابعة..."));
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static string Reverse(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    static void PrintE(int startLeft, int startTop)
    {
        string[] eLines = {
            "███████╗",
            "██╔════╝",
            "█████╗░░",
            "██╔══╝░░",
            "███████╗",
            "╚══════╝"
        };
        PrintAnimatedLetter(eLines, startLeft, startTop);
    }

    static void PrintL(int startLeft, int startTop)
    {
        string[] aLines = {
            "██╗░░░░░",
            "██║░░░░░",
            "██║░░░░░░░",
            "██║░░░░░░░",
            "███████░",
            "╚═════╝░"
        };
        PrintAnimatedLetter(aLines, startLeft, startTop);
    }

    static void Print3(int startLeft, int startTop)
    {
        string[] gLines = {
            "╔███████╗",
            "╚════╗██║",
            "░░╔█████║",
            "░░╚══╗██║",
            "╔███████╝",
            "╚══════╝░"
        };
        PrintAnimatedLetter(gLines, startLeft, startTop);
    }

    static void PrintO(int startLeft, int startTop)
    {
        string[] lLines = {
            "░█████╗░",
            "██╔══██╗",
            "██║░░██║",
            "██║░░██║",
            "╚█████╔╝",
            "░╚════╝░"
        };
        PrintAnimatedLetter(lLines, startLeft, startTop);
    }

    static void PrintM(int startLeft, int startTop)
    {
        string[] sLines = {
            "███╗░░░███╗",
            "████╗░████║",
            "██╔████╔██║",
            "██║╚██╔╝██║",
            "██║░╚═╝░██║",
            "╚═╝░░░░░╚═╝"
        };
        PrintAnimatedLetter(sLines, startLeft, startTop);
    }

    static void PrintA(int startLeft, int startTop)
    {
        string[] sLines = {
            "░█████╗░",
            "██╔══██╗",
            "███████║",
            "██╔══██║",
            "██║░░██║",
            "╚═╝░░╚═╝"
        };
        PrintAnimatedLetter(sLines, startLeft, startTop);
    }

    static void PrintN(int startLeft, int startTop)
    {
        string[] sLines = {
            "███╗░░██╗",
            "████╗░██║",
            "██╔██╗██║",
            "██║╚████║",
            "██║░╚███║",
            "╚═╝░░╚══╝"
        };
        PrintAnimatedLetter(sLines, startLeft, startTop);
    }

    static void PrintY(int startLeft, int startTop)
    {
        string[] sLines = {
            "██╗░░░██╗",
            "██║░░░██║",
            "██║░░░██║",
            "██║░░░██║",
            "╚██████╔╝",
            "░╚═════╝░",
            "      ██",
            "      ██\n                  █████████████████████████████████████████████████████████████"
        };
        PrintAnimatedLetter(sLines, startLeft, startTop);
    }

    static void PrintAnimatedLetter(string[] letterLines, int startLeft, int startTop)
    {
        for (int i = 0; i < letterLines.Length; i++)
        {
            Console.SetCursorPosition(startLeft, startTop + i);
            foreach (char c in letterLines[i])
            {
                Console.Write(c);
                Thread.Sleep(5); // سرعة ظهور الحروف
            }
        }
        Thread.Sleep(60); // تأخير بعد انتهاء الحرف
    }

    static void points(string s, int ret, int num, bool cleer)
    {
        for (int i = 1; i <= ret; i++)
        {
            for (int j = 1; j <= num; j++)
            {
                Console.Write(s);
                Thread.Sleep(150);
            }
            if (cleer)
                Console.Clear();
        }
    }
}