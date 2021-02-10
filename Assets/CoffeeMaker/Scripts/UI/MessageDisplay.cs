using System;
using TMPro;
using UnityEngine;

namespace CoffeeMaker.UI
{
    public class MessageDisplay : MonoBehaviour
    {
        [SerializeField] Color colorDefault = Color.white;
        [SerializeField] Color colorError = Color.red;
        
        [Header("Refs")]
        [SerializeField] TextMeshProUGUI textComponent;

        void Awake()
        {
            MessageMediator.OnMessageReceived += OnMessageReceived;
        }

        void OnDestroy()
        {
            MessageMediator.OnMessageReceived -= OnMessageReceived;
        }

        void OnMessageReceived(string message, MessageType type)
        {
            textComponent.text = message;
            textComponent.color = type == MessageType.Error ? colorError : colorDefault;
        }
    }
}