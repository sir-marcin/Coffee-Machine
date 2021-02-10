using UnityEngine;

namespace CoffeeMaker
{
    public class RecipesMemory : MonoBehaviour
    {
        const string RECIPES_KEY = "REC_MEM";

        [SerializeField] RecipesListWrapper recipesList;

        void Awake()
        {
            if (!PlayerPrefs.HasKey(RECIPES_KEY))
            {
                return;
            }

            var json = PlayerPrefs.GetString(RECIPES_KEY);
            recipesList = JsonUtility.FromJson<RecipesListWrapper>(json);
        }

        public void SaveRecipe(CoffeeRecipe recipe)
        {
            
            recipesList.Recipes.Add(recipe);

            var json = JsonUtility.ToJson(recipesList);
            PlayerPrefs.SetString(RECIPES_KEY, json);
        }
    }
}