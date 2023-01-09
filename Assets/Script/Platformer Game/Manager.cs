using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour
{
    public static Manager instance;
    public List<GameObject> DropPlatforms = new List<GameObject>();
    private void Awake()
    {
       
        if(instance==null)
        {
            instance = this;
        }

        CurrentLevel = PlayerPrefs.GetInt("CURRENTLEVEL", 0);

        if (CurrentLevel >= Env.Length)
            CurrentLevel = 0;

        Env[CurrentLevel].gameObject.SetActive(true);

        DropPlatform[] Drop = FindObjectsOfType<DropPlatform>();
        for(int i=0;i<Drop.Length;i++)
        {
            DropPlatforms.Add(Drop[i].gameObject);
        }
    }
    public void TurnDropPlatformsOn()
    {
        for(int i=0;i<DropPlatforms.Count;i++)
        {
            DropPlatforms[i].SetActive(true);
            DropPlatforms[i].GetComponent<DropPlatform>().isDestroyedCalled = false;
        }
    }
    public Text TreasureText;
    public int CurrentTreasure;
    public int TotalTresure;
    public float Health=100;
    public Image HealthImg;
    public int CurrentLevel;
    public GameObject LevelComplete;
    public GameObject GameComplete;

    public GameObject[] Env;

    public void MakeExit()
    {
        Application.Quit();
    }
    void Start()
    {
        TotalTresure = FindObjectsOfType<Treasure>().Length;
        TreasureText.text = "TREASURE: "+CurrentTreasure.ToString()+"/" + TotalTresure.ToString();    
    }
   
    public void DelayComplete(int delay)
    {
        Invoke("LevelHasComplete", delay);
    }
    public void LevelHasComplete()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;
        if (CurrentLevel != Env.Length - 1)
            LevelComplete.SetActive(true);
        else
            GameComplete.SetActive(true);
    }
    public void TreasureCollected()
    {
        CurrentTreasure++;
        TreasureText.text = "TREASURE: " + CurrentTreasure.ToString() + "/" + TotalTresure.ToString();
        if(CurrentTreasure==TotalTresure)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


            Time.timeScale = 0;
            if (CurrentLevel != Env.Length - 1)
                LevelComplete.SetActive(true);
            else
                GameComplete.SetActive(true);
        }
    }
    public void NextLevel()
    {
        CurrentLevel++;

        if (CurrentLevel == Env.Length)
            CurrentLevel = 0;

          
        PlayerPrefs.SetInt("CURRENTLEVEL", CurrentLevel);
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ReloadScene()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("MainMenu");
    }
    public void DecrementHealth()
    {
        Health -= 20;
        HealthImg.fillAmount = Health / 100;

        if(Health<=0)
        {
            Health = 100;
            HealthImg.fillAmount = Health / 100;
            FindObjectOfType<PlayerController>().ResetPosition();

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
