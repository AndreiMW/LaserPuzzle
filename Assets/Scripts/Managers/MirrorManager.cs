/**
 * Created Date: 4/28/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using Mirrors;

using UnityEngine;

namespace Managers {
	public class MirrorManager : MonoBehaviour {
		[SerializeField]
		private Mirror[] _mirrors;

		#region Public

		/// <summary>
		/// Change mirrors interaction state.
		/// </summary>
		/// <param name="state">Interaction (drag) enabled/disabled.</param>
		public void ChangeMirrorsInteractionState(bool state) {
			foreach (Mirror mirror in this._mirrors) {
				mirror.ChangeInteractionState(state);
			}
		}
		
		#endregion
	}
}