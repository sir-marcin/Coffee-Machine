using System;
using JetBrains.Annotations;
using UnityEngine;

namespace CoffeeMaker
{
    public enum MessageType
    {
        Info = 0,
        Error = 1
    }
    
    public static class MessageMediator
    {
        public static event Action<string, MessageType> OnMessageReceived = (s, m) => { };

        public static void SendMessage(string message, MessageType type)
        {
            OnMessageReceived.Invoke(message, type);
        }

        public static void Clear(MessageType type)
        {
            SendMessage(string.Empty, type);
        }
    }
}