using System;
using System.Collections;
using UnityEngine;

namespace CoffeeMaker
{
    public class CoffeeBeansContainer : CoffeeMachineComponent
    {
        const float SECONDS_PER_GRAM = .1f;
        
        float beansGrams = 100f;
        
        public override string Name => "Coffee beans container";
        public override float CurrentAmount => beansGrams;
        public override float MaxAmount => config.BeansContainerCapacity;

        public override void Initialize(CoffeeMachineConfig config)
        {
            base.Initialize(config);

            if (HasSavedValue(out var value))
            {
                beansGrams = value;
            }
        }

        public override void Service()
        {
            beansGrams = MaxAmount;
        }

        public override bool CanMakeRecipe(CoffeeRecipe recipe, out ValidationResultCode validationResultCode)
        {
            validationResultCode = ValidationResultCode.OK;
            
            var requiredBeansAmount = config.GetGramsForIntensity(recipe.Intensity);

            if (beansGrams < requiredBeansAmount)
            {
                validationResultCode = ValidationResultCode.FillBeansContainer;
                return false;
            }

            return true;
        }

        public override IEnumerator ProcessRecipe(CoffeeRecipe recipe)
        {
            var requiredBeansGrams = config.GetGramsForIntensity(recipe.Intensity);
            
            yield return new WaitForSeconds(requiredBeansGrams * SECONDS_PER_GRAM);

            beansGrams -= requiredBeansGrams;
            
            SaveCurrentState();
        }
    }
}