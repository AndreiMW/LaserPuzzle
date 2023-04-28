/**
 * Created Date: 4/27/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using GameState;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private static GameManager s_instance;
	public static GameManager Instance => s_instance ??= FindObjectOfType<GameManager>();
	
	public readonly GameIdleState GameIdle = new ();
	public readonly GameInProgressState GameInProgress = new ();
	public readonly GameEndState GameEnd = new ();

	private BaseGameState _currentState;
	
	#region Lifecycle

	private void Awake() {
		this._currentState = this.GameIdle;
		
	}

	private void Start() {
		this._currentState.OnStateEnter(this);
	}

	private void Update() {
		this._currentState.OnUpdate(this);
	}
	
	#endregion
	
	#region Public

	/// <summary>
	/// Change the game's state.
	/// </summary>
	/// <param name="state">The state to change to.</param>
	public void ChangeState(BaseGameState state) {
		this._currentState.OnStateExit(this);
		this._currentState = state;
		this._currentState.OnStateEnter(this);
	}
	
	#endregion
}