/**
 * Created Date: 4/25/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using UnityEngine;

public class FilterColor : MonoBehaviour {
	private enum Colors {
		Magenta,
		Cyan,
		Yellow,
		Green,
		Red,
		Blue
	}

	[SerializeField]
	private Colors _filterColor;

	private Renderer _renderer;

	public Color32 ColorOfFilter { get; private set; }
	
	#region Lifecycle

	private void Awake() {
		this._renderer = this.GetComponent<Renderer>();

		this.ColorOfFilter = this.ColorFromEnum();
		this._renderer.material.color = this.ColorOfFilter;
	}
	
	#endregion
	
	#region Private

	private Color32 ColorFromEnum() {
		switch (this._filterColor) {
			case Colors.Magenta: {
				return Color.magenta;
			}
			case Colors.Cyan: {
				return Color.cyan;
			}
			case Colors.Green: {
				return Color.green;
			}
			case Colors.Yellow: {
				return Color.yellow;
			}
			case Colors.Red: {
				return Color.red;
			}
			case Colors.Blue: {
				return Color.blue;
			}
			default:
				return Color.white;
		}
	}
	
	#endregion
}