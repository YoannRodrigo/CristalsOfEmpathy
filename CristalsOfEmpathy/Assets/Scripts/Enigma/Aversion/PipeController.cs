using UnityEngine;

public class PipeController : MonoBehaviour
{
    public ParticleSystem particlesSystem;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            particlesSystem.gameObject.SetActive(true);
            ParticleSystem.MainModule main = particlesSystem.main;
            main.loop = true;
            particlesSystem.Play();
        }
        else
        {
            ParticleSystem.MainModule main = particlesSystem.main;
            main.loop = false;
        }
    }
}