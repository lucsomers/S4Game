using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    public const int ClassUnlockCost = 200;

    #region SingleTon
    public static Locker instance;

    private void Awake()
    {
        if (instance != this || instance == null)
        {
            instance = this;
        }
    }
    #endregion

    [SerializeField] private GameObject lockImage;
    [SerializeField] private GameObject readyButton;
    [SerializeField] private GameObject unlockButton;

    public void UnlockClass(ClassStats selectedClass)
    {
        PlayerPrefs.SetInt(selectedClass.ClassName,1);
        PlayerPrefs.Save();

        UpdateLockedState(selectedClass);
    }

    public void UpdateLockedState(ClassStats selectedClass)
    {
        bool unlocked = PlayerPrefs.HasKey(selectedClass.ClassName);
        
        if (unlocked)
        {
            //Unlocked
            lockImage.SetActive(false); 

            if (readyButton != null)
            {
                if (!Photon.Pun.PhotonNetwork.IsMasterClient)
                {
                    readyButton.SetActive(true);
                }
                else
                {
                    if (ReadyGame.readyPlayer)
                    {
                        readyButton.SetActive(true);
                    }
                }
            }

            if (unlockButton != null)
            {
                unlockButton.SetActive(false);
            }
        }
        else
        {
            //Locked
            lockImage.SetActive(true);

            if (readyButton != null)
            {
                readyButton.SetActive(false);
            }

            if (unlockButton != null)
            {
                unlockButton.SetActive(true);
            }
        }
    }
}
