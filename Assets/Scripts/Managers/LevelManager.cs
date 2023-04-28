/**
 * Created Date: 4/28/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using System;

using UnityEngine;

using Levels;

namespace Managers {
	public class LevelManager : MonoBehaviour {
		private static LevelManager s_instance;
		public static LevelManager Instance => s_instance ??= FindObjectOfType<LevelManager>();

		private LevelData[] _levelDatas;
		
		public event Action OnLevelLoaded;
		public event Action OnLevelEnded;

		private LevelData _currentLevelData;
		private Level _currentLevelInstance;
		
		private int _currentLevelIndex;
		private int _actualLevelIndex;
		
		#region Lifecycle
		private void Awake() {
			this._levelDatas = Resources.LoadAll<LevelData>("LevelDatas");
			this._currentLevelIndex = UserSettings.Instance.CurrentReachedLevel;
		}
		
		private void OnDestroy() {
			s_instance = null;
		}
		
		#endregion
		
		#region Public
		
		/// <summary>
		/// Load next level index that is saved in PlayerPrefs.
		/// </summary>
		public void LoadLevel() {
			this._actualLevelIndex = this._currentLevelIndex;
			while (this._actualLevelIndex >= this._levelDatas.Length) {
				this._actualLevelIndex -= (this._levelDatas.Length - 1);
			}
			this._currentLevelData = this._levelDatas[this._actualLevelIndex];
			if (this._currentLevelInstance != null){
				Destroy(this._currentLevelInstance.gameObject);
				this._currentLevelInstance = null;
			}
			this._currentLevelInstance = GameObject.Instantiate(this._levelDatas[this._actualLevelIndex].LevelPrefab, this.transform);
			this._currentLevelInstance.Init(this._currentLevelData.EndLevelColor);
			this.OnLevelLoaded?.Invoke();
		}

		/// <summary>
		/// Change the lasers state.
		/// </summary>
		/// <param name="shouldShoot">Should shoot lasers?</param>
		public void ChangeLasersState(bool shouldShoot) {
			this._currentLevelInstance.LaserManager.ChangeCanShootLaser(shouldShoot);
		}
		
		/// <summary>
		/// Trigger level end.
		/// </summary>
		public void LevelEnd() {
			this._currentLevelIndex++;
			UserSettings.Instance.CurrentReachedLevel = this._currentLevelIndex;
			UserSettings.Instance.SaveSettings();
			this.OnLevelEnded?.Invoke();
		}
		
		#endregion
	}
}