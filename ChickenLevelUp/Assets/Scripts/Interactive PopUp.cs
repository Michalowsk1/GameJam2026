using Unity.VisualScripting;
using UnityEngine;

public class InteractivePopUp : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public Animator animator;
    public bool inRange;
    public float interactionRange;

    // Update is called once per frame
    public void Detection()
    {
        Player = GameObject.Find("/Player");
        if (Vector2.Distance(Player.transform.position, gameObject.transform.position) < interactionRange)
        {
            animator.SetBool("Came", true);
            inRange = true;
        }
        else
        {
            animator.SetBool("Came", false);
            inRange = false;
        }
    }
}
