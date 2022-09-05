using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private int _poolSize;
    [SerializeField] private Camera _camera;
    [SerializeField] protected Transform Container;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            var newObject = Instantiate(_template, Container);
            _pool.Add(newObject);
            newObject.SetActive(false);
        }
    }

    protected bool TryGetElement(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectAbroadScreen()
    {
        var deadPoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));
        foreach (var item in _pool)
        {
            if(item.activeSelf == true && item.transform.position.x < deadPoint.x)
            {
                item.SetActive(false);
            }
        }
    }
}
