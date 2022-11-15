public class Developer
{
    public Developer()
    {

    }
    public Developer(string firstName, string lastName, bool hasAccess)
    {
        FirstName = firstName;
        LastName = lastName;
        this.hasAccess = hasAccess;
    }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { 
        get {
        return $"{FirstName} {LastName}";  
        
        }
    }
    public bool hasAccess { get; set; }
    

}
