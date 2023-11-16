using System.Collections;
using UnityEngine;

namespace Assets._Scripts.General_use
{
    public class AutoDestroyer : TimedAction
    {
        public override void DoAction()
        {
            Destroy(gameObject);
        }
    }
}