/**
 * Created Date: 4/25/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */


using System;
using System.Collections.Generic;
using UnityEngine;
using Color = UnityEngine.Color;
using Vector3 = UnityEngine.Vector3;

namespace Managers {
	public class LaserManager : MonoBehaviour {
		[SerializeField]
		private LaserOrigin _laserOrigin;

		[SerializeField]
		private LineRenderer _linePrefab;

		private List<LineRenderer> _visibleLines;

		private int _maxLaserDistance = 100;

		private bool _shootLasers;

		#region Lifecycle

		private void Awake() {
			this._visibleLines = new List<LineRenderer>();
		}

		private void Update() {
			if (this._shootLasers) {
				int linesCount = 0;

				linesCount += this.CalculateLaserLine(this._laserOrigin.Info, linesCount);

				this.RemoveOldLasers(linesCount);
			}
		}

		#endregion

		#region Public

		/// <summary>
		/// Set if the laser origin shoudlt shoot lasers.
		/// </summary>
		/// <param name="canShoot">True if should shoot laser, false otherwise. </param>
		public void ChangeCanShootLaser(bool canShoot) {
			this._shootLasers = canShoot;
		}

		/// <summary>
		/// Reset the lasers. (Delete current visible lasers)
		/// </summary>
		public void ResetLasers() {
			if (this._visibleLines is null) {
				return;
			}

			for (int i = 0; i < this._visibleLines.Count; i++) {
				this.RemoveOldLasers(i);
			}
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
			Ray ray = new Ray(info.StartPosition, info.Direction);
			int result = 1;
			bool raycast = Physics.Raycast(ray, out RaycastHit hit, this._maxLaserDistance);
			Vector3 hitPos = hit.point;
			LaserInfo nextInfo = info;
			if (raycast) {
				switch (hit.collider.tag) {
					case Tags.MIRROR: {
						nextInfo.StartPosition = hitPos;
						nextInfo.Direction = Vector3.Reflect(info.Direction, hit.normal);
						nextInfo.Color = info.Color;

						result += this.CalculateLaserLine(nextInfo, index + result);

						break;
					}
					case Tags.FILTER: {
						Color32 filterColor = hit.collider.GetComponent<FilterColor>().ColorOfFilter;
						if (info.Color != Color.white) {
							CmykColor filter = this.RgbToCmyk(filterColor);
							CmykColor line = this.RgbToCmyk(nextInfo.Color);
							CmykColor combination = this.CombineCMYKColors(filter, line);
							filterColor = this.CmykToRgb(combination);
						}

						nextInfo.StartPosition = hitPos + (info.Direction * 0.75f);
						nextInfo.Color = filterColor;
						nextInfo.Direction = info.Direction;

						result += this.CalculateLaserLine(nextInfo, index + result);
						break;
					}
					case Tags.LEVEL_END: {
						if (info.Color == LevelManager.Instance.LevelEndColor) {
							GameManager.Instance.ChangeState(GameManager.Instance.GameEnd);
						}

						break;
					}
				}
			} else {
				hitPos = info.StartPosition + info.Direction * this._maxLaserDistance;
			}

			this.DrawLine(info.StartPosition, hitPos, info.Color, index);
			return result;
		}

		private void DrawLine(Vector3 startPos, Vector3 endPos, Color32 color, int index) {
			LineRenderer lineRenderer = null;
			if (index < this._visibleLines.Count) {
				lineRenderer = this._visibleLines[index];
			} else {
				lineRenderer = GameObject.Instantiate(this._linePrefab, this.transform);
				this._visibleLines.Add(lineRenderer);
			}

			lineRenderer.SetPosition(0, startPos);
			lineRenderer.SetPosition(1, endPos);

			lineRenderer.startColor = color;
			lineRenderer.endColor = color;
		}

		private CmykColor RgbToCmyk(Color32 color) {
			double black = Math.Min(1.0 - color.r / 255.0, Math.Min(1.0 - color.g / 255.0, 1.0 - color.b / 255.0));
			double cyan = (1.0 - (color.r / 255.0) - black) / (1.0 - black);
			double magenta = (1.0 - (color.g / 255.0) - black) / (1.0 - black);
			double yellow = (1.0 - (color.b / 255.0) - black) / (1.0 - black);
			return new CmykColor(cyan, magenta, yellow, black);
		}

		private Color32 CmykToRgb(CmykColor color) {
			byte red = Convert.ToByte((1 - Math.Min(1, color.C * (1 - color.K) + color.K)) * 255);
			byte green = Convert.ToByte((1 - Math.Min(1, color.M * (1 - color.K) + color.K)) * 255);
			byte blue = Convert.ToByte((1 - Math.Min(1, color.Y * (1 - color.K) + color.K)) * 255);
			return new Color32(red, green, blue, 255);
		}

		private CmykColor CombineCMYKColors(CmykColor color1, CmykColor color2) {
			double cyan = Math.Min(color1.C + color2.C, 100);
			double magenta = Math.Min(color1.M + color2.M, 100);
			double yellow = Math.Min(color1.Y + color2.Y, 100);
			double black = Math.Min(color1.K + color2.K, 100);
			return new CmykColor(cyan, magenta, yellow, black);
		}

		#endregion

		#region CMYKColor

		private struct CmykColor {
			public readonly double C;
			public readonly double M;
			public readonly double Y;
			public readonly double K;

			public CmykColor(double c, double m, double y, double k) {
				this.C = c;
				this.M = m;
				this.Y = y;
				this.K = k;
			}
		}

		#endregion
	}
}