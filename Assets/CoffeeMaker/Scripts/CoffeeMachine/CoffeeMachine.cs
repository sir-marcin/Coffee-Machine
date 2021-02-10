using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoffeeMaker
{
    public class CoffeeMachine : MonoBehaviour
    {
        [SerializeField] Configs configs;

        public static event Action<CoffeeMachine> OnInitialized = c => { };
        public static event Action<CoffeeMachineState> OnStateChanged = s => { };
        public static event Action<Coffee> OnCoffeeReady = c => { };

        static readonly WaitForSeconds turnOnWait = new WaitForSeconds(4f);
        
        CoffeeMachineComponent[] coffeeMachineComponents;
        Coroutine currentProcessCoroutine;
        CoffeeMachineState state = CoffeeMachineState.Off;
        CoffeeMachineConfig coffeeMachineConfig;
        
        CoffeeMachineState State
        {
            set
            {
                state = value;
                OnStateChanged.Invoke(state);
            }
        }
        bool CoffeeMakingInProgress => state == CoffeeMachineState.MakingCoffee;
        public IEnumerable<CoffeeMachineComponent> CoffeeMachineComponents => coffeeMachineComponents;

        void Awake()
        {
            coffeeMachineConfig = configs.CoffeeMachineConfig;
            coffeeMachineComponents = GetComponents<CoffeeMachineComponent>();

            foreach (var component in coffeeMachineComponents)
            {
                component.Initialize(coffeeMachineConfig);
            }
        }

        void Start()
        {
            OnInitialized.Invoke(this);
        }

        public void TryMakeCoffee(CoffeeRecipe recipe)
        {
            if (CoffeeMakingInProgress)
            {
                MessageMediator.SendMessage("Coffee already in progress", MessageType.Error);
                return;
            }
            
            if (!ValidateComponents(recipe))
            {
                return;
            }
            
            State = CoffeeMachineState.MakingCoffee;

            currentProcessCoroutine = StartCoroutine(ProcessCoffee(recipe));
        }

        public void Toggle()
        {
            switch (state)
            {
                case CoffeeMachineState.Off:
                    currentProcessCoroutine = StartCoroutine(TurnOn());
                    return;
                case CoffeeMachineState.ReadyToMakeCoffee:
                    TurnOff();
                    return;
            }
        }

        IEnumerator TurnOn()
        {
            State = CoffeeMachineState.TurningOn;
            MessageMediator.SendMessage("HEATING UP", MessageType.Info);
            
            yield return turnOnWait;
            
            State = CoffeeMachineState.ReadyToMakeCoffee;
            MessageMediator.SendMessage("READY", MessageType.Info);

            currentProcessCoroutine = null;
        }

        void TurnOff()
        {
            State = CoffeeMachineState.Off;
            
            MessageMediator.Clear(MessageType.Info);
            MessageMediator.Clear(MessageType.Error);
        }
        
        bool ValidateComponents(CoffeeRecipe recipe)
        {
            foreach (var component in coffeeMachineComponents)
            {
                if (component.CanMakeRecipe(recipe, out var validationResultCode))
                {
                    continue;
                }
                
                if (validationResultCode != ValidationResultCode.OK)
                {
                    MessageMediator.SendMessage(validationResultCode.ToDisplayName(), MessageType.Error);
                }
                    
                return false;
            }

            return true;
        }

        IEnumerator ProcessCoffee(CoffeeRecipe recipe)
        {
            var isHotWater = recipe.IsHotWater;
            var message = isHotWater ? "Hot water" : "Making coffee";
            
            for (var i = 0; i < coffeeMachineComponents.Length; i++)
            {
                MessageMediator.SendMessage($"{message} ({(float)(i + 1) / coffeeMachineComponents.Length:P})", MessageType.Info);
                
                var component = coffeeMachineComponents[i];
                yield return component.ProcessRecipe(recipe);
            }

            var coffee = new Coffee(recipe.Size, recipe.Intensity);
            
            OnCoffeeReady.Invoke(coffee);
            
            currentProcessCoroutine = null;

            message = isHotWater 
                ? $"Hot water ready: {coffeeMachineConfig.GetGramsForSize(coffee.Size)}ml"
                : $"Coffee ready: {coffeeMachineConfig.GetGramsForSize(coffee.Size)}ml ({coffee.Intensity})";
            
            MessageMediator.SendMessage(message, MessageType.Info);
            
            ValidateComponents(CoffeeRecipe.SmallestAndLightest);

            State = CoffeeMachineState.ReadyToMakeCoffee;
        }
    }
}
