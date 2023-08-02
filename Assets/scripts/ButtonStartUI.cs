using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStartUI : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Malcolm - HauntedHouse1";

    public void NewGameButton ()
    {
        SceneManager.LoadScene(newGameLevel);
    }

}