using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayGamesUpload : MonoBehaviour
{

    public GameMaster gm;

    public void Upload()
    {
        //PlayGamesController.instance.OnAddScoreToLeaderBoard((int)gm.score);
    }

    public void ShowLeaderboard()
    {
        if (Social.localUser.authenticated)
            PlayGamesController.instance.OnShowLeaderBoard();
        else
        {
            // authenticate user:
            Social.localUser.Authenticate((bool success) => {
                // handle success or failure
                if (success)
                {
                    Debug.Log("Login Success....");
                    PlayGamesController.instance.OnAddScoreToLeaderBoard((int)gm.score);
                    PlayGamesController.instance.OnShowLeaderBoard(); // Show current (Active) leaderboard
                }
                else
                {
                    Debug.Log("Login Failed....");
                }
            });
        }
    }
}
