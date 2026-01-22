using UnityEngine;

public class InteractivePopUp : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(Player.transform.position, gameObject.transform.position) < 2.5f)
            animator.SetBool("Came", true);
        else animator.SetBool("Came", false);
    }
}
