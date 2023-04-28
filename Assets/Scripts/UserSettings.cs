/**
 * Created Date: 4/28/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using UnityEngine;

public class UserSettings {
	private static UserSettings s_settings;
	public static UserSettings Instance => s_settings ??= new UserSettings();
	
	private const string USER_REACHED_LEVEL = "c9e9a848920877e76685b2e4e76de38d";
	public int CurrentReachedLevel{ get; set; }

	private UserSettings() {
		this.LoadSettings();
	}
	
	#region Save Settings
    
	public void SaveSettings() {
		PlayerPrefs.SetInt(USER_REACHED_LEVEL, this.CurrentReachedLevel);
	}
    
	#endregion
    
	#region Load Settings

	private void LoadSettings() {
		this.CurrentReachedLevel = PlayerPrefs.GetInt(USER_REACHED_LEVEL, 0);
	}
    
	#endregion
}