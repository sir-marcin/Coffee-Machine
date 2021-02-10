using System.Collections;
using UnityEngine;

namespace CoffeeMaker
{
    public class WaterDripTray : CoffeeMachineComponent
    {
        const float WATER_DRIP_PER_RECIPE_GRAM = .1f;

        float currentWaterGrams;

        public override string Name => "Water drip tray";
        public override float CurrentAmount => currentWaterGrams;
        public override float MaxAmount => config.WaterDripCapacity;

        public override void Initialize(CoffeeMachineConfig config)
        {
            base.Initialize(config);

            if (HasSavedValue(out var value))
            {
                currentWaterGrams = value;
            }
        }

        public override void Service()
        {
            currentWaterGrams = 0f;
        }

        public override bool CanMakeRecipe(CoffeeRecipe recipe, out ValidationResultCode validationResultCode)
        {
            validationResultCode = ValidationResultCode.OK;

            bool limitReached = currentWaterGrams + config.GetGramsForSize(recipe.Size) * WATER_DRIP_PER_RECIPE_GRAM >
                                MaxAmount;

            if (limitReached)
            {
                validationResultCode = ValidationResultCode.DripTrayFull;
            }

            return !limitReached;
        }

        public override IEnumerator ProcessRecipe(CoffeeRecipe recipe)
        {
            yield return null;
            
            currentWaterGrams += config.GetGramsForSize(recipe.Size) * WATER_DRIP_PER_RECIPE_GRAM;
            
            SaveCurrentState();
        }
    }
}