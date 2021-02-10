using System.Collections.Generic;
using UnityEngine;

namespace CoffeeMaker.UI
{
    public class CoffeeMachineConfigPanel : MonoBehaviour
    {
        [SerializeField] Configs configs;
        [SerializeField] ConfigEditView editViewPrefab;
        [SerializeField] RectTransform container;
        
        CoffeeMachineConfig coffeeMachineConfig;
        List<ConfigEditView> editPanels;
        
        void Awake()
        {
            coffeeMachineConfig = configs.CoffeeMachineConfig;
            
            editPanels = new List<ConfigEditView>{
                Instantiate(editViewPrefab, container).Initialize("Small Water Grams", coffeeMachineConfig.SmallWaterGrams, v => coffeeMachineConfig.SmallWaterGrams = v),
                Instantiate(editViewPrefab, container).Initialize("Medium Water Grams", coffeeMachineConfig.MediumWaterGrams, v => coffeeMachineConfig.MediumWaterGrams = v),
                Instantiate(editViewPrefab, container).Initialize("Large Water Grams", coffeeMachineConfig.LargeWaterGrams, v => coffeeMachineConfig.LargeWaterGrams = v),
                Instantiate(editViewPrefab, container).Initialize("Light Coffee Grams", coffeeMachineConfig.LightCoffeeGrams, v => coffeeMachineConfig.LightCoffeeGrams = v),
                Instantiate(editViewPrefab, container).Initialize("Medium Coffee Grams", coffeeMachineConfig.MediumCoffeeGrams, v => coffeeMachineConfig.MediumCoffeeGrams = v),
                Instantiate(editViewPrefab, container).Initialize("Strong Coffee Grams", coffeeMachineConfig.StrongCoffeeGrams,  v => coffeeMachineConfig.StrongCoffeeGrams = v),
                Instantiate(editViewPrefab, container).Initialize("Beans Water Absorb/g", coffeeMachineConfig.BeansWaterAbsorbPerGram, v => coffeeMachineConfig.BeansWaterAbsorbPerGram = v),
                Instantiate(editViewPrefab, container).Initialize("Water Container Cap./g",coffeeMachineConfig.WaterContainerCapacity, v => coffeeMachineConfig.WaterContainerCapacity = v),
                Instantiate(editViewPrefab, container).Initialize("Beans Container Cap./g", coffeeMachineConfig.BeansContainerCapacity, v => coffeeMachineConfig.BeansContainerCapacity = v),
                Instantiate(editViewPrefab, container).Initialize("Beans Dispenser Cap./g", coffeeMachineConfig.BeansDispenserCapacity, v => coffeeMachineConfig.BeansDispenserCapacity = v),
                Instantiate(editViewPrefab, container).Initialize("Water Drip Cap./g", coffeeMachineConfig.WaterDripCapacity, v => coffeeMachineConfig.WaterDripCapacity = v),
            };
        }
    }
}