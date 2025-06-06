using UnityEngine;
using UnityEngine.Serialization;

namespace _PROJECT.Scripts.SO
{
    [CreateAssetMenu(fileName = "targetGesture",menuName ="ScriptableObjects/GestureSO", order = 1)]
    public class GestureSO : ScriptableObject
    {
        [FormerlySerializedAs("GestureName")] [SerializeField]
        private string gestureName;
        [FormerlySerializedAs("Icon")] [SerializeField]
        private Sprite icon;
        
        [SerializeField]
        private AudioClip audioClip;
    
        public Sprite Icon { get => icon; set => icon = value; }
        public string GestureName { get => gestureName; set => gestureName = value; }
        public AudioClip AudioClip { get => audioClip; set => audioClip = value; }
    }
}
