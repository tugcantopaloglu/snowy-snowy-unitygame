using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float sceneDelayCount = 0.5f;
    [SerializeField] ParticleSystem crashParticle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            crashParticle.Play();
            Invoke("ReloadScene", sceneDelayCount);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Level_1");
    }
}
