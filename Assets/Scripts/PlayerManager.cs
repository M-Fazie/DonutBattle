using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{
    
    private int PlayerNumber;
    [SerializeField] private Button[] button;
    [SerializeField] private GameObject[] playerAutoMove;
    [SerializeField] private GameObject[] player;
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private GameObject Panel, winPanel, loadingPanel;
    [SerializeField] private Text winPanelText, loadingPanelText;
    [SerializeField] private Image winnerSprite;
    private float time = 4;
    public string[] spriteIndexArray;
    private bool enter = true;
    void Start()
    {
        PlayerPrefs.SetInt("IsPlay", 0);
        LoadingPanelOpen();
        string str = PlayerPrefs.GetString("spriteIndex");
        spriteIndexArray = str.Split(' ');
        //for(int r=0; r < PlayerNumber; r++)
        //{
        //    spriteIndexArray[r] = arraystring[r];
        //}
        //spriteIndexArray = GameObject.FindGameObjectWithTag("gameManager").gameObject.GetComponent<GameManager>().spriteIndex;
        PlayerNumber =PlayerPrefs.GetInt("playerNumber");
        for(int i =0; i<PlayerNumber; i++)
        {
            //Debug.Log(gameManager.spriteIndex[i]);
            button[i].interactable = true;
            player[i].GetComponent<SpriteRenderer>().sprite = sprite[int.Parse(spriteIndexArray[i].Trim())];
        }
        
        for (int i = PlayerNumber; i <4; i++)
        {
            player[i].GetComponent<SpriteRenderer>().sprite = sprite[Random.Range(0,7)];
            Debug.Log("sprite name  "+sprite[Random.Range(0, 7)].name);
            
            playerAutoMove[i].SetActive(true);
        }

    }
    public void Update()
    {
        time = time-Time.deltaTime;
        loadingPanelText.text = time.ToString();
        
        if (time <= 0&& enter)
        {
            enter = false;
            LoadingPanelClose();
        }
        if (PlayerPrefs.GetInt("IsPlayerDead")==1)
        {
            PlayerPrefs.SetInt("IsPlayerDead", 0);
            
            if (player[0].activeInHierarchy == false)
            {

                button[0].interactable = false;
            }
            if (player[1].activeInHierarchy == false)
            {
                button[1].interactable = false;
            }
            if (player[2].activeInHierarchy == false)
            {
                button[2].interactable = false;
            }
            if (player[3].activeInHierarchy == false)
            {
                button[3].interactable = false;
            }

            GameObject[] temp =GameObject.FindGameObjectsWithTag("Enemy");
            Debug.Log("enemys count : "+ temp.Length);
            if(temp.Length<=1)
            {
                winPanelOpen();
                temp[0].tag="Winner";
                string name=GameObject.FindGameObjectWithTag("Winner").name;
                Debug.Log(name);
                winPanelText.text = name + " WINNER!";
                winnerSprite.sprite= GameObject.FindGameObjectWithTag("Winner").GetComponent<SpriteRenderer>().sprite;
                
            }
        }       
    }
    public void winPanelOpen()
    {
        Panel.SetActive(true);
        winPanel.SetActive(true);       
    }
    
    public void LoadingPanelOpen()
    {
        Panel.SetActive(true);
        loadingPanel.SetActive(true);
        
    }
    public void LoadingPanelClose()
    {
        Panel.SetActive(false);
        loadingPanel.SetActive(false);
        
        PlayerPrefs.SetInt("IsPlay", 1);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
