using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generating
{
    public class BlockMovement : MonoBehaviour
    {
        public static event System.Action<BlockMovement> BlockDestroyedEvent;

        private void OnDestroy()
        {
            BlockDestroyedEvent?.Invoke(this);
        }
    }
}
