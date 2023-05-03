/**
 * Created Date: 4/27/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using GameState;
using Managers;
using UnityEngine;

public class GameIdleState : BaseGameState {
	/// <inheritdoc />
	public override void OnStateEnter(GameManager manager) {
		LevelManager.Instance.LoadLevel();	
		UIManager.Instance.ShowStartView();
	}

	/// <inheritdoc />
	public override void OnStateExit(GameManager manager) {
	}

	/// <inheritdoc />
	public override void OnUpdate(GameManager manager) {
	}
}