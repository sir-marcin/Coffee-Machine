using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CoffeeMaker.UI
{
    public class ComponentServiceButton : MonoBehaviour
    {
        [SerializeField] Button button;
        [SerializeField] TextMeshProUGUI labelName;
        [SerializeField] TextMeshProUGUI labelAmount;
        
        CoffeeMachineComponent coffeeMachineComponent;

        public CoffeeMachineComponent CoffeeMachineComponent => coffeeMachineComponent;

        void Awake()
        {
            button.onClick.AddListener(OnButtonClick);
        }

        void OnDestroy()
        {
            button.onClick.RemoveListener(OnButtonClick);
        }

        void OnButtonClick()
        {
            MessageMediator.Clear(MessageType.Error);
            coffeeMachineComponent?.Service();
            
            Refresh();
        }

        public void Initialize(CoffeeMachineComponent coffeeMachineComponent)
        {
            this.coffeeMachineComponent = coffeeMachineComponent;
            labelName.text = coffeeMachineComponent.Name;
            
            Refresh();
        }

        public void Refresh()
        {
            labelAmount.text = $"{coffeeMachineComponent.CurrentAmount}/{coffeeMachineComponent.MaxAmount} (g)";
        }
    }
}