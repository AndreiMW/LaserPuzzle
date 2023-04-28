/**
 * Created Date: 4/28/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using Managers;
using UnityEngine;

namespace Levels {
	public class Level : MonoBehaviour {
		[field: SerializeField]
		private GameObject _levelEndTarget;
		
		[field:SerializeField]
		public LaserManager LaserManager { get; private set; }
		
		[field:SerializeField]
		public MirrorManager MirrorManager { get; private set; }

		#region Public
		
		/// <summary>
		/// Init Level
		/// </summary>
		/// <param name="endLevelColorTarget">The color that the laser should have for the level end target.</param>
		public void Init(Color endLevelColorTarget) {
			Material levelEndTargetMat = this._levelEndTarget.GetComponent<Renderer>().sharedMaterial;
			levelEndTargetMat.color = endLevelColorTarget;
		}
		
		#endregion
		
	}
}