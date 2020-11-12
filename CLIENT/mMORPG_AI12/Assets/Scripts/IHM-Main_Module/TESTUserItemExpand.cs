using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTUserItemExpand : MonoBehaviour
{

    private float smoothTime;
    private Vector2 velocity;
    private Vector2 target;
    private Boolean reduced;

    // Start is called before the first frame update
    void Start()
    {
        smoothTime = 0.3F;
        velocity = Vector2.zero;
        target = GetComponent<RectTransform>().sizeDelta;
        reduced = true;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().sizeDelta = Vector2.SmoothDamp(GetComponent<RectTransform>().sizeDelta, target, ref velocity, smoothTime);
    }

    public void OnClickOnUserInfo()
    {
        Debug.Log("CLICK");
        Vector2 grow = new Vector2(GetComponent<RectTransform>().sizeDelta.x, 289);
        Vector2 shrink = new Vector2(GetComponent<RectTransform>().sizeDelta.x, 41);
        if (reduced)
        {
            target = grow;
            transform.Find("Details").gameObject.SetActive(true);
        }
        else
        {
            target = shrink;
            transform.Find("Details").gameObject.SetActive(false);
        }
        reduced = !reduced;
    }
}
