using static System.Console;
public class Program_UI
{
    private readonly DevRepository _dRepo = new DevRepository();
    public void Run()
    {
        RunApplication();
    }
    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            WriteLine("Welcome to Dev Team Database\n" +
            "1. Add Developer to database\n" +
            "2. View All Developers\n" +
            "3. View Developer By Id\n" +
            "4. Update Developer Data\n" +
            "5. Delete Developer Data\n" +
            "0. Exit App\n");
            
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                AddDeveloperToDataBase();
                break;
                case "2":
                ViewAllDevelopers();
                break;
                case "3":
                ViewDeveloperDataById();
                break;
                case "4":
                UpdateDeveloperData();
                break;
                case "5":
                DeleteDeveloperData();
                break;
                case "0":
                isRunning = ExitApplication();
                break;
                default:
                WriteLine("Invalid, Selection.");
                PressAnyKey();
                break;
            }
        }
    }

    private void AddDeveloperToDataBase()
    {
        Clear();
        WriteLine("Add Developer");

        Developer developer = new Developer();

        WriteLine("Please enter the developers first name.");
        developer.FirstName = ReadLine();

        WriteLine("Please enter the developers last name.");
        developer.LastName = ReadLine();

        WriteLine("Does the developer have access to Pluralsight? y/n");

        string userInput = ReadLine();
        if (userInput == "Y".ToLower())
        {
            developer.hasAccess = true;
        }
        else
        {
            developer.hasAccess = false;
        }
        
        if (_dRepo.AddDeveloperToDB(developer))
        {
            WriteLine("Success");
        }
        else
        {
            WriteLine("Failure");
        }
        ReadKey();
    }
    private void ViewAllDevelopers()
    {
        Clear();
        WriteLine("== Developers ==");

        List<Developer> developersInDb = _dRepo.GetDevelopers();
        foreach (Developer developer in developersInDb)
        {
            DisplayDeveloperData(developer);
        }
        ReadKey();
    }
    private void DisplayDeveloperData(Developer developer)
    {
        WriteLine
        (
            $"Developer Id: {developer.Id}\n" +
            $"Developer Name: {developer.FullName}\n" +
            $"Developer have access?: {developer.hasAccess}"
        
        );
    }

    private void ViewDeveloperDataById()
    {
        Clear();
        WriteLine("--Developer Info--");
        WriteLine("Please enter a developer Id.");
        int userInput = int.Parse(ReadLine());
        Developer developerInDb = _dRepo.GetDeveloper(userInput);
        {
            if (developerInDb != null)
            {
                DisplayDeveloperData(developerInDb);
            }
            else
            {
                WriteLine($"Sorry the player with id: {userInput} does not exist.");
            }
            ReadKey();
        }
    }
    private void UpdateDeveloperData()
    {
        Clear();
        WriteLine("Please enter a Developer Id.");
        int userInput = int.Parse(ReadLine());
        Developer developerInDb = _dRepo.GetDeveloper(userInput);
        if (developerInDb != null)
        {
            Developer updatedDeveloperData = new Developer();
            WriteLine("Please enter the developers first name.");
            updatedDeveloperData.FirstName = ReadLine();

            WriteLine("Please enter the developers last name.");
            updatedDeveloperData.LastName = ReadLine();
            WriteLine("Does the developer have access to PularSight");
            
            string developerHaveAccess = ReadLine();
            if (developerHaveAccess == "Y".ToLower())
            {
                updatedDeveloperData.hasAccess = true;
            }
            else
            {
                updatedDeveloperData.hasAccess = false;
            }
            if (_dRepo.UpdateDeveloperData(developerInDb.Id, updatedDeveloperData))
            {
                WriteLine("Success");
            }
            else
            {
                WriteLine("Failure");
            }
        }
        else
        {
            WriteLine($"Sorry the developer with id: {userInput} doesn't exist.");
        }
        ReadKey();
    }
    private void DeleteDeveloperData()
    {
        Clear();
        WriteLine("Please enter a Developer Id.");
        int userInput = int.Parse(ReadLine());
        Developer developerInDb = _dRepo.GetDeveloper(userInput);
        if (developerInDb != null) 
        {
            if (_dRepo.DeletePlayer(developerInDb.Id))
            {
                WriteLine("Success");
            }
            else
            {
                WriteLine("Failure");
            }
        }
        else
        {
            WriteLine($"Sorry the developer with id: {userInput} doesnt exist.");
        }
        ReadKey();
    }
    private bool ExitApplication()
    {
        WriteLine("Thank you for coming to our app!");
        PressAnyKey();
        return false;
    }
    private void PressAnyKey()
    {
        WriteLine("Press any key to continue.");
        ReadKey();
    }

    public void SeedData()
    {
        Developer developerA = new Developer("Michael", "Jordan", true);
        Developer developerB = new Developer("Lebron", "James", true);
        Developer developerC= new Developer("Patrick", "Mahomes", true);
        Developer developerD = new Developer("Lamar", "Jackson", true);

        _dRepo.AddDeveloperToDB(developerA);
        _dRepo.AddDeveloperToDB(developerB);
        _dRepo.AddDeveloperToDB(developerC);
        _dRepo.AddDeveloperToDB(developerD);

    }
}









