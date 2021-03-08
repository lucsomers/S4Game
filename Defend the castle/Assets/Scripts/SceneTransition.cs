using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    #region SingleTon
    public static SceneTransition instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField] private float transitionTime;
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("StartScene", true);
    }

    public void LoadScene(string sceneToLoadName)
    {
        Debug.Log(SceneManager.GetSceneByName(sceneToLoadName).name);
        StartCoroutine(LoadLevel(SceneManager.GetSceneByName(sceneToLoadName).buildIndex));
    }

    public void LoadScene(int sceneToLoadIndex)
    {
        StartCoroutine(LoadLevel(sceneToLoadIndex));
    }

    IEnumerator LoadLevel(int sceneToLoadName)
    {
        animator.SetBool("StartScene", false);

        yield return new WaitForSeconds(transitionTime);

        if (GameData.instance.Multiplayer)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.LoadLevel(sceneToLoadName);
            }
            else
            {
                SceneManager.LoadScene(sceneToLoadName);
            }
        }
        else
        {
            SceneManager.LoadScene(sceneToLoadName);
        }
    }
}
