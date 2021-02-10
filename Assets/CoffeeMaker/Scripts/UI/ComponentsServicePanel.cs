using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoffeeMaker.UI
{
    public class ComponentsServicePanel : MonoBehaviour
    {
        [SerializeField] ComponentServiceButton buttonPrefab;
        [SerializeField] RectTransform buttonsContainer;

        List<ComponentServiceButton> serviceButtons = new List<ComponentServiceButton>();

        public IEnumerable<ComponentServiceButton> ServiceButtons => serviceButtons;
        
        void Awake()
        {
            CoffeeMachine.OnInitialized += OnCoffeeMachineInitialized;
            CoffeeMachine.OnStateChanged += OnCoffeeMachineStateChanged;
        }

        void OnDestroy()
        {
            CoffeeMachine.OnInitialized -= OnCoffeeMachineInitialized;
            CoffeeMachine.OnStateChanged += OnCoffeeMachineStateChanged;
        }

        void OnCoffeeMachineStateChanged(CoffeeMachineState state)
        {
            foreach (var button in serviceButtons)
            {
                button.Refresh();
            }
        }

        void OnCoffeeMachineInitialized(CoffeeMachine coffeeMachine)
        {
            foreach (var coffeeMachineComponent in coffeeMachine.CoffeeMachineComponents)
            {
                var button = Instantiate(buttonPrefab, buttonsContainer);
                button.Initialize(coffeeMachineComponent);
                
                serviceButtons.Add(button);
            }
        }
    }
}