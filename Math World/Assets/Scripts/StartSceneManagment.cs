using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartSceneManagment : MonoBehaviour
{
    public GameObject startButton, quitButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
