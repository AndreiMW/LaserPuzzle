/**
 * Created Date: 4/28/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using UnityEngine;
using UnityEngine.UI;

namespace Managers {
	public class UIManager : MonoBehaviour {
		[SerializeField]
		private Button _startButton;

		#region Lifecycle

		private void Awake() {
			this._startButton.onClick.AddListener(this.HandleStartButton);
		}

		#endregion
		
		#region Private

		private void HandleStartButton() {
			GameManager.Instance.ChangeState(GameManager.Instance.GameInProgress);
			this.gameObject.SetActive(false);
		}

		#endregion
	}
}