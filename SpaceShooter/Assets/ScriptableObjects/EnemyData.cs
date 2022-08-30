using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	[CreateAssetMenu(
		fileName = "EnemyData",
		menuName = "ScriptableObjects/EnemyData",
		order = 1
	)]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] public int HealthPoints { get; private set; }
    
}
