using System;
using System.Collections;
using UnityEngine;

namespace CoffeeMaker
{
    public abstract class CoffeeMachineComponent : MonoBehaviour
    {
        protected CoffeeMachineConfig config;
        
        public abstract string Name { get; }
        public abstract float CurrentAmount { get; }
        public abstract float MaxAmount { get; }
        
        public virtual void Initialize(CoffeeMachineConfig config)
        {
            this.config = config;
        }

        protected void SaveCurrentState()
        {
            PlayerPrefs.SetFloat(GetType().ToString(), CurrentAmount);
        }

        void OnDestroy()
        {
            SaveCurrentState();
        }

        protected bool HasSavedValue(out float value)
        {
            if (PlayerPrefs.HasKey(GetType().ToString()))
            {
                value = PlayerPrefs.GetFloat(GetType().ToString());
                return true;
            }

            value = 0;
            return false;
        }
        
        public abstract void Service();
        public abstract bool CanMakeRecipe(CoffeeRecipe recipe, out ValidationResultCode validationResultCode);
        public abstract IEnumerator ProcessRecipe(CoffeeRecipe recipe);
    }
}