using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneName : MonoBehaviour
{  
    public int GetLevel()
    {
        var sceneName = gameObject.scene.name;
        var level = int.Parse(sceneName);
        return level;
    }
}
