using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBtns : MonoBehaviour {

   public void PlayGame() {

        SceneManager.LoadScene(1, LoadSceneMode.Single);

    }

   public void QuitGame() {

        Application.Quit();

    }
}
