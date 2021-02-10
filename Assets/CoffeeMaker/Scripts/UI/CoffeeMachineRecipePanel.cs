using UnityEngine;

namespace CoffeeMaker.UI
{
    public class CoffeeMachineRecipePanel : MonoBehaviour
    {
        [SerializeField] AmountSelector intensitySelector;
        [SerializeField] AmountSelector sizeSelector;

        public AmountSelector IntensitySelector => intensitySelector;
        public AmountSelector SizeSelector => sizeSelector;

        public CoffeeRecipe GetCurrentRecipe()
        {
            var intensity = (CoffeeIntensity) intensitySelector.CurrentValue;
            var size = (CoffeeSize) sizeSelector.CurrentValue;

            return new CoffeeRecipe(size, intensity);
        }
    }
}