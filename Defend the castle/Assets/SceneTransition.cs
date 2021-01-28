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
        if (instance == null || instance != this)
        {
            instance = this;
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

    public void LoadScene(int sceneToLoadIndex)
    {
        StartCoroutine(LoadLevel(sceneToLoadIndex));
    }

    IEnumerator LoadLevel(int sceneToLoadIndex)
    {
        animator.SetBool("StartScene", false);

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneToLoadIndex);
    }
}
