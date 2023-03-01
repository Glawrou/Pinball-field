using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private SpringJoint _springJoint;

    private void Awake()
    {
        StartCoroutine(Spring());
    }

    private IEnumerator Spring()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            for (var s = 200; s > 0; s--)
            {
                _springJoint.spring = s;
                yield return new WaitForFixedUpdate();
            }

            yield return new WaitForSeconds(2);
            _springJoint.spring = 200;
        }
    }
}
