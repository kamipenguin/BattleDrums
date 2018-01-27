﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    internal class BeatManager : MonoBehaviour
    {
        /// <summary>
        /// The amount of beats per minute.
        /// </summary>
        [SerializeField] private int _beatsPerMinute;

        /// <summary>
        /// Static instance <see cref="BeatManager"/>.
        /// </summary>
        public static BeatManager Instance { get; private set; }

        /// <summary>
        /// Time between beats.
        /// </summary>
        public float BeatTime { get { return 60f / _beatsPerMinute; } }

        /// <summary>
        /// Event thrown every beat.
        /// </summary>
        public UnityEvent Beat;
        public UnityEvent HalfTimeBeat;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            StartCoroutine(OpDaBeat());
        }

        /// <summary>
        /// Invokes <see cref="Beat"/> after every intervalof <see cref="BeatTime"/>.
        /// </summary>
        /// <returns></returns>
        private IEnumerator OpDaBeat()
        {
            while (true)
            {
                Beat.Invoke();
                yield return new WaitForSeconds(BeatTime / 2);
                HalfTimeBeat.Invoke();
                yield return new WaitForSeconds(BeatTime / 2);
            }
        }
    }
}
