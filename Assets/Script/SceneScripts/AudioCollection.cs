using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollection : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips= new List<AudioClip>();
    private Dictionary<string, AudioClip> audioClipDict= new Dictionary<string, AudioClip>();

    private void Awake()
    {
        audioClips.ForEach(clip =>
        {
            audioClipDict.Add(clip.name, clip);
        });
    }

    public AudioClip GetAudioClip(string name)
    {
        if (audioClipDict.ContainsKey(name))
        {
            return audioClipDict[name];
        }

        return null;
    }
}
