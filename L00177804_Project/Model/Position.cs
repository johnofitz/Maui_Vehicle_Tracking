namespace L00177804_Project.Model
{
    public partial class Position: ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(LocationString))]
        public Location _location;
        public string Address { get; }

        public string Description { get; }

        public string LocationString => $"{Location.Latitude}, {Location.Longitude}";

        public Position(string address, string description, Location location)
        {
            Address = address;
            Description = description;
            Location = location;
        }

   

    }
}
