using System;

namespace CoffeeMaker
{
    public static class ValidationResultCodeExtensions
    {
        public static string ToDisplayName(this ValidationResultCode code)
        {
            switch (code)
            {
                case ValidationResultCode.OK:
                    return "OK";
                case ValidationResultCode.FillWaterContainer:
                    return "Fill water container";
                case ValidationResultCode.FillBeansContainer:
                    return "Fill beans container";
                case ValidationResultCode.UsedCoffeeDispenserFull:
                    return "Coffee dispenser full";
                case ValidationResultCode.DripTrayFull:
                    return "Water drip tray full";
                default:
                    return code.ToString();
            }
        }
    }
}