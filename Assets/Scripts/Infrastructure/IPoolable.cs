using System;

public interface IPoolable
{
    event Action<IPoolable> ReadyToReturn;
    void ReturnToPool();
}