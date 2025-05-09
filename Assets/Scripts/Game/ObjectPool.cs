using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private uint initPoolSize;
    [SerializeField] private PooledObject objectToPool;

    // �v�[�����ꂽ�I�u�W�F�N�g���R���N�V�����Ɋi�[����
    private Stack<PooledObject> stack;

    private void Start()
    {
        SetupPool();
    }

    // �v�[�����쐬����i���O���ڗ����Ȃ��Ȃ�����Ăяo���j
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

    // �v�[������ŏ��̃A�N�e�B�u��GameObject��Ԃ�
    public PooledObject GetPooledObject()
    {
        // �v�[�����\���ɑ傫���Ȃ��ꍇ�A�V����PooledObject���C���X�^���X������
        if (stack.Count == 0)
        {
            PooledObject newInstance = Instantiate(objectToPool);
            newInstance.Pool = this;
            return newInstance;
        }
        // ����ȊO�̏ꍇ�́A�P�Ƀ��X�g���玟�̂��̂��擾����
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
