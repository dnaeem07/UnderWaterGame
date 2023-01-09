using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class UICONTROLLER : MonoBehaviour
{
    // Start is called before the first frame update
    public string level;
    public AudioSource BtnSound;
    void Start()
    {
        
    }
    public void SelectLevel(string levelname)
    {
        PlayerPrefs.SetInt("CURRENTLEVEL", 0);
        level = levelname;
    }
    public void BUTTONSOUNDPLAY()
    {
        BtnSound.Play();
    }
    public void LoadLevel()
    {
        PlayerPrefs.SetString("LEVEL", level);
        SceneManager.LoadScene(level);
    }
    public void Q()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
