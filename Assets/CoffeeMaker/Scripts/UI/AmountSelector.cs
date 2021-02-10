using UnityEngine;
using UnityEngine.UI;

namespace CoffeeMaker.UI
{
    public class AmountSelector : MonoBehaviour
    {
        [SerializeField] bool allowZeroAmount;
        
        [Header("Refs")]
        [SerializeField] Button buttonMore;
        [SerializeField] Button buttonLess;
        [SerializeField] AmountIndicator[] indicators;

        const int MAX_VALUE = 3;
        
        int minValue;
        int currentValue;

        public int CurrentValue => currentValue;

        void Awake()
        {
            buttonMore.onClick.AddListener(IncreaseAmount);
            buttonLess.onClick.AddListener(DecreaseAmount);

            currentValue = minValue = allowZeroAmount ? 0 : 1;
            UpdateIndicators();
        }
        
        public void IncreaseAmount()
        {
            if (currentValue + 1 > MAX_VALUE)
            {
                return;
            }

            currentValue++;
            UpdateIndicators();
        }
        
        public void DecreaseAmount()
        {
            if (currentValue - 1 < minValue)
            {
                return;
            }

            currentValue--;
            UpdateIndicators();
        }

        void UpdateIndicators()
        {
            for (int i = 0; i < MAX_VALUE; i++)
            {
                indicators[i].SetHighlighted(i < currentValue);
            }
        }
    }
}