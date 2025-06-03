using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChordSO", menuName = "ScriptableObjects/ChordSO", order = 2)]
public class ChordSO : ScriptableObject
{
    public List<GestureSO> GestureSos;
}
