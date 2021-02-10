using System;
using UnityEngine;

namespace CoffeeMaker
{
    [Serializable]
    public class CoffeeMachineConfig
    {
        [Header("Coffee sizes")] 
        [Range(0, 500)] public float SmallWaterGrams = 50f;
        [Range(0, 500)] public float MediumWaterGrams = 100f;
        [Range(0, 500)] public float LargeWaterGrams = 200f;

        [Header("Coffee intensities")] 
        [Range(0, 50)] public float LightCoffeeGrams = 6f;
        [Range(0, 50)] public float MediumCoffeeGrams = 10f;
        [Range(0, 50)] public float StrongCoffeeGrams = 14f;

        [Header("Coffee machine components")] 
        [Range(0, 2000)] public float WaterContainerCapacity = 1000;
        [Range(0, 2000)] public float BeansContainerCapacity = 1000;
        [Range(0, 1000)] public float BeansDispenserCapacity = 100;
        [Range(0, 1000)] public float WaterDripCapacity = 100;
        
        [Header("Misc.")]
        public float BeansWaterAbsorbPerGram = .5f;

        public float GetGramsForSize(CoffeeSize size)
        {
            switch (size)
            {
                case CoffeeSize.Small:
                    return SmallWaterGrams;
                case CoffeeSize.Medium:
                    return MediumWaterGrams;
                case CoffeeSize.Large:
                    return LargeWaterGrams;
                default:
                    return MediumWaterGrams;
            }
        }

        public float GetGramsForIntensity(CoffeeIntensity intensity)
        {
            switch (intensity)
            {
                case CoffeeIntensity.Light:
                    return LightCoffeeGrams;
                case CoffeeIntensity.Medium:
                    return MediumCoffeeGrams;
                case CoffeeIntensity.Strong:
                    return StrongCoffeeGrams;
                default:
                    return MediumCoffeeGrams;
            }
        }
    }
}