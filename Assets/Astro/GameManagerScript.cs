using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.AI;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G Project Name = EXHILE

namespace AstroMomo
{
  public class GameManagerScript : NetworkBehaviour
  {
      public int MinimumPlayersForGame = 1;
      public Astroboii LocalPlayer;
      public GameObject StartPanel;
      public GameObject GameOverPanel;
      public GameObject HealthTextLabel;
      public GameObject ScoreTextLabel;
      public Text HealthText;
      public Text ScoreText;
      public Text PlayerNameText;
      public Text WinnerNameText;
      public bool IsGameReady;
      public bool IsGameOver;
      public List<Astroboii> players = new List<Astroboii>();

      // Update is called once per frame
      void Update()
      {
          if (NetworkManager.singleton.isNetworkActive)
          {
            GameReadyCheck();
            GameOverCheck();

            if (LocalPlayer == null)
            {
              FindLocalAstroboii();
            }
            else
            {
              ShowReadyMenu();
              UpdateStats();
            }
          }
          else
          {
            //cleanup state once the network is offline
            IsGameReady = false;
            LocalPlayer = null;
            players.Clear();
          }
      }

      void ShowReadyMenu()
      {
          if (NetworkManager.singleton.mode == NetworkManagerMode.ServerOnly)
            return;

          if (LocalPlayer.isReady)
            return;

          StartPanel.SetActive(true);
      }

      void GameReadyCheck()
      {
          if (!IsGameReady)
          {
            //look for connections that are not in the player list
            foreach (KeyValuePair<uint, NetworkIdentity> kvp in NetworkIdentity.spawned)
            {
              Astroboii comp = kvp.Value.GetComponent<Astroboii>();

              //ADD IF new
              if (comp != null && !players.Contains(comp))
              {
                  players.Add(comp);
              }

            }

            //if minimum connections has been check if they are all ready
            if (players.Count >= MinimumPlayersForGame)
            {
              bool AllReady = true;
              foreach (Astroboii astroboii in players)
              {
                if (!astroboii.isReady)
                {
                  AllReady = false;
                }
              }
              if (AllReady)
              {
                  IsGameReady = true;
                  AllowAstroboiiMovement();

                  //update loca gui
                  StartPanel.SetActive(false);
                  HealthTextLabel.SetActive(true);
                  ScoreTextLabel.SetActive(true);
              }
            }
          }
      }

      void GameOverCheck()
      {
        if (!IsGameReady)
        return;

        //cant win a game with only one player but this can be used for testing
        if (players.Count == 1)
            return;

        int alivePlayerCount = 0;
        foreach (Astroboii astroboii in players)
        {
          if (!tank.isDead)
          {
            alivePlayerCount++;
            //if there is only one player left than their name will be displayed as the winner
            WinnerNameText.text = astroboii.playerName;
          }
        }

        if (alivePlayerCount ==1)
        {
            IsGameOver = true;
            GameOverPanel.SetActive(true);
            DisallowAstroboiiMovement();
        }
      }

      void FindLocalAstroboii()
      {
          //check to see if the player is regristered in
          if (ClientScene.localPlayer == null)
              return;

          LocalPlayer = ClientScene.localPlayer.GetComponent<Astroboii>();
      }

      void UpdateStats()
      {
        HealthText.text = LocalPlayer.health.ToString();
        ScoreText.text = LocalPlayer.score.ToString();
      }

      public void ReadyButtonHandler()
      {
        LocalPlayer.SendReadyToServer(PlayerNameText.text);
      }

      void AllowAstroboiiMovement()
      {
        foreach (Astroboii astroboii in players)
        {
            astroboii.allowMovement = true;
        }
      }

      void DisallowAstroboiiMovement()
      {
        foreach (Astroboii astroboii in players)
        {
            astroboii.allowMovement = false;
        }
      }

  //last bracket
  }







//namespace last bracket
}
