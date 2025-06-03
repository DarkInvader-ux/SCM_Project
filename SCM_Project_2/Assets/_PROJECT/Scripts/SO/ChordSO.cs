using System.Collections.Generic;
using UnityEngine;

namespace _PROJECT.Scripts.SO
{
    [CreateAssetMenu(fileName = "ChordSO", menuName = "ScriptableObjects/ChordSO", order = 2)]
    public class ChordSO : ScriptableObject
    {
        public List<GestureSO> GestureSos;
    }
}
