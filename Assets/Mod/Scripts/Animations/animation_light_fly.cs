using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_light_fly : MonoBehaviour
{  
    void Awake()
    {
        StartCoroutine(idle());
    }

    void Update()
    {

    }

    private IEnumerator idle() {
        while (true)
        {
            for (int i = 0; i < 30; i++)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.005f, this.transform.position.z);
                yield return new WaitForSeconds(.02f);
            }

            for (int i = 0; i < 30; i++)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.005f, this.transform.position.z);
                yield return new WaitForSeconds(.02f);
            }
        }
    }
}
