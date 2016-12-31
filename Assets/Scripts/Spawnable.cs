using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// This class should contain fields and logic common to all spawnable objects
    /// </summary>
    public class Spawnable : MonoBehaviour
    {
        [Tooltip("Average number of seconds between appearances")]
        public float SeenEverySeconds;
    }
}
