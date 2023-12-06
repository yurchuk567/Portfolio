using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]
//Цей код гарантує, що TrailRenderer і BoxCollider знаходяться на GameObject, яким є сценарій
//прикріплений до.
public class ClickandSwipe : MonoBehaviour
{
    private GameManager gameManager;
    private Camera cam;
    private Vector3 mousePos;
    private TrailRenderer trailRenderer;
    private BoxCollider boxCollider;

    private bool swiping = false;
    // Start is called before the first frame update
    private void Awake()
    {
        cam = Camera.main;
        trailRenderer = GetComponent<TrailRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        trailRenderer.enabled = false;
        boxCollider.enabled = false;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }


    private void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                UpdateComponents();
            }
            if (swiping)
            {
                UpdateMousePosistion();
            }
        }
    }

    // Update is called once per frame
    void UpdateMousePosistion()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        // ScreenToWorld перетворить положення миші на екрані у положення світу. Причина, яку ми використовуємо
       // 10,0f по осі z, тому що камера має положення z -10,0f
        transform.position = mousePos;
    }
    private void UpdateComponents()
    {
        trailRenderer.enabled = swiping;
        boxCollider.enabled = swiping;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }
}
