using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour

{

    [SerializeField] float screenWidthInUnits = 16f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosition = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlesPos = new Vector2(transform.position.x, transform.position.y);
        paddlesPos.x = Mathf.Clamp(mousePosition, 1f, screenWidthInUnits -1);
        transform.position = paddlesPos;
    }
}
