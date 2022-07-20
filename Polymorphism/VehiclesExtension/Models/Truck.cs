namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double TruckFuelConsumptionIncrement = 1.6;
        private const double RefuelCoeffiecient = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        protected override double FuelConsumptionModifier
            => TruckFuelConsumptionIncrement;

        protected override double AdditionalConsumption => TruckFuelConsumptionIncrement;

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            this.FuelQuantity -= liters * RefuelCoeffiecient;
        }
    }
}