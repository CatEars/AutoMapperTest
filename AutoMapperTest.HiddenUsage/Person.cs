namespace AutoMapperTest.HiddenUsage
{
    public class Person
    {
        // ??? Where is this ever used ???
        public string Name
        {
            // ??? UNUSED? can it be removed ???
            get;
        }
        
        public int HeightInCm { get; }

        public Person(string name, int heightInCm)
        {
            Name = name;
            HeightInCm = heightInCm;
        }
    }
}