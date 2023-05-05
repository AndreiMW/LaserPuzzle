/**
 * Created Date: 4/28/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using UnityEngine;

using UI;
using UI.CurrentLevelMVP;

namespace Managers {
	public class UIManager : MonoBehaviour {
		private static UIManager s_instance;
		public static UIManager Instance => s_instance ??= FindObjectOfType<UIManager>();
		
		[SerializeField]
		private StartView _startView;
		
		[SerializeField]
		private GameEndView _gameEndView;

		[SerializeField]
		private CurrentLevelView _currentLevelView;
		private CurrentLevelPresenter _currentLevelPresenter;
		private CurrentLevelModel _currentLevelModel;

		#region Lifecycle

		private void Awake() {
			this._currentLevelModel = new CurrentLevelModel();
			this._currentLevelPresenter = new CurrentLevelPresenter(this._currentLevelModel, this._currentLevelView);
		}

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

		/// <summary>
		/// Show the current level view.
		/// </summary>
		public void ShowCurrentLevelText() {
			this._currentLevelPresenter.UpdateLevelText();
			
			this._currentLevelView.Show();
		}

		/// <summary>
		/// Hide the current level view.
		/// </summary>
		public void HideCurrentLevelText() {
			this._currentLevelView.Hide();
		}
		
		

		#endregion
	}
}