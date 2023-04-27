/**
 * Created Date: 4/25/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using UnityEngine;

public class LaserOrigin : MonoBehaviour {
	[SerializeField]
	private Color _color;

	public LaserInfo Info;

	#region Lifecycle
	
	private void Awake() {
		this.Info.StartPosition = this.transform.position;
		this.Info.Direction = this.transform.forward;
		this.Info.Color = this._color;
	}
	
	#endregion
}