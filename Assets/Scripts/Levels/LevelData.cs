/**
 * Created Date: 4/28/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using UnityEngine;

namespace Levels {
	[CreateAssetMenu(fileName = "Level000", menuName = "Level/CreateLevelData")]
	public class LevelData : ScriptableObject {
 
		[field : SerializeField] 
		public Level LevelPrefab {get; private set;} 
		
		[field:SerializeField]
		public Color32 EndLevelColor { get; private set; }
	}
}