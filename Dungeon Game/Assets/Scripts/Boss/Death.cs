using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Death : MonoBehaviour
{

    public GameObject Explosion;

    private void OnEnable()
    {
        StartCoroutine(DeathExplosion());
    }

    IEnumerator DeathExplosion()
    {
        Time.timeScale = 0.5f;
        for (int i = 0; i < 25f; ++i)
        {
            Instantiate(Explosion, new Vector3(Random.Range(-2f, 2f), Random.Range(-1f, 1f), 0f), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
