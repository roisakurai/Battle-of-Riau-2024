using UnityEngine;

public class ENMY_CannonBallEnemy : MonoBehaviour
{
    public ParticleSystem shipEffects;
    public ParticleSystem waterEffects;
    public ParticleSystem landEffects;

    private AudioSource audioSource;
    public AudioClip soundShip, soundWater, soundLand;

    private bool shipPlayed = false;
    private bool waterPlayed = false;
    private bool landPlayed = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!shipPlayed && !waterPlayed && !landPlayed)
        {
            if (other.CompareTag("Enemy") && other is BoxCollider)
            {
                // Hanya memutar efek visual dan audio
                PlayEffectsAndSound(soundShip, shipEffects, ref shipPlayed);
            }

            if (other.CompareTag("Water"))
            {
                PlayEffectsAndSound(soundWater, waterEffects, ref waterPlayed);
            }

            if (other.CompareTag("Land"))
            {
                PlayEffectsAndSound(soundLand, landEffects, ref landPlayed);
            }
        }
    }

    private void PlayEffectsAndSound(AudioClip sound, ParticleSystem effects, ref bool playedFlag)
    {
        audioSource.PlayOneShot(sound);
        playedFlag = true;
        effects.Play();
    }
}
