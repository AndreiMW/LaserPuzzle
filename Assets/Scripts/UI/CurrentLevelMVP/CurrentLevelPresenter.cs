/**
 * Created Date: 5/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

namespace UI.CurrentLevelMVP {
	public class CurrentLevelPresenter {
		private readonly CurrentLevelModel _model;
		private readonly CurrentLevelView _view;
		
		#region Constructor

		public CurrentLevelPresenter(CurrentLevelModel model, CurrentLevelView view) {
			this._model = model;
			this._view = view;
			
			this.UpdateLevelText();
		}
		
		#endregion
		
		#region Public

		/// <summary>
		/// Update the current level text.
		/// </summary>
		public void UpdateLevelText() {
			this._view.UpdateLevelText(this._model.CurrentLevel);
		}
		
		#endregion
	}
}