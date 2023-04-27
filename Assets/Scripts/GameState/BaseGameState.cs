/**
 * Created Date: 4/27/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

namespace GameState {
	public abstract class BaseGameState {
		
		#region Public
		
		/// <summary>
		/// Handle logic when state enters.
		/// </summary>
		/// <param name="manager">The game manager.</param>
		public abstract void OnStateEnter(GameManager manager);
		
		/// <summary>
		/// Handle logic when state exists.
		/// </summary>
		/// <param name="manager">The game manager.</param>
		public abstract void OnStateExit(GameManager manager);
		
		/// <summary>
		/// Handle logic when state updates.
		/// </summary>
		/// <param name="manager">The game manager.</param>
		public abstract void OnUpdate(GameManager manager);
		
		#endregion
		
	}
}