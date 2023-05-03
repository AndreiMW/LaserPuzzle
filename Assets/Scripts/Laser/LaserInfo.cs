/**
 * Created Date: 4/27/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using UnityEngine;

public struct LaserInfo {
	public Vector3 StartPosition { get; internal set; }
	public Vector3 Direction { get; internal set; }
	public Color32 Color { get; internal set; }
}