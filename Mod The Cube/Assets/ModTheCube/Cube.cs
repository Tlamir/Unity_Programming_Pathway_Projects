using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public int rotateSpeed=3;
    private Color lerpedColor= new Color (100f, 8.0f, 0.4f, 0.2f);
    private Material material;


    void Start()
    {
        transform.position = new Vector3(3, 3, 3);
        transform.localScale = Vector3.one * 1.3f;


        material = Renderer.material;
        material.color = lerpedColor;
    }
    
    void Update()
    {
        transform.Rotate(Vector3.down, 45 * Time.deltaTime * rotateSpeed);
        transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
        ColorChangerr();
    }
    void ColorChangerr()
    {
        lerpedColor = Color.Lerp(Color.red,Color.blue, Mathf.PingPong(Time.time, 1));
        material.color = lerpedColor;
    }
}
