
namespace L00177804_Project.Models
{

    public class Vehicle
    {
     
        public int Id { get; set; }
        public string Name { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string FuelType { get; set; }

        public double Odometer { get; set; }

        public string EngineSize { get; set; }

        public string FuelConsumption { get; set; }

        public string InsurencePolicy { get; set; }

        public string InsurenceCompany { get; set; }

        public string Licence { get; set; }

        public string Distance { get; set; }


       
        public override string ToString()
        {
            return Name;
        }

    }
}
