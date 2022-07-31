using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnemyTriggerDo : MonoBehaviour
{
    [SerializeField] private UnityEvent action;
    [SerializeField] private UnityEvent filteredAction;
    [SerializeField] List<string> ignoreTagsToIgnore;

    private void OnTriggerEnter2D(Collider2D collision) {
        action.Invoke();
        foreach (var ignoreTag in ignoreTagsToIgnore)
        {
            if (collision.tag == ignoreTag)
                return;
        }
        filteredAction.Invoke();
    }
}
