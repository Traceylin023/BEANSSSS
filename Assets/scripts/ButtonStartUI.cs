using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStartUI : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Ty - HauntedHouse 6 - A (1)";

    public void NewGameButton ()
    {
        SceneManager.LoadScene(newGameLevel);
    }

}
