using UnityEngine;

public class ParticleEffectScript : MonoBehaviour
{
    public ParticleSystem particleEffect; // Assign your particle effect in the Inspector
    public GameObject Player; // Assign your player game object in the Inspector

    void Start()
    {
        // If the particle effect is not playing on start, play it
        if (!particleEffect.isPlaying)
        {
            particleEffect.Play();
        }
    }

    void Update()
    {
        // Always emit particles from the back of the player
        Vector3 particlePosition = Player.transform.position - Player.transform.forward;
        particleEffect.transform.position = particlePosition;
    }
}
