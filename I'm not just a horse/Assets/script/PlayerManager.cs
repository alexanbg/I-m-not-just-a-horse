using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Leaderboard leaderboard;
    public TMP_InputField playerName;
    public TextMeshProUGUI Score;

    [SerializeField]
    public GameObject Horse;

    [SerializeField]
    public GameObject Pannel;

    int  highscore = 0;
    void Start()
    {
        StartCoroutine(SetupRoutine());
        Pannel.gameObject.SetActive(false);
        playerName.text = FindObjectOfType<PassableObject>().playerName;
        SetPlayerName();
    }
    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return leaderboard.FetchTopHighscoresRoutine();
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if(response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Could not start session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerName.text, (response) =>
        {
            if(response.success)
            {
                Debug.Log("Succesfully set player name");
            }
            else
            {
                Debug.Log("Could not set player name"+response.Error);
            }
        });
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        highscore++;
        Score.text = "Score: " + highscore;
        if(Horse == null){
            Debug.Log("Horse Died");
            StartCoroutine(DieRoutine());
        }
    }
    

    IEnumerator DieRoutine()
    {
        Time.timeScale = 0f;
        Pannel.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
    }
    public void PlayAgain(){
        StartCoroutine(leaderboard.SubmitScoreRoutine(highscore, playerName.text));
        Time.timeScale = 1f;
        FindObjectOfType<PassableObject>().playerName = playerName.text;
        SceneManager.LoadScene("1");
    }

}
