public class DevTeam
    {
        public DevTeam() { }
        
        public DevTeam(string name, List<Developer> developers)
        {
            Name = name;
            Developers = developers;
        }
        public DevTeam(string name)
        {
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List <Developer> Developers { get; set; } = new List<Developer>
        ();
    }

