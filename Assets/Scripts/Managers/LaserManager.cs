/**
 * Created Date: 4/25/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using System.Collections.Generic;

using UnityEngine;

public class LaserManager : MonoBehaviour {
	private static LaserManager s_instance; 
	public static LaserManager Instance => s_instance ??= FindObjectOfType<LaserManager>();

	[SerializeField]
	private LaserOrigin _laserOrigin;

	[SerializeField]
	private LineRenderer _linePrefab;
	
	private List<LineRenderer> _visibleLines;

	private int _maxLaserDistance = 100;

	#region Lifecycle
	
	private void Awake() {
		this._visibleLines = new List<LineRenderer>();
	}

	private void FixedUpdate() {
		int linesCount = 0;

		linesCount += this.CalculateLaserLine(this._laserOrigin.Info, linesCount);
		
		this.RemoveOldLasers(linesCount);
	}

	private void OnDestroy() {
		s_instance = null;
	}
	
	#endregion
	
	#region Private

	private void RemoveOldLasers(int linesCount) {
		if (linesCount < this._visibleLines.Count) {
			Destroy(this._visibleLines[^1].gameObject);
			this._visibleLines.RemoveAt(this._visibleLines.Count - 1);
			this.RemoveOldLasers(linesCount);
		}
	}
	
	private int CalculateLaserLine(LaserInfo info, int index) {
		Ray ray = new Ray(info.StartPosition,info.Direction);
		int result = 1;
		bool raycast = Physics.Raycast(ray, out RaycastHit hit, this._maxLaserDistance);
		Vector3 hitPos = hit.point;
		LaserInfo nextInfo = info;
		if (raycast) {
			if (hit.collider.CompareTag(Tags.MIRROR)) {
				nextInfo.StartPosition = hitPos;
				nextInfo.Direction = Vector3.Reflect(info.Direction, hit.normal);
				nextInfo.Color = info.Color;
				
				result += this.CalculateLaserLine(nextInfo, index + result);
			}else if (hit.collider.CompareTag(Tags.FILTER)) {
				Color filterColor = hit.collider.GetComponent<FilterColor>().Color;
				if (info.Color != Color.white) {
					//TODO Refactor this, it's not working right
					filterColor = (filterColor + info.Color) / 2;
				}
				nextInfo.StartPosition = hit.collider.transform.position;
				nextInfo.Color = filterColor;
				nextInfo.Direction = info.Direction;
				
				result += this.CalculateLaserLine(nextInfo, index + result);
			}
		} else {
			hitPos = info.StartPosition + info.Direction * this._maxLaserDistance;
		}
		this.DrawLine(info.StartPosition, hitPos, info.Color, index);
		return result;
	}
	
	private void DrawLine(Vector3 startPos, Vector3 endPos, Color color, int index) {
		LineRenderer lineRenderer = null;
		if (index < this._visibleLines.Count) {
			lineRenderer = this._visibleLines[index];
		} else {
			lineRenderer = GameObject.Instantiate(this._linePrefab);
			this._visibleLines.Add(lineRenderer);
		}

		lineRenderer.SetPosition(0, startPos);
		lineRenderer.SetPosition(1, endPos);

		lineRenderer.startColor = color;
		lineRenderer.endColor = color;
	}

	#endregion
	
}