using UnityEngine;

public class fadecontroller : MonoBehaviour
{
    public Animator animator;
    public Canvas fadeCanvas;
    public GameObject Cube;
    public GameObject Mezzanine;
    public GameObject Cantina;
    public GameObject LivingRoom;
    private GameObject currSphere;

    void Awake()
    {
        currSphere = LivingRoom;
    }
    public void FadeToLevel ()
    {
        animator.SetTrigger("FadeOut");
        fadeCanvas.gameObject.SetActive(false);
    }

    public void FadeToBlack (int level)
    {
        fadeCanvas.gameObject.SetActive(true);
        animator.SetTrigger("FadeIn");
        ChangeScene(level);
    }

    public void ChangeScene (int level)
    {
        if (level == 0)
        {
            currSphere.gameObject.SetActive(false);
            LivingRoom.gameObject.SetActive(true);
            currSphere = LivingRoom;
        } else if (level == 1)
        {
            currSphere.gameObject.SetActive(false);
            Cube.gameObject.SetActive(true);
            currSphere = Cube;
        } else if (level == 2)
        {
            currSphere.gameObject.SetActive(false);
            Cantina.gameObject.SetActive(true);
            currSphere = Cantina;
        } else if (level == 3)
        {
            currSphere.gameObject.SetActive(false);
            Mezzanine.gameObject.SetActive(true);
            currSphere = Mezzanine;
        }
        FadeToLevel();
    }
}
