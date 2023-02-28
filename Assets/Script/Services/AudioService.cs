using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : IAudioService
{
    private AudioCollection audioCollection;
    public AudioService(AudioCollection collection) 
    {
        audioCollection= collection;
    }

    AudioClip IAudioService.GetAudioClip(string name)
    {
        return audioCollection.GetAudioClip(name);
    }
}
