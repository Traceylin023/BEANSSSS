using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEndUI : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "MalcolmStartUI";

    public void NewGameButton ()
    {
        SceneManager.LoadScene(newGameLevel);
    }

}