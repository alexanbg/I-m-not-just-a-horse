using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Leaderboard leaderboard;

    [SerializeField]
    public GameObject Horse;

    [SerializeField]
    public GameObject Pannel;

    int  highscore = 0;
    void Start()
    {
        StartCoroutine(SetupRoutine());
        Pannel.gameObject.SetActive(false);
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



    // Update is called once per frame
    void FixedUpdate()
    {
        highscore++;
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
        yield return leaderboard.SubmitScoreRoutine(highscore);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
