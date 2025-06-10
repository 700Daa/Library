using System;
using System.Collections.Generic; // to uses Lists<> 
using System.IO; // to use File, StreamWriter, StreamReader
using System.Linq; // to use LINQ methods like Where, ToList
using System.Threading; // to use Thread.Sleep


class LibrarySystem
{
    private static List<string> arBorrowedBooks = new List<string>();
    private static List<string> enBorrowedBooks = new List<string>();
    private static List<string> EnglishBooks = new List<string> { "The Push", "Bride Read", "The Hedge", "It", "The Coming of the Ice" };
    private static List<string> ArabicBooks = new List<string> { Reverse("في قلبي انثى عبرية"), Reverse("ارض زيكولا 1"), Reverse("ارض زيكولا 2"), Reverse("ارض زيكولا 3"), Reverse("ما وراء الكواليس الدحيح") };
    private static List<string> enBookLinks = new List<string> {
        "https://www.readanybook.com/online/684299",
        "https://www.readanybook.com/online/765632#583144",
        "https://www.readanybook.com/online/765193#582482",
        "https://www.readanybook.com/ebook/it-book-565296",
        "https://www.readanybook.com/online/10556#9479" };
    private static List<string> arBookLinks = new List<string> {
        "https://docs.google.com/viewerng/viewer?hl=ar&t=1&url=https://www.alarabimag.com/books/22459.pdf",
        "https://docs.google.com/viewerng/viewer?hl=ar&t=8&url=https://www.alarabimag.com/books/22375.pdf",
        "https://docs.google.com/viewerng/viewer?hl=ar&t=22&url=https://www.alarabimag.com/books/34834.pdf",
        "https://archive.org/details/2_20240503_20240503_0905/1-%20%D8%A3%D8%B1%D8%B6%20%D8%B2%D9%8A%D9%83%D9%88%D9%84%D8%A7",
        "https://kolalkotob.com/read/3141" };
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
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();
        int trayes = 3;
        bool loginOk = false;
        int forgetPassword;
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
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
            Console.WriteLine("3. Return a book");
            Console.WriteLine("4. Back to main menu");
            Console.WriteLine("----------------------");
            Console.WriteLine("Choose an action (1-4):");
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
                    ReturnEnglishBook();
                    break;
                case 4:
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
        while (bookChoice != 4);
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
            for (int i = 0; i < EnglishBooks.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + EnglishBooks[i]);
            }

            Console.Write("\nEnter the number of the book to view details\nor 0 to cancel: ");
            if (int.TryParse(Console.ReadLine(), out int bookChose))
            {
                if (bookChose > 0 && bookChose <= EnglishBooks.Count)
                {
                    Console.WriteLine("\nYou chose: " + EnglishBooks[bookChose - 1]);
                    if (bookChose <= enBookLinks.Count)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Link to Read: \n" + enBookLinks[bookChose - 1]);
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
            Console.WriteLine((i + 1) + ". " + EnglishBooks[i]);
        }
        Console.ResetColor();
        Console.WriteLine("Enter number of book you want to borrow: ");
        if (int.TryParse(Console.ReadLine(), out int bookIndex))
        {
            // التحقق من أن الفهرس صالح
            if (bookIndex > 0 && bookIndex <= EnglishBooks.Count)
            {
                // تصحيح الفهرس ليكون من صفر
                int correctedIndex = bookIndex - 1;

                // التأكد من أن القائمة لها حجم كافٍ
                while (enBorrowedBooks.Count <= correctedIndex)
                {
                    enBorrowedBooks.Add(null); // أو string.Empty حسب احتياجك
                }

                // إضافة الكتاب المستعار في نفس الفهرس
                enBorrowedBooks[correctedIndex] = EnglishBooks[correctedIndex];

                Console.Write("Borrowed ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(enBorrowedBooks[correctedIndex]);
                Console.ResetColor();
                Console.WriteLine("Total borrowed English books: " + enBorrowedBooks.Where(b => b != null).Count());
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
    
    static void ReturnEnglishBook()
    {
        if (enBorrowedBooks.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No books are currently borrowed.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Borrowed English Books:");
        for (int i = 0; i < enBorrowedBooks.Count; i++)
        {
            if (enBorrowedBooks[i] != null)
            {
                Console.WriteLine($"{i + 1}. {enBorrowedBooks[i]}");
            }
        }

        Console.Write("\nEnter the number of the book to return (0 to cancel): ");
        if (int.TryParse(Console.ReadLine(), out int bookIndex))
        {
            if (bookIndex == 0)
            {
                return; // إلغاء العملية
            }

            // تصحيح الفهرس ليكون من صفر
            int correctedIndex = bookIndex - 1;

            if (correctedIndex >= 0 && correctedIndex < enBorrowedBooks.Count && enBorrowedBooks[correctedIndex] != null)
            {
                string returnedBook = enBorrowedBooks[correctedIndex];
                enBorrowedBooks[correctedIndex] = null;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Book '{returnedBook}' has been returned successfully.");
                Console.ForegroundColor = ConsoleColor.White;

                // حساب الكتب المستعارة المتبقية
                int remaining = enBorrowedBooks.Count(b => b != null);
                Console.WriteLine($"Remaining borrowed books: {remaining}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid book number or book not borrowed.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Invalid input! Please enter a valid number.");
            Console.ForegroundColor = ConsoleColor.White;
        }

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
            Console.WriteLine(Reverse("3. اعادة كتاب"));
            Console.WriteLine(Reverse("4. العوده الي القائمه الرئيسيه"));
            Console.WriteLine("-----------------------");
            Console.WriteLine(Reverse("اختر من القائمه= )1-4(:"));
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
                        ReturnArabicBook();
                        break;
                    case 4:
                        MainMenu();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(Reverse("اختيار خاطئ!"));
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
        while (bookChoice != 4);
    }

    static void ViewArabicBooks()
    {
        Console.Clear();
        Console.WriteLine(Reverse("\nالكتب العربيه المتاحه:"));
        if (ArabicBooks.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Reverse("لا كتب متاحه في المكتبه العربيه."));
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            for (int i = 0; i < ArabicBooks.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + ArabicBooks[i]);
            }

            Console.Write(Reverse("   اختر رقم الكتاب لعرض التفاصيل او ختر 0 للالغاء \n"));
            if (int.TryParse(Console.ReadLine(), out int book_choice))
            {
                if (book_choice > 0 && book_choice <= ArabicBooks.Count)
                {
                    Console.WriteLine(ArabicBooks[book_choice - 1] + Reverse(" لقد اخترت : "));
                    if (book_choice <= arBookLinks.Count)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(Reverse("\nرابط القراءه: ") + arBookLinks[book_choice - 1]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(Reverse("لا روابط متاحه لهذا الكتاب."));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (book_choice != 0)
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
            Console.WriteLine((i + 1) + ". " + ArabicBooks[i]);
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
                Console.WriteLine(Reverse("تم استعارة  "));
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(arBorrowedBooks[correctedIndex]);
                Console.ResetColor();
                Console.WriteLine(Reverse("الكتب المستعاره الكليه ") + arBorrowedBooks.Where(b => b != null).Count());
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

    static void ReturnArabicBook()
    {
        if (arBorrowedBooks.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Reverse("لا يوجد كتب مستعارة"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Reverse("\nاضغط أي مفتاح للمتابعة..."));
            Console.ReadKey();
            return;
        }

        Console.WriteLine(Reverse("الكتب المستعارة"));
        for (int i = 0; i < arBorrowedBooks.Count; i++)
        {
            if (arBorrowedBooks[i] != null)
            {
                Console.WriteLine($"{i + 1}. {arBorrowedBooks[i]}");
            }
        }

        Console.WriteLine(Reverse("\nأدخل رقم الكتاب للاعادة "));
        Console.Write(Reverse("(0 لإلغاء العملية): "));
        if (int.TryParse(Console.ReadLine(), out int bookIndex))
        {
            if (bookIndex == 0)
            {
                return;
            }

            int correctedIndex = bookIndex - 1;

            if (correctedIndex >= 0 && correctedIndex < arBorrowedBooks.Count && arBorrowedBooks[correctedIndex] != null)
            {
                string returnedBook = arBorrowedBooks[correctedIndex];
                arBorrowedBooks[correctedIndex] = null;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Reverse($"كتاب {returnedBook} تم اعادته بنجاح..."));
                Console.ForegroundColor = ConsoleColor.White;

                // حساب الكتب المستعارة المتبقية
                int remaining = arBorrowedBooks.Count(b => b != null);
                Console.WriteLine(Reverse($"الكتب المستعارة المتبقية: {remaining}"));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(Reverse("رقم الكتاب غير صالح أو الكتاب غير مستعار..."));
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Reverse("إدخال غير صحيح! الرجاء إدخال رقم صحيح..."));
            Console.ForegroundColor = ConsoleColor.White;
        }

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