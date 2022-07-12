using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public bool showWinScreen = false;
    public bool showLoseScreen = false;
    public int maxItems = 4;
    public string labelText = "Collect all items and take your freedom";
    private int _itemsCollected = 0;
    public int Items
    {
        get
        {
            return _itemsCollected;
        }
        set
        {
            _itemsCollected = value;

            if (_itemsCollected >= maxItems)
            {
                setValues("You've found all the items!", 0f, true);
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected)
                    + " more to go!";
            }
        }
    }

    private int _playerHP = 10;
    public int HP
    {
        get
        {
            return _playerHP;
        }
        set
        {
            _playerHP = value;
            if (_playerHP <= 0)
            {
                setValues("You want another life with that?", 0f, false);
            }
            else
            {
                labelText = "Ouch! That's got hurt!";
            }
        }
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25),
            "Player Health:" + _playerHP);

        GUI.Box(new Rect(20, 50, 150, 25),
    "Items collected:" + _itemsCollected);

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50),
            labelText);
        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 -100,
                Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                Utilities.RestartLevel(0);
            }
        }
        if (showLoseScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
                Screen.height / 2 - 50, 200, 100), "YOU LOSE!"))
            {
                Utilities.RestartLevel(0);
            }
        }
    }
    private void setValues(string labelText, float timeScale, bool isShowWinScreen) {
        this.labelText = labelText;
        if (isShowWinScreen)
        {
            this.showWinScreen = true;
        }
        else
        {
            this.showLoseScreen = true;
        }
        Time.timeScale = timeScale;
    }
}
