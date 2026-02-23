using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using nm_cubersFile;

public class SoundPlayer {
	
	GameObject soundPlayerObj;
	GameObject soundPlayerObj2;
	AudioSource audioSource;
	AudioSource audioSource2;
	Dictionary<string, AudioClipInfo> audioClips = new Dictionary<string, AudioClipInfo>();

	BGMPlayer curBGMPlayer;
	BGMPlayer fadeOutBGMPlayer;


	// AudioClip information
	class AudioClipInfo {
		public string resourceName;
		public string name;
		public AudioClip clip;
		
		public AudioClipInfo( string resourceName, string name ) {
			this.resourceName = resourceName;
			this.name = name;
		}
	}
	
	public SoundPlayer() {
		audioClips.Add( "bomb001", new AudioClipInfo( "bomb001", "bomb001" ) );
		audioClips.Add( "bomb002", new AudioClipInfo( "F_Ball_thruder", "bomb002" ) );
		audioClips.Add( "bomb003", new AudioClipInfo( "GasReleasing12", "bomb003" ) );
		audioClips.Add( "bomb004", new AudioClipInfo( "F_Line_light", "bomb004" ) );
		audioClips.Add( "bomb005", new AudioClipInfo( "Shoot06", "bomb005" ) );
		audioClips.Add( "hit001", new AudioClipInfo( "Hit1", "hit001" ) );
		audioClips.Add( "hit004", new AudioClipInfo( "Hit4", "hit004" ) );
		audioClips.Add( "hit008", new AudioClipInfo( "Hit8", "hit008" ) ); //
		audioClips.Add( "hit010", new AudioClipInfo( "Button10", "hit010" ) );
		audioClips.Add( "coin001", new AudioClipInfo( "Coinz3", "coin001" ) );	//
		audioClips.Add( "fall001", new AudioClipInfo( "Fall1", "fall001" ) );
		audioClips.Add( "fall003", new AudioClipInfo( "Fall3", "fall003" ) );
		audioClips.Add( "fall004", new AudioClipInfo( "paku_BGM-fall01", "fall004" ) );
		audioClips.Add( "lost001", new AudioClipInfo( "paku_BGM-lost01", "lost001" ) );
		audioClips.Add( "bgm001", new AudioClipInfo( "paku_BGM-3", "bgm001" ) );

	
		if ( soundPlayerObj == null ) {
			soundPlayerObj = new GameObject( "SoundPlayer" ); 
			audioSource = soundPlayerObj.AddComponent<AudioSource>();
		}
		if ( soundPlayerObj2 == null ) {
			soundPlayerObj2 = new GameObject( "SoundPlayer" ); 
			audioSource2 = soundPlayerObj2.AddComponent<AudioSource>();
		}

	}






	public bool playSE( string seName, int sw ) {
		// TODO:1-1-11 追加 新規設定画面処理の作成
		if (cubersFile.setting_SoundEffect == 0)
        {
			// サウンドエフェクトオフ
			return false;
        }
		if ( audioClips.ContainsKey( seName ) == false )
			return false; // not register
		
		AudioClipInfo info = audioClips[ seName ];
		
		// Load
		if ( info.clip == null )
			info.clip = (AudioClip)Resources.Load( info.resourceName );
		
//		if ( soundPlayerObj == null ) {
//			soundPlayerObj = new GameObject( "SoundPlayer" ); 
//			audioSource = soundPlayerObj.AddComponent<AudioSource>();
//		}
		if (sw == 1) {
			audioSource.GetComponent<AudioSource>().pitch = 1.8f;
			audioSource.GetComponent<AudioSource>().volume = 0.03f;
		}
		else if (sw == 2) {
			audioSource.GetComponent<AudioSource>().volume = 0.04f;
		}
		else if (sw == 3) {
			audioSource.GetComponent<AudioSource>().pitch = 0.7f;
			audioSource.GetComponent<AudioSource>().volume = 0.5f;
		}
		else {
			audioSource.GetComponent<AudioSource>().volume = 1.0f;
		}
		// Play SE
		audioSource.PlayOneShot( info.clip );
		
		return true;
	}
	
	public bool playSE_2( string seName, int sw ) {
		// TODO:1-1-11 追加 新規設定画面処理の作成
		if (cubersFile.setting_SoundEffect == 0)
		{
			// サウンドエフェクトオフ
			return false;
		}
		if ( audioClips.ContainsKey( seName ) == false )
			return false; // not register
		
		AudioClipInfo info = audioClips[ seName ];
		
		// Load
		if ( info.clip == null )
			info.clip = (AudioClip)Resources.Load( info.resourceName );
		
//		if ( soundPlayerObj2 == null ) {
//			soundPlayerObj2 = new GameObject( "SoundPlayer" ); 
//			audioSource2 = soundPlayerObj2.AddComponent<AudioSource>();
//		}
		
		if (sw == 1) {
			audioSource2.GetComponent<AudioSource>().pitch = 3.0f;
			audioSource2.GetComponent<AudioSource>().volume = 0.2f;
		}
		else if (sw == 2) {
			audioSource2.GetComponent<AudioSource>().pitch = 0.3f;
			audioSource2.GetComponent<AudioSource>().volume = 0.1f;
		}
		else if (sw == 3) {
			audioSource2.GetComponent<AudioSource>().pitch = 0.5f;
			audioSource2.GetComponent<AudioSource>().volume = 0.05f;
		}
		else if (sw == 4) {
			audioSource2.GetComponent<AudioSource>().pitch = 1.0f;
			audioSource2.GetComponent<AudioSource>().volume = 0.5f;
		}
		else if (sw == 5) {
			audioSource2.GetComponent<AudioSource>().pitch = 1.0f;
			audioSource2.GetComponent<AudioSource>().volume = 0.02f;
		}
		else {
			audioSource2.GetComponent<AudioSource>().pitch = 1.0f;
//			audioSource2.GetComponent<AudioSource>().pitch = 0.3f;
			audioSource2.GetComponent<AudioSource>().volume = 1.0f;
		}
		// Play SE
		audioSource2.PlayOneShot( info.clip );
//		
		return true;
	}
	
	public bool stopSE() {

		if ( audioSource != null ) {
			audioSource.Stop();
		}

		return true;
	}

	public bool stopSE_2() {
		
		if ( audioSource2 != null ) {
			audioSource2.Stop();
		}
		
		return true;
	}


	public void playBGM( string bgmName, float fadeTime ) {
			// destory old BGM
		if ( fadeOutBGMPlayer != null )
			fadeOutBGMPlayer.destory();
		
		// change to fade out for current BGM
		if ( curBGMPlayer != null ) {
			curBGMPlayer.stopBGM( fadeTime );
			fadeOutBGMPlayer = curBGMPlayer;
		}
		
		// play new BGM
		if ( audioClips.ContainsKey( bgmName ) == false ) {
			// null BGM
			curBGMPlayer = new BGMPlayer();
		} else {
			curBGMPlayer = new BGMPlayer( audioClips[ bgmName ].resourceName );
			curBGMPlayer.playBGM( fadeTime );
		}
	}

	public void playBGM() {

		if ( curBGMPlayer != null && curBGMPlayer.hadFadeOut() == false )
			curBGMPlayer.playBGM();
		if ( fadeOutBGMPlayer != null && fadeOutBGMPlayer.hadFadeOut() == false )
			fadeOutBGMPlayer.playBGM();
	}
	
	public void pauseBGM() {
		if ( curBGMPlayer != null )
			curBGMPlayer.pauseBGM();
		if ( fadeOutBGMPlayer != null )
			fadeOutBGMPlayer.pauseBGM();
	}
	
	public void stopBGM( float fadeTime ) {
		if ( curBGMPlayer != null )
			curBGMPlayer.stopBGM( fadeTime );
		if ( fadeOutBGMPlayer != null )
			fadeOutBGMPlayer.stopBGM( fadeTime );
	}

}

public class Singleton<T> where T : class, new() {
	
	static T obj = null;
	
	Singleton() {}
	
	public static T instance {
		get {
			if ( obj == null )
				obj = new T();
			return obj;
		}
	}
}