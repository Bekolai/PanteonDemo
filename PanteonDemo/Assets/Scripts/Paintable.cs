using System.Collections;
using System.IO;
using UnityEngine;

public class Paintable : MonoBehaviour
{

    public GameObject Brush;
    public float BrushSize = 0.1f;
    public RenderTexture RTexture;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            //cast a ray to the plane
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(Ray, out hit) && hit.collider.gameObject.CompareTag("PaintCanvas"))
            {
                //instanciate a brush
                var go = Instantiate(Brush, hit.point + Vector3.up * 0.1f, transform.rotation, transform);
                go.transform.localScale = Vector3.one * BrushSize;
                go.transform.localPosition = new Vector3(go.transform.localPosition.x,0.1f,go.transform.localPosition.z);
            }

        }
    }

}