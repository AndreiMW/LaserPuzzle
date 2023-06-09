/**
 * Created Date: 4/27/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using Managers;
using UnityEngine;

namespace GameState {
	public class GameInProgressState : BaseGameState {
		/// <inheritdoc />
		public override void OnStateEnter(GameManager manager) {
			LevelManager.Instance.ChangeLasersState(true);
			LevelManager.Instance.ChangeMirrorInteractionState(true);
			UIManager.Instance.HideCurrentLevelText();
		}
		
		/// <inheritdoc />
		public override void OnStateExit(GameManager manager) { }
		
		/// <inheritdoc />
		public override void OnUpdate(GameManager manager) { }
	}
}
