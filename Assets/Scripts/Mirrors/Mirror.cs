/**
 * Created Date: 4/28/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using UnityEngine;

namespace Mirrors {
	public class Mirror : MonoBehaviour {
		private Outline _outline;

		private bool _wasPointerDown = false;
		private bool _shouldInteract = false;

		#region Lifecycle
		
		private void Awake() {
			this._outline = this.GetComponent<Outline>();
		}
		
		#endregion
		
		#region Mouse Interactions

		private void OnMouseDrag() {
			if (!this._shouldInteract) {
				return;
			}
			float xAxis = Input.GetAxis("Mouse X") * 5;
			this.transform.Rotate(Vector3.down, xAxis);
			this._wasPointerDown = true;
		}

		private void OnMouseUp() {
			if (!this._shouldInteract) {
				return;
			}
			this._wasPointerDown = false;
			if (this._outline.OutlineWidth > 0) {
				this._outline.OutlineWidth = 0f;
			}
		}

		private void OnMouseEnter() {
			if (!this._shouldInteract) {
				return;
			}
			this._outline.OutlineWidth = 10f;
		}

		private void OnMouseExit() {
			if (this._wasPointerDown || !this._shouldInteract) {
				return;
			}
			this._outline.OutlineWidth = 0f;
		}
		
		#endregion
		
		#region Public

		/// <summary>
		/// Change mirrors interaction state.
		/// </summary>
		/// <param name="state">Interaction (drag) enabled/disabled.</param>
		public void ChangeInteractionState(bool state) {
			this._shouldInteract = state;
		}
		
		#endregion
	}
}