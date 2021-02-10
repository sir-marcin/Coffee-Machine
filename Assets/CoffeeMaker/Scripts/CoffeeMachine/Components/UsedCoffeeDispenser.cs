using System.Collections;
using UnityEngine;

namespace CoffeeMaker
{
    public class UsedCoffeeDispenser : CoffeeMachineComponent
    {
        static readonly WaitForSeconds processWait = new WaitForSeconds(1f);
        
        float currentUsedCoffeeGrams;
        
        public override string Name => "Used coffee dispenser";
        public override float CurrentAmount => currentUsedCoffeeGrams;
        public override float MaxAmount => config.BeansDispenserCapacity;

        public override void Initialize(CoffeeMachineConfig config)
        {
            base.Initialize(config);

            if (HasSavedValue(out var value))
            {
                currentUsedCoffeeGrams = value;
            }
        }

        public override void Service()
        {
            currentUsedCoffeeGrams = 0f;
        }

        public override bool CanMakeRecipe(CoffeeRecipe recipe, out ValidationResultCode validationResultCode)
        {
            validationResultCode = ValidationResultCode.OK;

            var recipeBeans = config.GetGramsForIntensity(recipe.Intensity);
            var wetBeansWaterGrams = recipeBeans * config.BeansWaterAbsorbPerGram;
            
            bool limitReached = currentUsedCoffeeGrams + recipeBeans + wetBeansWaterGrams > MaxAmount;

            if (limitReached)
            {
                validationResultCode = ValidationResultCode.UsedCoffeeDispenserFull;
            }

            return !limitReached;
        }

        public override IEnumerator ProcessRecipe(CoffeeRecipe recipe)
        {
            yield return processWait;
            
            var recipeBeans = config.GetGramsForIntensity(recipe.Intensity);
            var wetBeansWaterGrams = recipeBeans * config.BeansWaterAbsorbPerGram;
            
            currentUsedCoffeeGrams += recipeBeans + wetBeansWaterGrams;
            
            SaveCurrentState();
        }
    }
}