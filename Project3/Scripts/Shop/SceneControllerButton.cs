using UnityEngine;
using UnityEngine.UI;

public class SceneControllerButton : MonoBehaviour
{
    enum TargetScene
    {
        Next,
        Previous,
        MainMenu
    }

    [SerializeField] TargetScene targetScene;       
}
