using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClicked : MonoBehaviour {

    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }

    public void ExitScene()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
    }

}
