using UnityEngine;
using UnityEngine.UI;

namespace CoffeeMaker.UI
{
    public class AmountIndicator : MonoBehaviour
    {
        [SerializeField] Image image;
        [SerializeField] Color colorActive = Color.white;
        [SerializeField] Color colorInactive = Color.black;

        public void SetHighlighted(bool isHighlighted)
        {
            image.color = isHighlighted ? colorActive : colorInactive;
        }
    }
}