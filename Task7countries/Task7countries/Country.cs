namespace Task7countries
{
    class Country
    {
        public string Name { get; set; }
        public bool IsTelenorSupported { get; set; }
        public Country(string name, bool supported)
        {
            this.Name = name;
            this.IsTelenorSupported = supported;

        }
    }
}