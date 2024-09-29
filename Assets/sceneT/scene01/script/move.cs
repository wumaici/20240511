using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class move : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Quad"))
        {
            SceneManager.LoadScene(collision.gameObject.GetComponent<SceneInfo>().SceneName);
        }
    }

}
