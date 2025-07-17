using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class LaserDoPlayer : MonoBehaviour
{
    public float velocidadeDolaser;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarOlaser();
    }
    private void MovimentarOlaser()
    {
        transform.Translate(Vector3.up * velocidadeDolaser * Time.deltaTime);
    }
}
