using System;
using TMPro;
using UnityEngine;

namespace CoffeeMaker.UI
{
    public class ConfigEditView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI label;
        [SerializeField] TMP_InputField inputField;

        public Action<float> OnValueChanged = v => { };
        
        public ConfigEditView Initialize(string valueName, float initialValue, Action<float> onValueChanged)
        {
            this.OnValueChanged += onValueChanged;
            label.text = valueName;

            inputField.text = initialValue.ToString();
            inputField.onValueChanged.AddListener(OnInputFieldValueChanged);

            return this;
        }

        void OnInputFieldValueChanged(string value)
        {
            if (!float.TryParse(value, out var number))
            {
                return;
            }
            
            OnValueChanged.Invoke(number);
        }
    }
}