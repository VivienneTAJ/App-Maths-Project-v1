using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScrollbarValue : MonoBehaviour //Script by: B00381904
{
    public Scrollbar sb;
    public IEnumerator Start()
    {
        yield return null;
        sb.value = 1;
    }
}
