using System;
using DG.Tweening;
using UnityEngine;

namespace CoffeeMaker.UI
{
    public class CoffeeMachinePanelController : MonoBehaviour
    {
        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] float fadeDuration = .5f;
        
        void Awake()
        {
            CoffeeMachine.OnStateChanged += OnCoffeeMachineToggled;
            canvasGroup.alpha = 0f;
        }

        void OnDestroy()
        {
            CoffeeMachine.OnStateChanged -= OnCoffeeMachineToggled;
        }

        void OnCoffeeMachineToggled(CoffeeMachineState state)
        {
            switch (state)
            {
                case CoffeeMachineState.TurningOn:
                    canvasGroup.DOFade(1f, fadeDuration);
                    break;
                case CoffeeMachineState.Off:
                    canvasGroup.DOFade(0f, fadeDuration);
                    break;
            }

            canvasGroup.interactable = state == CoffeeMachineState.ReadyToMakeCoffee;
        }
    }
}