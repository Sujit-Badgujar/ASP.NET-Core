namespace Services
{
    public class CitiesService
    {
        private List<string> cities;

        public CitiesService() 
        {
            cities = new List<string>()
            {
              "Sinnar",
              "Nashik",
              "Pune"  
            };
        }

        public List<string> GetCities() 
        {
            return cities;  
        }
    }
}
