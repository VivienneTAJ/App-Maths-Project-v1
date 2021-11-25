using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour //Script by: B00381904
{
    public Animator animator;
    public int sceneToLoad;
    public void FadeOut(int sceneIndex)
    {
        sceneToLoad = sceneIndex;
        animator.SetTrigger("FadeOut");
    }
    //public void FadeIn()
    //{    
    //    animator.SetTrigger("FadeIn");
    //}
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
