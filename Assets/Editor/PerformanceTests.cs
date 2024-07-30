using NUnit.Framework;
using Unity.PerformanceTesting;
using UnityEngine;

public class PerformanceTests
{
    private GameObject _go;
    private const int LoopCount = 100000;
    private const int TestCount = 100;
    
    [SetUp]
    public void Setup()
    {
        _go = new GameObject();
        _go.AddComponent<ComponentWithInterface>();
    }
    
    [Test, Performance]
    public void TestGetComponentInterface()
    {
        Measure.Method(() =>
            {
                for (var i = 0; i < LoopCount; i++)
                {
                    _go.GetComponent<IDamageable>();
                }
            })
            .MeasurementCount(TestCount)
            .Run();
    }
    
    [Test, Performance]
    public void TestGetComponentDefault()
    {
        Measure.Method(() =>
            {
                for (var i = 0; i < LoopCount; i++)
                {
                    _go.GetComponent<ComponentWithInterface>();
                }
            })
            .MeasurementCount(TestCount)
            .Run();
    }
}

public class SimpleComponent : MonoBehaviour
{
    
}

public class ComponentWithInterface : MonoBehaviour, IDamageable
{
    public void TakeDamage(int damage)
    {
        
    }
}

public interface IDamageable
{
    void TakeDamage(int damage);
}