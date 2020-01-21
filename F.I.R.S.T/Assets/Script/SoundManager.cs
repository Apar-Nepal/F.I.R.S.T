using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source1;

    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public AudioClip clip5;

    // Start is called before the first frame update
    void Start()
    {
        source1.clip = clip1;

        StartCoroutine(CallAmbulance());

    }

    IEnumerator CallAmbulance()
    {
        yield return new WaitForSeconds(3);
        source1.Play();
    }

    public void CheckHeartBeatAudio()
    {
        source1.clip = clip2;
        source1.PlayDelayed(3);
    }

    public void CheckHeartBeatAudioTwo()
    {
        source1.clip = clip3;
        source1.Play();
    }

    public void StartCPRAudio()
    {
        source1.clip = clip4;
        source1.Play();

        source1.clip = clip5;
        source1.PlayDelayed(7);
    }
}
