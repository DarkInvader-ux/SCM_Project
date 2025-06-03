using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "targetGesture",menuName ="ScriptableObjects/GestureSO", order = 1)]
public class GestureSO : ScriptableObject
{
    [FormerlySerializedAs("GestureName")] [SerializeField]
    private string gestureName;
    [FormerlySerializedAs("Icon")] [SerializeField]
    private Sprite icon;
    
    public Sprite Icon { get => icon; set => icon = value; }
    public string GestureName { get => gestureName; set => gestureName = value; }
}
