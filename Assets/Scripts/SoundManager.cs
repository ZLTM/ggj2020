using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance;

    [Tooltip ("Play music clip when start")]
    public AudioClip musicsGame;
    [Range (0, 1)]
    public float musicsGameVolume = 0.5f;

    private AudioSource musicAudio;
    private AudioSource soundFx;

    //GET and SET
    public static float MusicVolume {
        set { Instance.musicAudio.volume = value; }
        get { return Instance.musicAudio.volume; }
    }
    public static float SoundVolume {
        set { Instance.soundFx.volume = value; }
        get { return Instance.soundFx.volume; }
    }
    // Use this for initialization
    void Awake () {
        Instance = this;
        musicAudio = gameObject.AddComponent<AudioSource> ();
        musicAudio.loop = true;
        soundFx = gameObject.AddComponent<AudioSource> ();
    }
    void Start () {
        Instance.soundFx.volume = PlayerPrefs.GetFloat ("SoundVolume", 0.8f);
        Instance.musicAudio.volume = PlayerPrefs.GetFloat ("MusicVolume", 0.8f);
        PlayMusic (musicsGame, musicsGameVolume);
    }

    public void MomentUpdateSoundFxVolume (float Volume) {
        if (Volume >= Instance.soundFx.volume) {
            return;
        }
        Instance.soundFx.volume = Volume;
    }

    public void MomentUpdateMusicVolume (float Volume) {
        if (Volume >= Instance.musicAudio.volume) {
            return;
        }
        Instance.musicAudio.volume = Volume;
    }

    public void UpdateSoundFxVolume (float Volume) {
        Instance.soundFx.volume = Volume;
        PlayerPrefs.SetFloat ("SoundVolume", Volume);
    }

    public void UpdateMusicVolume (float Volume) {
        Instance.musicAudio.volume = Volume;
        PlayerPrefs.SetFloat ("MusicVolume", Volume);
    }

    public void PlaySfxFromScene (AudioClip clip) {
        PlaySfx (clip);
    }

    public static void PlaySfx (AudioClip clip) {
        Instance.PlaySound (clip, Instance.soundFx);
    }

    public static void PlaySfx (AudioClip clip, float volume) {
        Instance.PlaySound (clip, Instance.soundFx, volume);
    }

    public static void PlayMusic (AudioClip clip) {
        Instance.PlaySound (clip, Instance.musicAudio);
    }

    public static void PlayMusic (AudioClip clip, float volume) {
        Instance.PlaySound (clip, Instance.musicAudio, volume);
    }

    private void PlaySound (AudioClip clip, AudioSource audioOut) {
        if (clip == null) {
            return;
        }

        if (audioOut == musicAudio) {
            audioOut.clip = clip;
            audioOut.Play ();
        } else
            audioOut.PlayOneShot (clip, SoundVolume);
    }

    private void PlaySound (AudioClip clip, AudioSource audioOut, float volume) {
        if (clip == null) {
            return;
        }

        if (audioOut == musicAudio) {
            audioOut.clip = clip;
            audioOut.Play ();
        } else
            audioOut.PlayOneShot (clip, SoundVolume * volume);
    }

    public void PlaySoundClick () {
        //PlaySfx(soundClick);
    }
}