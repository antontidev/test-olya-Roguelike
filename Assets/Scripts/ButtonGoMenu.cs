using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonGoMenu : MonoBehaviour
{
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}