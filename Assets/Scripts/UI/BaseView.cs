/**
 * Created Date: 5/2/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using System;

using UnityEngine;

using DG.Tweening;

namespace UI {
	[RequireComponent(typeof(CanvasGroup))]
	public class BaseView : MonoBehaviour {
		private CanvasGroup _canvasGroupReference;
		private CanvasGroup _canvasGroup => this._canvasGroupReference ??= this.GetComponent<CanvasGroup>();

		#region Public
		
		/// <summary>
		/// Fade in the view.
		/// </summary>
		/// <param name="duration">The duration of the fade.</param>
		/// <param name="completionCallback">The completion callback.</param>
		protected virtual void FadeIn(float duration, Action completionCallback = null) {
			this._canvasGroup.DOFade(1f, duration).OnComplete(Completion);

			void Completion() {
				completionCallback?.Invoke();
			}
		}
		
		/// <summary>
		/// Fade out the view.
		/// </summary>
		/// <param name="duration">The duration of the fade.</param>
		/// <param name="completionCallback">The completion callback.</param>
		protected virtual void FadeOut(float duration, Action completionCallback = null) {
			this._canvasGroup.DOFade(0f, duration).OnComplete(Completion);

			void Completion() {
				completionCallback?.Invoke();
			}
		}
		
		#endregion
	}
}