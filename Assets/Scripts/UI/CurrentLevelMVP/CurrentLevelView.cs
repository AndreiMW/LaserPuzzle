/**
 * Created Date: 5/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using TMPro;
using UnityEngine;

namespace UI.CurrentLevelMVP {
	public class CurrentLevelView : BaseView {
		[SerializeField]
		private TMP_Text _currentLevelText;

		private float _fadeDuration = 0.4f;
		
		#region Public

		/// <summary>
		/// Update the current level text.
		/// </summary>
		/// <param name="currentLevel">The current level.</param>
		public void UpdateLevelText(int currentLevel) {
			this._currentLevelText.SetText($"Level {currentLevel}");
		}

		/// <summary>
		/// Show the current level view.
		/// </summary>
		public void Show() {
			this.FadeIn(this._fadeDuration);
		}

		/// <summary>
		/// Hide the current level view.
		/// </summary>
		public void Hide() {
			this.FadeOut(this._fadeDuration);
		}
		
		#endregion
	}
}