using System;
using System.Collections.Generic;
using UnityEngine;

namespace CoffeeMaker.UI
{
    public class ComponentStatusPanel : MonoBehaviour
    {
        [SerializeField] ComponentStatus componentStatusPrefab;
        [SerializeField] RectTransform container;

        List<ComponentStatus> componentStatusViews = new List<ComponentStatus>();
        
        void Awake()
        {
            CoffeeMachine.OnInitialized += OnCoffeeMachineInitialized;
            CoffeeMachine.OnStateChanged += OnCoffeeMachineStateChanged;
        }

        void OnDestroy()
        {
            CoffeeMachine.OnInitialized -= OnCoffeeMachineInitialized;
            CoffeeMachine.OnStateChanged -= OnCoffeeMachineStateChanged;
        }

        void OnCoffeeMachineStateChanged(CoffeeMachineState state)
        {
            if (state != CoffeeMachineState.ReadyToMakeCoffee)
            {
                return;
            }
            
            foreach (var status in componentStatusViews)
            {
                status.Refresh();
            }
        }

        void OnCoffeeMachineInitialized(CoffeeMachine coffeeMachine)
        {
            foreach (var machineComponent in coffeeMachine.CoffeeMachineComponents)
            {
                var status = Instantiate(componentStatusPrefab, container);
                status.Initialize(machineComponent);
                
                componentStatusViews.Add(status);
            }
        }
    }
}