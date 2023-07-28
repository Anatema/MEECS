using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public virtual void OpenPanel()
    {
        gameObject.SetActive(true);
    }

    public virtual void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
