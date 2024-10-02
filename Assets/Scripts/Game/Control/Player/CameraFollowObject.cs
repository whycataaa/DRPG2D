using System.Collections;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{

    [SerializeField]
    float OFFSET;

    [DisplayOnly][SerializeField]
    private float offset;
    //过渡时间
    [SerializeField]
    private float transTime;

    private Coroutine turnCoroutine;
    [DisplayOnly][SerializeField]
    bool IsTurning=false;
    private PlayerController playerController;



    void Awake()
    {
        offset = OFFSET;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        transform.position=new Vector2(transform.position.x+offset,transform.position.y);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        transform.position=playerController.transform.position+new Vector3(offset,0);
    }

    public void Turn()
    {
        if(IsTurning)
        {
            StopCoroutine(turnCoroutine);
        }
        turnCoroutine=StartCoroutine(Flip());
    }

    private IEnumerator Flip()
    {
        IsTurning=true;
        float startX=offset;
        float endX=GetEndX();
        float elapsedTime = 0f;

        while (elapsedTime < transTime)
        {
            elapsedTime += Time.deltaTime;

            offset=Mathf.Lerp(startX,endX,elapsedTime/transTime);

            yield return null;

            if(elapsedTime>=transTime)
            {
                IsTurning=false;
            }
        }

    }

    private float GetEndX()
    {
        if(playerController.IsFacingRight)
        {
            return OFFSET;
        }
        else
        {
            return -OFFSET;
        }
    }
}
