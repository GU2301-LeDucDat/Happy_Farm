using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    public float timer = 0f;
    public float growTime = 11f;
    private float maxSize = 1f;
    public bool isMaxSize;
    private Vector3 startSize;
    private int cost = 5;
    private bool isGrowing;

    private void Start()
    {
        startSize = transform.localScale;
        isMaxSize = false;
        isGrowing = false;
    }

    public void growTomato()
    {
        if (!isMaxSize)
        {
            if (!isGrowing)
            {
                if (PlayerProfile.Instance.UseItem(new Item_Info() { ID = Item_ID.Tomato }))
                {
                    StartCoroutine(grow());
                    isGrowing = true;
                }
                else if (PlayerProfile.Instance.DecreaseMoney(cost))
                {
                    StartCoroutine(grow());
                    isGrowing = true;
                }
            }
        }
    }

    public void harvestTomato()
    {
        if (isMaxSize)
        {
            PlayerProfile.Instance.AddItem(new Item_Info() { ID = Item_ID.Tomato}, 4);
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
            transform.localScale = Vector3.Lerp(startSize, maxScale, timer / growTime);
            timer += Time.deltaTime;
            yield return null;
        } while (timer < growTime);
        isMaxSize = true;
        isGrowing = false;
    }
}
