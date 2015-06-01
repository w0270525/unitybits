using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

    /// <summary>
    /// loads level from 
    /// </summary>
    /// <param name="level"></param>
    public void LoadScene(int level)
    {
        Application.LoadLevel(level);

    }
}
