using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;

    public AudioClip callAmbulance;
    public AudioClip breathChecking;
    public AudioClip breathChecking2;
    public AudioClip startCpr;
    public AudioClip startCpr2;
    public AudioClip heartBeat;
    public AudioClip ambulance;
    public AudioClip entryAudio;

    // Start is called before the first frame update
    void Start()
    {
        source.clip = entryAudio;
        source.Play();

        StartCoroutine(CallAmbulance());

    }

    IEnumerator CallAmbulance()
    {
        yield return new WaitForSeconds(8);
        source.clip = callAmbulance;
        source.Play();
    }

    public void CheckHeartBeatAudio()
    {
        source.clip = breathChecking;
        source.PlayDelayed(3);
    }

    public void CheckHeartBeatAudioTwo()
    {
        
        source.clip = breathChecking2;
        source.PlayDelayed(3);
    }

    public void HeartBeat()
    {
        source.loop = true;
        source.clip = heartBeat;
        source.pitch = 0.9f;
        source.Play();
    }

    public void StartCPRAudio()
    {
        source.clip = startCpr;
        source.Play();

        StartCoroutine(StartCPRAudio2());
    }

    IEnumerator StartCPRAudio2()
    {
        yield return new WaitForSeconds(6);
        source.clip = startCpr2;
        source.Play();
    }

    public void AmbulanceSound()
    {
        source.clip = ambulance;
        source.Play();
    }
}
