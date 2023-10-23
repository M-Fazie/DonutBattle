using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private int PlayerNumber;
    [SerializeField] private Button[] button;
    [SerializeField] private GameObject[] playerAutoMove;
    [SerializeField] private GameObject[] player;
    [SerializeField] private Sprite[] sprite;
    void Start()
    {
        PlayerNumber=PlayerPrefs.GetInt("playerNumber");
        for(int i =0; i<PlayerNumber; i++)
        {
            button[i].interactable = true;
            //player[i].GetComponent<Image>().sprite = sprite[PlayerPrefs.GetInt("spriteIndex")];
        }
        
        for (int i = PlayerNumber; i <4; i++)
        {
            //player[i].GetComponent<SpriteRenderer>().sprite = sprite[Random.Range(0,7)];
            //player[i].GetComponent<Transform>().localScale = new Vector3(2f,2f,1f);
            playerAutoMove[i].SetActive(true);
        }
        for(int j=0; j<4; j++)
        {

        }
    }
    public void Update()
    {
        if(PlayerPrefs.GetInt("IsPlayerDead")==1)
        {
            PlayerPrefs.SetInt("IsPlayerDead", 0);
            if (PlayerPrefs.GetString("PlayerName") == "Player1")
            {
                button[0].interactable = false;
            }
            if (PlayerPrefs.GetString("PlayerName") == "Player2")
            {
                button[1].interactable = false;
            }
            if (PlayerPrefs.GetString("PlayerName") == "Player3")
            {
                button[2].interactable = false;
            }
            if (PlayerPrefs.GetString("PlayerName") == "Player4")
            {
                button[3].interactable = false;
            }
        }
       
    }


}
