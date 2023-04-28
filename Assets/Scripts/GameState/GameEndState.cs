/**
 * Created Date: 4/27/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using GameState;
using Managers;
using UnityEngine;

public class GameEndState : BaseGameState {
	/// <inheritdoc />
	public override void OnStateEnter(GameManager manager) {
		LevelManager.Instance.ChangeLasersState(false);
		LevelManager.Instance.ChangeMirrorInteractionState(false);
		LevelManager.Instance.LevelEnd();
	}

	/// <inheritdoc />
	public override void OnStateExit(GameManager manager) {
		
	}

	/// <inheritdoc />
	public override void OnUpdate(GameManager manager) {
		if (Input.GetKeyDown(KeyCode.Space)) {
			manager.ChangeState(manager.GameIdle);
		}
	}
}