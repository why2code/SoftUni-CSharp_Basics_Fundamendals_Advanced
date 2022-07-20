namespace VehiclesExtension.Models
{
    using Interfaces;
    public class Bus : Vehicle
    {
        private const double CarFuelConsumptionIncrement = 1.4; //was 0.9, should we add 1.9 to 0.9?
        private AirConditionerMode airConditionerMode;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double FuelConsumptionModifier
            => 0;

        protected override double AdditionalConsumption =>
             airConditionerMode == AirConditionerMode.On
                 ? CarFuelConsumptionIncrement
                 : 0;


        public void SwitchACOn()
        {
            airConditionerMode = AirConditionerMode.On;
        }

        public void SwitchACOff()
        {
            airConditionerMode = AirConditionerMode.Off;
        }

    }
}