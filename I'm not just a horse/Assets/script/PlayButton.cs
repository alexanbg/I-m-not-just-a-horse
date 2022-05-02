using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayButton : MonoBehaviour
{
    private Button button;
    [SerializeField]
    private TextMeshProUGUI playerName;
    private string firstText;


    

    void Awake(){
        button = GetComponent<Button>();
        firstText = playerName.text;
    }

    void Update(){
        if(playerName.text == firstText){
            
            button.interactable = false;
        }
        else{
            button.interactable = true;
        }
        Debug.Log(playerName.text);
    }

    public void Play(){
        FindObjectOfType<PassableObject>().playerName = playerName.text;
        SceneManager.LoadScene("1");
    }

}
