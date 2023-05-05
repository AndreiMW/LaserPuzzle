/**
 * Created Date: 5/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using Managers;

namespace UI.CurrentLevelMVP {
	public class CurrentLevelModel {
		/// <summary>
		/// The current level index.
		/// </summary>
		public int CurrentLevel => LevelManager.Instance.CurrentLevelIndex + 1;
	}
}