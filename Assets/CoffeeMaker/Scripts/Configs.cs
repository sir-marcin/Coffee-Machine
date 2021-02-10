using System;
using UnityEngine;

namespace CoffeeMaker
{
    [CreateAssetMenu(fileName = "Configs", menuName = "Coffee/Configs")]
    public class Configs : ScriptableObject
    {
        [SerializeField] CoffeeMachineConfig coffeeMachineConfig;

        public CoffeeMachineConfig CoffeeMachineConfig => coffeeMachineConfig;

    }
}