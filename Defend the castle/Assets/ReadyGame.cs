using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyGame : MonoBehaviour
{
    [SerializeField] private ClassSelector selector;

    public void StartGame()
    {
        string selectedClassName = selector.CurrentClass.ClassName;

        PlayerPrefs.SetString("SelectedClass", selectedClassName);
        PlayerPrefs.Save();

        //Load next scene
        SceneTransition.instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
