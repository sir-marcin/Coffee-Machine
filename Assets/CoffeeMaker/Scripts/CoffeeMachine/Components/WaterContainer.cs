using System.Collections;
using UnityEngine;

namespace CoffeeMaker
{
    public class WaterContainer : CoffeeMachineComponent
    {
        const float SECONDS_PER_GRAM = .05f;
        
        float waterGrams = 500f;
        
        public override string Name => "Water container";
        public override float CurrentAmount => waterGrams;
        public override float MaxAmount => config.WaterContainerCapacity;

        public override void Initialize(CoffeeMachineConfig config)
        {
            base.Initialize(config);

            if (HasSavedValue(out var value))
            {
                waterGrams = value;
            }
        }

        public override void Service()
        {
            waterGrams = MaxAmount;
        }

        public override bool CanMakeRecipe(CoffeeRecipe recipe, out ValidationResultCode validationResultCode)
        {
            validationResultCode = ValidationResultCode.OK;

            var beansAmount = config.GetGramsForIntensity(recipe.Intensity);
            var requiredWater = config.GetGramsForSize(recipe.Size) + beansAmount * config.BeansWaterAbsorbPerGram;

            if (waterGrams < requiredWater)
            {
                validationResultCode = ValidationResultCode.FillWaterContainer;
                return false;
            }

            return true;
        }

        public override IEnumerator ProcessRecipe(CoffeeRecipe recipe)
        {
            var beansAmount = config.GetGramsForIntensity(recipe.Intensity);
            var requiredWater = config.GetGramsForSize(recipe.Size) + beansAmount * config.BeansWaterAbsorbPerGram;

            yield return new WaitForSeconds(requiredWater * SECONDS_PER_GRAM);

            waterGrams -= requiredWater;
            
            SaveCurrentState();
        }
    }
}