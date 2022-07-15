using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] private EnvironmentStateObject[] objects; 
    
    public void Set(EnvironmentState state)
    {
        foreach (var obj in objects)
        {
            obj.gameObject.SetActive(obj.state == state);
        }
    }
}

public enum EnvironmentState
{
    Day,
    Night
}