using UnityEngine;
using System.Collections;
using nm_cubersFile;

public class BGMPlayer {

	class State {
		protected BGMPlayer bgmPlayer;
		public State( BGMPlayer bgmPlayer ) {
			this.bgmPlayer = bgmPlayer;
		}
		public virtual void playBGM() {}
		public virtual void pauseBGM() {}
		public virtual void stopBGM() {}
		public virtual void update() {}
		public virtual void hadFadOut() {}
	}

	GameObject obj;
	AudioSource source;
	State state;
	float fadeInTime = 0.0f;
	float fadeOutTime = 0.0f;
	bool fadeOut;
	float pit = 1.0f;
	float vol = 0.5f;

	public BGMPlayer() {}


	public BGMPlayer( string bgmFileName ) {
		AudioClip clip = (AudioClip)Resources.Load( bgmFileName );
		if ( clip != null ) {
			obj = new GameObject( "BGMPlayer" );
			source = obj.AddComponent<AudioSource>();
			source.clip = clip;
			state = new Wait( this );
		} else
			Debug.Log( "BGM " + bgmFileName + " is not found." );
	}
	
	public void destory() {
		if ( source != null )
			GameObject.Destroy( obj );
	}
	
	public void playBGM() {
		if ( source != null ) {
			// TODO:1-1-11 追加 新規設定画面処理の作成
			if (cubersFile.setting_BGM == 0)
			{
				// BGMオフ
				return;
			}
			state.playBGM();
		}
	}
	public void playBGM(int sw) {
		if ( source != null ) {
			switch(sw) {
			case 0:
				this.source.volume = 0.5f;
				this.source.pitch = 1.0f;
//				this.vol = 0.5f;
//				this.pit = 1.0f;
				break;
			case 1:
				this.source.volume = 0.5f;
				this.source.pitch = 1.1f;
//				this.vol = 0.3f;
//				this.pit = 0.5f;
				break;
			case 2:
				this.source.volume = 0.5f;
				this.source.pitch = 1.2f;
//				this.vol = 0.3f;
//				this.pit = 0.3f;
				break;
			}
			state.playBGM();
		}
	}

	public void playBGM( float fadeTime ) {
		if ( source != null ) {
			this.fadeInTime = fadeTime;
			state.playBGM();
		}
	}
	
	public void pauseBGM() {
		if ( source != null )
			state.pauseBGM();
	}
	
	public void stopBGM( float fadeTime ) {
		if ( source != null ) {
			fadeOutTime = fadeTime;
			state.stopBGM();
		}
	}
	
	public void update() {
		if ( source != null )
			state.update();
	}

	public bool hadFadeOut () {
		return fadeOut;
	}


	class Wait : State {
		
		public Wait( BGMPlayer bgmPlayer ) : base( bgmPlayer ) {}
		
		public override void playBGM() {
			if ( bgmPlayer.fadeInTime > 0.0f )
				bgmPlayer.state = new FadeIn( bgmPlayer );
			else
				bgmPlayer.state = new Playing( bgmPlayer );
		}
	}

	class FadeIn : State {
		
		float t = 0.0f;
		
		public FadeIn( BGMPlayer bgmPlayer ) : base( bgmPlayer ) {
			bgmPlayer.source.Play();
			bgmPlayer.source.volume = 0.0f;
		}
		
		public override void pauseBGM() {
			bgmPlayer.state = new Pause( bgmPlayer, this );
		}
		
		public override void stopBGM() {
			bgmPlayer.state = new FadeOut( bgmPlayer );
		}
		
		public override void update() {
			t += Time.deltaTime;
			bgmPlayer.source.volume = t / bgmPlayer.fadeInTime;
			if ( t >= bgmPlayer.fadeInTime ) {
				bgmPlayer.source.volume = bgmPlayer.vol;
				bgmPlayer.state = new Playing( bgmPlayer );
				bgmPlayer.source.loop = true;
				bgmPlayer.source.pitch = bgmPlayer.pit;
//				bgmPlayer.source.pitch = 1.5f;
			}
		}
	}


	class Playing : State {
		
		public Playing( BGMPlayer bgmPlayer ) : base( bgmPlayer ) {
			if ( bgmPlayer.source.isPlaying == false ) {
				bgmPlayer.source.volume = bgmPlayer.vol;
				bgmPlayer.source.Play();
				bgmPlayer.source.loop = true;
				bgmPlayer.source.pitch = bgmPlayer.pit;
			}
		}
		
		public override void pauseBGM() {
			bgmPlayer.state = new Pause( bgmPlayer, this );
		}
		
		public override void stopBGM() {
			bgmPlayer.state = new FadeOut( bgmPlayer );
		}
	}


	class Pause : State {
		
		State preState;
		
		public Pause( BGMPlayer bgmPlayer, State preState ) : base( bgmPlayer ) {
			this.preState = preState;
			bgmPlayer.source.Pause();
		}
		
		public override void stopBGM() {
			bgmPlayer.source.Stop();
			bgmPlayer.state = new Wait( bgmPlayer );
		}
		
		public override void playBGM() {
			bgmPlayer.state = preState;
			bgmPlayer.source.Play();
		}
	}


	class FadeOut : State {
		float initVolume;
		float t = 0.0f;
		
		public FadeOut( BGMPlayer bgmPlayer ) : base( bgmPlayer ) {
			initVolume = bgmPlayer.source.volume;
		}
		
		public override void pauseBGM() {
			bgmPlayer.state = new Pause( bgmPlayer, this );
		}
		
		public override void update() {
			t += Time.deltaTime;
			bgmPlayer.source.volume = initVolume * ( 1.0f - t / bgmPlayer.fadeOutTime );
			bgmPlayer.fadeOut = false;
			if ( t >= bgmPlayer.fadeOutTime ) {
				bgmPlayer.source.volume = 0.0f;
				bgmPlayer.source.Stop();
				bgmPlayer.state = new Wait( bgmPlayer );
				bgmPlayer.fadeOut = true;
			}
		}
	}


}