using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _PROJECT.Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] private Image gestureImage;
        [SerializeField] private TextMeshProUGUI txtPotionName;
        [SerializeField] private LevelManager levelManager; 

        private void OnEnable()
        {
            EventManager.ONGestureStarted += UpdatePanel;
            EventManager.ONLevelStart += UpdatePanel;
            EventManager.ONGestureCompleted += UpdatePanel;

        }
        private void OnDisable()
        {
            EventManager.ONGestureStarted -= UpdatePanel;
            EventManager.ONLevelStart -= UpdatePanel;
            EventManager.ONGestureCompleted -= UpdatePanel;

        }
        private async void UpdatePanel()
        {
            // await Task.Delay(50);
            // var ingredient = levelManager.GetIngredient();
            // txtPotionName.SetText(ingredient.IngredientName);
            // gestureImage.sprite = ingredient.İngredientImage;
        }
    }
}
