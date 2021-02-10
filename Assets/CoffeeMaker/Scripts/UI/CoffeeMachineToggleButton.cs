using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CoffeeMaker.UI
{
    public class CoffeeMachineToggleButton : MonoBehaviour
    {
        [SerializeField] Button button;
        [SerializeField] TextMeshProUGUI label;
        
        CoffeeMachine coffeeMachine;
        
        void Awake()
        {
            CoffeeMachine.OnInitialized += OnCoffeeMachineInitialized;
            CoffeeMachine.OnStateChanged += OnCoffeeMachineToggled;
            button.onClick.AddListener(OnButtonClick);
        }

        void OnDestroy()
        {
            CoffeeMachine.OnInitialized -= OnCoffeeMachineInitialized;
            CoffeeMachine.OnStateChanged -= OnCoffeeMachineToggled;
        }

        void OnCoffeeMachineToggled(CoffeeMachineState state)
        {
            label.text = state == CoffeeMachineState.Off ? "OFF" : "ON";
        }

        void OnCoffeeMachineInitialized(CoffeeMachine coffeeMachine)
        {
            this.coffeeMachine = coffeeMachine;
        }

        void OnButtonClick()
        {
            coffeeMachine.Toggle();
        }
    }
}