using System.Collections.Generic;
using _PROJECT.Scripts.SO;
using UnityEngine;

namespace _PROJECT.Scripts.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [System.Serializable]
        public class Level
        {
            public ChordSO Chord;
            public float requiredHoldTime;
            public int currentIngredient;
        }

        [SerializeField] private List<Level> levels = new();
        [SerializeField] private int currentLevelIndex;
        //[SerializeField] private PotionController currentPotionController;
    

        private void Start()
        {
            currentLevelIndex = 0;
            EventManager.OnLevelStart();
            StartGame();
        }

        private void StartGame()
        {
            var currentLevel = GetCurrentLevel();
            if (currentLevel != null && currentLevel.Chord != null)
            {
                //GameObject potionInstance = Instantiate(currentLevel.Chord.potionPrefab, Vector3.zero, Quaternion.identity);
                //currentPotionController = potionInstance.GetComponent<PotionController>();
            }
            else
            {
                Debug.LogError("No potion prefab found for the current level.");
            }
        }

        public ChordSO GetCurrentChord()
        {
            return levels[currentLevelIndex].Chord;
        }

        private void OnEnable()
        {
            EventManager.ONGestureCompleted += OnIngredientComplete;
            EventManager.ONLevelCompleted += OnLevelCompleted;
        }

        private void OnLevelCompleted()
        {
            var currentLevel = GetCurrentLevel();
            currentLevel.currentIngredient = 0;
        }

        private void OnDisable()
        {
            EventManager.ONGestureCompleted -= OnIngredientComplete;
        }

        public Level GetCurrentLevel()
        {
            if (currentLevelIndex < 0 || currentLevelIndex >= levels.Count)
            {
                Debug.LogError("Invalid level index.");
                return null;
            }
            return levels[currentLevelIndex];
        }

  

        private void OnIngredientComplete()
        {
            var level = GetCurrentLevel();
            if (level == null) return;
        
            if (level.Chord.GestureSos.Count == level.currentIngredient + 1)
            {
                currentLevelIndex++;
                EventManager.OnLevelCompleted();
                Debug.LogError("level completed");
            }
            else
            {
                ParticleManager.Instance.PlayCorrectIngredientEffect(Vector3.zero);
                level.currentIngredient++;
            }
        }

        public float GetFillTime()
        {
            return GetCurrentLevel()?.requiredHoldTime ?? 0f;
        }

        public GestureSO GetGesture()
        {
            var chord = GetCurrentChord();
            var currentIngredient = GetCurrentLevel().currentIngredient;
            if (chord == null || GetCurrentLevel() == null)
                Debug.LogError("Something went wrong");
            return chord.GestureSos[currentIngredient];
        }
    }
}
