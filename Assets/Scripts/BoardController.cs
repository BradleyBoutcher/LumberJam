using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Handle board generation and maintenance
 * 
 *  Coroutines used for generating purely aesthetic grid lines 
 */

public class BoardController : MonoBehaviour
{
    private LineRenderer Horizontal;
    private LineRenderer Vertical;

    public LineRenderer Line;

    public BoardController()
    {
        this.Horizontal = Line;
        this.Vertical = Line;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(generateHorizontalLines());
        StartCoroutine(generateVerticalLines());
    }

    private IEnumerator generateHorizontalLines()
    {
        float start = this.GetComponent<Renderer>().bounds.min.x + 0.5f;        // offset the start so we don't intersect the center
        float end = this.GetComponent<Renderer>().bounds.max.x;
        float horizontal_z = this.GetComponent<Renderer>().bounds.min.z;
        try
        {
            print("Instantiating horizontal lines...");
            for (float i = start; i < end; i++)
            {
                Vector3 newPos = new Vector3()
                {
                    x = i,
                    y = 0.1f,
                    z = horizontal_z,
                };
                                   
                Instantiate(Line, newPos, Line.transform.localRotation, this.transform);
            }
        }
        catch
        {
            Debug.Log("An error occurred generating Horizontal Grid Lines");
        }

        yield return null;
    }

    private IEnumerator generateVerticalLines()
    {
        float start = this.GetComponent<Renderer>().bounds.min.z + 0.5f;        // offset the start so we don't intersect the center
        float end = this.GetComponent<Renderer>().bounds.max.z;
        float vertical_x = this.GetComponent<Renderer>().bounds.min.x;

        try
        {
            print("Instantiating vertical lines...");
            for (float i = start; i < end; i++)
            {
                Vector3 newPos = new Vector3()
                {
                    x = vertical_x,
                    y = 0.1f,
                    z = i,
                };
                                     
                Instantiate(Line, newPos, Quaternion.Euler(new Vector3(0, 90, 0)), this.transform);
            }
        }
        catch
        {
            Debug.Log("An error occurred generating Vertical Grid Lines");
        }

        yield return null;
    }
}
