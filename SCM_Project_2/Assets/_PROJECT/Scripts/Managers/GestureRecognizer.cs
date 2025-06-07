using System;
using _PROJECT.Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

namespace _PROJECT.Scripts.Managers
{
    public class GestureRecognizer : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private UDPReceiver receiver;
        [SerializeField] private Image recognitionBar;

        [Header("Settings")]
        [SerializeField] private bool isActive;
        [SerializeField] private bool catchingGesture;
    
        private float currentFillTime = 0f;
        
        private bool _hasAudioStarted = false;

        private void OnEnable()
        {
            EventManager.ONLevelCompleted += ResetBar;
        }

        private void OnDisable()
        {
            EventManager.ONLevelCompleted -= ResetBar;
        }

        private void Start()
        {
            if (levelManager == null)
            {
                Debug.LogError("Level Manager is null");
            }
            if (recognitionBar == null)
            {
                Debug.LogError("Recognition Bar is not set");
            }

            ResetBar();
        }

        private void Update()
        {
            if (!isActive) return;

            var currentGestureStr = receiver.GetGesture();
            var targetGesture = levelManager.GetGesture();

            // If the gesture matches, start filling the bar
            if (string.Equals(currentGestureStr, targetGesture.GestureName, StringComparison.CurrentCultureIgnoreCase))
            {
                if (!_hasAudioStarted)
                {
                    AudioManager.Instance.SetAudio(targetGesture.AudioClip);
                    _hasAudioStarted = true;
                }
                catchingGesture = true;
                FillBar(levelManager.GetFillTime());
            }
            else
            {
                if (catchingGesture)
                {
                    // Gesture failed, reset the bar
                    ResetBar();
                    catchingGesture = false;
                    _hasAudioStarted = false;
                    Debug.LogWarning("Gesture catching failed");
                    AudioManager.Instance.SetAudio(null);
                }
            }
        }

        private void FillBar(float fillDuration)
        {
            if (catchingGesture)
            {
                // Time passed while holding the gesture
                currentFillTime += Time.deltaTime;
            
                // Update the fill bar based on the time passed
                recognitionBar.fillAmount = currentFillTime / fillDuration;

                // If the fill time exceeds the fill duration, stop the gesture process and update the potion and bar
                if (currentFillTime >= fillDuration)
                {
                    recognitionBar.fillAmount = 1f; // Make sure the bar is completely filled
                    catchingGesture = false; // Stop catching the gesture
                    _hasAudioStarted = false;
                    EventManager.OnGestureCompleted();
                    ResetBar();
                    Debug.Log("Gesture completed successfully!");
                }
            }
        }

        private void ResetBar()
        {
            recognitionBar.fillAmount = 0f; // Reset the bar to empty
            currentFillTime = 0f; // Reset the timer
        }
    }
}
