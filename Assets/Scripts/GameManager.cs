using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Players;
    [SerializeField] private Image[] PlayerImage;
    [SerializeField] private GameObject[] Sprites;
    [SerializeField] private GameObject Panel,SelectionPanel,PlayBtn,Shop;
    private int playerCount=0;
    private int playerNumber;
    public int[] spriteIndex;
    public void Start()
    {
        PlayerPrefs.SetString("spriteIndex","");
    }
    public void PlayerCount(int number)
    {
        playerNumber = number;
        PlayerPrefs.SetInt("playerNumber", number);
        Panel.SetActive(true);
        SelectionPanel.SetActive(true);
        for(int i = 0; i < number; i++)
        {
            Players[i].SetActive(true);
        }
    }
    public void playerSelection(int index)
    {
        spriteIndex[playerCount] = index;
        PlayerPrefs.SetString("spriteIndex", PlayerPrefs.GetString("spriteIndex") + " " +  index.ToString());
        playerCount += 1;
        
        //for(int y=0; y < Players.Length; y++)
        if (playerCount<=playerNumber)
        {
            Sprites[index].GetComponent<Button>().interactable = false;
            //Players[playerCount - 1].GetComponentInChildren<Button>().GetComponentInChildren<Image>().sprite;
            PlayerImage[playerCount-1].sprite = Sprites[index].GetComponent<Image>().sprite;
            PlayerImage[playerCount-1].enabled = true;
            Players[playerCount-1].GetComponentInChildren<Button>().interactable = false;
            if (playerCount <playerNumber)
            {
                Players[playerCount].GetComponentInChildren<Button>().interactable = true;
            }
            
            //Image image= Players[y].GetComponentInChildren<Button>().GetComponentInChildren<Image>();
            //image.GetComponent<Image>().sprite = Sprites[index];
        }
        if (playerCount==playerNumber)
        {
            PlayBtn.SetActive(true);
            Shop.SetActive(false);
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //game play scene restart 
    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
