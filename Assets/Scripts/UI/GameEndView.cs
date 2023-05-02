/**
 * Created Date: 5/2/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class GameEndView : BaseView {
		[SerializeField]
		private Button _continueButton;

		private float _showHideDuration = 0.4f;

		#region Lifecycle
		
		private void Awake() {
			this._continueButton.onClick.AddListener(this.HandleContinueButton);
		}
		
		#endregion
		
		#region Public

		/// <summary>
		/// Show the game end view.
		/// </summary>
		public void Show() {
			this.FadeIn(this._showHideDuration);
		}

		/// <summary>
		/// Hide the game end view.
		/// </summary>
		public void Hide() {
			this.FadeOut(this._showHideDuration);
		}
		
		#endregion
		
		#region Private

		private void HandleContinueButton() {
			this.Hide();
			GameManager.Instance.ChangeState(GameManager.Instance.GameIdle);
		}
		
		#endregion
	}
}