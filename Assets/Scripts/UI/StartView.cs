/**
 * Created Date: 5/2/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class StartView : BaseView {
		[SerializeField]
		private Button _startButton;

		private float _showHideDuration = 0.4f;

		#region Lifecycle
		
		private void Awake() {
			this._startButton.onClick.AddListener(this.HandleStartButton);
		}
		
		#endregion
		
		#region Public

		/// <summary>
		/// Show the start view.
		/// </summary>
		public void Show() {
			this.FadeIn(this._showHideDuration);
		}

		/// <summary>
		/// Hide the start view.
		/// </summary>
		public void Hide() {
			this.FadeOut(this._showHideDuration);
		}
		
		#endregion
		
		#region Private

		private void HandleStartButton() {
			this.Hide();
			GameManager.Instance.ChangeState(GameManager.Instance.GameInProgress);
		}
		
		#endregion
	}
}