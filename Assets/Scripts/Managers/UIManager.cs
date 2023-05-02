/**
 * Created Date: 4/28/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using System;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Managers {
	public class UIManager : MonoBehaviour {
		private static UIManager s_instance;
		public static UIManager Instance => s_instance ??= FindObjectOfType<UIManager>();
		
		[SerializeField]
		private StartView _startView;
		
		[SerializeField]
		private GameEndView _gameEndView;

		#region Lifecycle

		private void OnDestroy() {
			s_instance = null;
		}

		#endregion
		
		#region Public

		/// <summary>
		/// Show the start view.
		/// </summary>
		public void ShowStartView() {
			this._startView.Show();
		}
		
		/// <summary>
		/// Hide the start view.
		/// </summary>
		public void HideStartView() {
			this._startView.Hide();
		}
		
		/// <summary>
		/// Show the game end view.
		/// </summary>
		public void ShowGameEndView() {
			this._gameEndView.Show();
		}
		
		/// <summary>
		/// Hide the game end view.
		/// </summary>
		public void HideGameEndView() {
			this._gameEndView.Hide();
		}

		#endregion
	}
}