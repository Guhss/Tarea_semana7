using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.OnPlayerChoiceMade += HandlePlayerChoiceMade;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnPlayerChoiceMade -= HandlePlayerChoiceMade;
    }

    private void HandlePlayerChoiceMade(IStoryElement storyElement)
    {
        
    }
}
