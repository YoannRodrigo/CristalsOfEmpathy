using UnityEngine;

public class PipeController : MonoBehaviour
{
    public ParticleSystem particlesSystem;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            ParticleSystem.MainModule main = particlesSystem.main;
            particlesSystem.GetComponent<Renderer>().enabled = true;
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