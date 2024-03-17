using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parapdeo : MonoBehaviour
{

    Light luz;

    private void Start()
    {
        luz = GetComponent<Light>();

        IEnumerator a = parpaiding();
        StartCoroutine(a);
    }

    IEnumerator parpaiding()
    {
        yield return new WaitForSeconds(Random.Range(0f,1.2f));
        while (true)
        {
            luz.intensity = 24594.62f;
            yield return new WaitForSeconds(1.0f);
            luz.intensity = 800;
            yield return new WaitForSeconds(0.2f);
            luz.intensity = 0;
            yield return new WaitForSeconds(0.2f);
            luz.intensity = 800;
            yield return new WaitForSeconds(0.2f);
            luz.intensity = 0;
            yield return new WaitForSeconds(0.2f);
        }
    }

}
