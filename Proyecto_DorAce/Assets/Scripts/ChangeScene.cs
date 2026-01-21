using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour
{
    public float delayTime;
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) { StartCoroutine(change()); }
    }

    IEnumerator change()
    {
        yield return new WaitForSeconds(delayTime);

        SceneManager.LoadScene(sceneName);


    }

}
