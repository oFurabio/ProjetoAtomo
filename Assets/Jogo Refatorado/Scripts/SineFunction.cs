using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using static UnityEditor.PlayerSettings;

public class SineFunction : MonoBehaviour {

    [Header("")]
    [SerializeField] private float amplitude = 1f;
    [SerializeField] private float frequency = 1f;
    [SerializeField] private bool invert;

    private Vector2 position;

    private float sin;
    private float center;


    private void Start() {
        position = transform.position;
        center = position.x;
    }

    private void FixedUpdate() {
        position = transform.position;

        sin = Mathf.Sin(position.y * frequency) * amplitude;

        if (invert)
            sin *= -1f;

        position.x = center + sin;

        transform.position = position;
    }
}
