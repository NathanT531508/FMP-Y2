using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] GameObject Title;
    [SerializeField] GameObject Play;
    [SerializeField] GameObject Tim;
    [SerializeField] GameObject Quit;


    void Start()
    {
        LeanTween.moveLocal(Title, new Vector3(0, 483, 0), 3f).setEaseInOutBack();
        StartCoroutine(Thing());
    }

    public IEnumerator Thing()
    {
        yield return new WaitForSeconds(1f);
        LeanTween.moveLocal(Play, new Vector3(-855, 93, 0), 3f).setEaseInOutQuad();
        yield return new WaitForSeconds(.4f);
        LeanTween.moveLocal(Tim, new Vector3(-855, -90, 0), 3f).setEaseInOutQuad();
        yield return new WaitForSeconds(.4f);
        LeanTween.moveLocal(Quit, new Vector3(-855, -275, 0), 3f).setEaseInOutQuad();
        yield return new WaitForSeconds(.4f);
    }

}
