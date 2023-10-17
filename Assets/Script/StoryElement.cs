using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StoryElement : MonoBehaviour, IStoryElement
{
    public abstract string Text { get; }
}
