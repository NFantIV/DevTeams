public class DevRepository
{
    private readonly List<Developer>
    _DeveloperDB = new List<Developer>();
    private int _count;
    
    // Create
    public bool AddDeveloperToDB(Developer developer)
    {
        if (developer is null)
        {
            return false;
        }
        else
        {
            _count++;
            developer.Id = _count;
            _DeveloperDB.Add(developer);
            return true;
        }
    }

    // Read
    public List<Developer> GetDevelopers()
    {
        return _DeveloperDB;
    }

    public Developer GetDeveloper(int developerId)
    {
        foreach (Developer developer in _DeveloperDB)
        {
            if (developer.Id == developerId)
            {
                return developer;
            }
        }
        return null;
    }

// Update
    public bool UpdateDeveloperData(int developerId, Developer updatedDeveloperData)
    {
        Developer developerInDb = GetDeveloper(developerId);
        if (developerInDb != null)
        {
            developerInDb.FirstName = updatedDeveloperData.FirstName;
            developerInDb.LastName = updatedDeveloperData.LastName;
            developerInDb.hasAccess = updatedDeveloperData.hasAccess;
            
            return true;
        }
        return false;
    }

    public bool DeletePlayer(int developerId)
    {
        Developer developerInDb = GetDeveloper(developerId);

        if (developerInDb != null)
        {
            _DeveloperDB.Remove(developerInDb);
            return true;
        }
    return false;
    }
}

