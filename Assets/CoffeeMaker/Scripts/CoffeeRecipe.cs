using System;
using UnityEngine;

namespace CoffeeMaker
{
    [Serializable]
    public class CoffeeRecipe
    {
        [SerializeField] string name;
        [SerializeField] CoffeeSize size = CoffeeSize.Medium;
        [SerializeField] CoffeeIntensity intensity = CoffeeIntensity.Medium;

        public static CoffeeRecipe SmallestAndLightest => new CoffeeRecipe(CoffeeSize.Small, CoffeeIntensity.Light);
        
        public string Name => name;
        public CoffeeSize Size => size;
        public CoffeeIntensity Intensity => intensity;
        public bool IsHotWater => intensity == CoffeeIntensity.None;
        
        public CoffeeRecipe(CoffeeSize size, CoffeeIntensity intensity, string name)
        {
            this.name = name;
            this.size = size;
            this.intensity = intensity;
        }
        
        public CoffeeRecipe(CoffeeSize size, CoffeeIntensity intensity) : this(size, intensity, string.Empty)
        {
        }
    }
}