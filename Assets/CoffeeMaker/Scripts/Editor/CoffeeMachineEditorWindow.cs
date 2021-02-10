#if UNITY_EDITOR
using System;
using System.Linq;
using CoffeeMaker.UI;
using UnityEditor;
using UnityEngine;

namespace CoffeeMaker.Editor
{
    public class CoffeeMachineEditorWindow : EditorWindow
    {
        CoffeeMachine CoffeeMachine => FindObjectOfType<CoffeeMachine>();
        CoffeeMachineRecipePanel CoffeeMachineRecipePanel => FindObjectOfType<CoffeeMachineRecipePanel>();
        ComponentsServicePanel ComponentsServicePanel => FindObjectOfType<ComponentsServicePanel>();
        void OnGUI()
        {
            EditorGUILayout.LabelField("Coffee Making");
            
            if (GUILayout.Button("Make Coffee"))
            {
                CoffeeMachine?.TryMakeCoffee(CoffeeRecipe.SmallestAndLightest);
            }

            if (GUILayout.Button("Weaker"))
            {
                CoffeeMachineRecipePanel?.IntensitySelector.DecreaseAmount();
            }
            
            if (GUILayout.Button("Stronger"))
            {
                CoffeeMachineRecipePanel?.IntensitySelector.IncreaseAmount();
            }
            
            if (GUILayout.Button("Smaller"))
            {
                CoffeeMachineRecipePanel?.SizeSelector.DecreaseAmount();
            }
            
            if (GUILayout.Button("Bigger"))
            {
                CoffeeMachineRecipePanel?.SizeSelector.IncreaseAmount();
            }
            
            EditorGUILayout.LabelField("Service");
            
            if (GUILayout.Button("Coffee Beans Container"))
            {
                RefreshCoffeeMachineComponent<CoffeeBeansContainer>();
            }
            
            if (GUILayout.Button("Coffee Dispenser"))
            {
                RefreshCoffeeMachineComponent<UsedCoffeeDispenser>();
            }
            
            if (GUILayout.Button("Water Container"))
            {
                RefreshCoffeeMachineComponent<WaterContainer>();
            }
            
            if (GUILayout.Button("Water Drip Tray"))
            {
                RefreshCoffeeMachineComponent<WaterDripTray>();
            }
        }

        void RefreshCoffeeMachineComponent<T>() where T : CoffeeMachineComponent
        {
            var button = ComponentsServicePanel?
                .ServiceButtons.FirstOrDefault(b => b.CoffeeMachineComponent is T);

            if (button == null)
            {
                return;
            }
            
            button.CoffeeMachineComponent.Service();
            button.Refresh();
        }
        
        [MenuItem("Coffee/Editor")]
        public static void ShowWindow()
        {
            GetWindow<CoffeeMachineEditorWindow>(false, "Coffee Machine", true);
        }
    }
}
#endif