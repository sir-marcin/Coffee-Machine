using TMPro;
using UnityEngine;

namespace CoffeeMaker.UI
{
    public class ComponentStatus : MonoBehaviour
    {
        [SerializeField] CoffeeMachineComponent coffeeMachineComponent;
        [SerializeField] TextMeshProUGUI label;

        public void Initialize(CoffeeMachineComponent coffeeMachineComponent)
        {
            this.coffeeMachineComponent = coffeeMachineComponent;
            Refresh();
        }
        
        public void Refresh()
        {
            label.text = $"{coffeeMachineComponent.CurrentAmount}g/{coffeeMachineComponent.MaxAmount}g";
        }
    }
}