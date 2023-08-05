using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabbage : MonoBehaviour
{
    public float timer  = 0f;
    public float growTime = 6f;
    private float maxSize = 1f;
    public bool isMaxSize;
    private Vector3 startSize;
    private int cost = 8;
    private bool isGrowing;
    // Start is called before the first frame update
    private void Start()
    {
        startSize = transform.localScale;
        isMaxSize = false;
        isGrowing = false;
    }

    public void growCabbage()
    {
        if (!isMaxSize)
        {
            if (!isGrowing)
            {
                if(PlayerProfile.Instance.UseItem(new Item_Info() { ID = Item_ID.Cabbage}))
                {
                    StartCoroutine(grow());
                    isGrowing = true;
                } else if(PlayerProfile.Instance.DecreaseMoney(cost))
                {
                    StartCoroutine(grow());
                    isGrowing = true;
                }
                
            }

        }
    }

    public void harvestCabbage()
    {
        if (isMaxSize)
        {
            PlayerProfile.Instance.AddItem(new Item_Info() { ID = Item_ID.Cabbage }, 2);
            transform.localScale = startSize;
            isMaxSize = !isMaxSize;
            timer = 0;
        }
    }

    IEnumerator grow()
    {
        Vector3 startSize = transform.localScale;
        Vector3 maxScale = new Vector3(maxSize, maxSize, maxSize);
        do
        {
            //Lerp use to chang from this status into that status by time
            transform.localScale = Vector3.Lerp(startSize, maxScale, timer / growTime);
            yield return null;
            timer += Time.deltaTime;
        } while (timer < growTime);
        isMaxSize = true;
        isGrowing = false;
    }

}
