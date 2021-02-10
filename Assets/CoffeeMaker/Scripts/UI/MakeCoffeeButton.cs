using UnityEngine;
using UnityEngine.UI;

namespace CoffeeMaker.UI
{
    public class MakeCoffeeButton : MonoBehaviour
    {
        [SerializeField] Button button;
        [SerializeField] CoffeeMachineRecipePanel recipePanel;

        CoffeeMachine coffeeMachine;

        void Awake()
        {
            if (button == null)
            {
                Debug.LogError($"No Button attached to script on {gameObject.name}");
                return;
            }
            
            CoffeeMachine.OnInitialized += OnCoffeeMachineInitialized;
        }

        void OnDestroy()
        {
            CoffeeMachine.OnInitialized -= OnCoffeeMachineInitialized;
            button.onClick.RemoveListener(OnButtonClick);
        }

        void OnCoffeeMachineInitialized(CoffeeMachine coffeeMachine)
        {
            this.coffeeMachine = coffeeMachine;
            button.onClick.AddListener(OnButtonClick);
        }

        void OnButtonClick()
        {
            coffeeMachine.TryMakeCoffee(recipePanel.GetCurrentRecipe());
        }
    }
}