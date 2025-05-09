using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private uint initPoolSize;
    [SerializeField] private PooledObject objectToPool;

    // プールされたオブジェクトをコレクションに格納する
    private Stack<PooledObject> stack;

    private void Start()
    {
        SetupPool();
    }

    // プールを作成する（ラグが目立たなくなったら呼び出す）
    private void SetupPool()
    {
        stack = new Stack<PooledObject>();
        PooledObject instance = null;

        for (int i = 0; i < initPoolSize; i++)
        {
            instance = Instantiate(objectToPool);
            instance.Pool = this;
            instance.gameObject.SetActive(false);
            stack.Push(instance);
        }
    }

    // プールから最初のアクティブなGameObjectを返す
    public PooledObject GetPooledObject()
    {
        // プールが十分に大きくない場合、新しいPooledObjectをインスタンス化する
        if (stack.Count == 0)
        {
            PooledObject newInstance = Instantiate(objectToPool);
            newInstance.Pool = this;
            return newInstance;
        }
        // それ以外の場合は、単にリストから次のものを取得する
        PooledObject nextInstance = stack.Pop();
        nextInstance.gameObject.SetActive(true);
        return nextInstance;
    }

    public void ReturnToPool(PooledObject pooledObject)
    {
        stack.Push(pooledObject);
        pooledObject.gameObject.SetActive(false);
    }
}
