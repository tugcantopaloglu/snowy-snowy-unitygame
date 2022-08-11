using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float sceneDelayCount = 0.5f;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] AudioClip crashSFX;
    bool isHit = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && isHit == false)
        {
            FindObjectOfType<PlayerController>().DisableControl();
            crashParticle.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            isHit = true;
            Invoke("ReloadScene", sceneDelayCount);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Level_1");
    }
}
