using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    [SerializeField] float nopackagemusicTime = 30f;
    [SerializeField] float packagemusicTime = 30f;
    public AudioSource audioSource;
    public AudioClip nopackageClip;
    public AudioClip packageClip;
    public Delivery delivery;
    void Update()
    {
        if(delivery.hasPackage && audioSource.clip != packageClip)
        {
            audioSource.Stop();
            audioSource.clip = packageClip;
            audioSource.loop = true;
            audioSource.time = packagemusicTime;
            audioSource.Play();
        }
        else if (!delivery.hasPackage && audioSource.clip != nopackageClip)
        {
            audioSource.Stop();
            audioSource.clip = nopackageClip;
            audioSource.loop = true;
            audioSource.time = nopackagemusicTime;
            audioSource.Play();
        }
    }
}
