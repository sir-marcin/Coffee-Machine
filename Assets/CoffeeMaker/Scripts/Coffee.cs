namespace CoffeeMaker
{
    public class Coffee
    {
        public CoffeeSize Size { get; }
        public CoffeeIntensity Intensity { get; }
        
        public Coffee(CoffeeSize size, CoffeeIntensity intensity)
        {
            Size = size;
            Intensity = intensity;
        }

        public override string ToString()
        {
            return $"{Size}, {Intensity}";
        }
    }
}