using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    public Text storyText;
    public Button[] optionButtons;
    public Player player;

    public Action<IStoryElement> OnPlayerChoiceMade = (element) => { };

    private Story currentStory;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentStory = StoryManager.GetStartingStory();
        UpdateUI();
    }

    public void HandlePlayerChoice(int optionIndex)
    {
        LogOption selectedOption = currentStory.options[optionIndex];
        player.UpdatePlayer(selectedOption);
        currentStory = selectedOption.nextStory;
        UpdateUI();

        OnPlayerChoiceMade.Invoke(selectedOption); // Notificar a los observadores
    }

    void UpdateUI()
    {
        storyText.text = currentStory.Text;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i < currentStory.options.Count)
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<Text>().text = currentStory.options[i].Text;
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }
    }
}
