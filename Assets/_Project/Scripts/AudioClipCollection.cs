using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "AudioClipCollection", menuName = "Audio/AudioClipCollection")]
public class AudioClipCollection : ScriptableObject
{
    public AudioClip[] clips;    
}
