using UnityEngine;

public class SoundHashMap
{
    private const int SIZE = 20;

    // An array of linked lists to handle collisions
    private HashMapEntry[] table;

    public SoundHashMap()
    {
        table = new HashMapEntry[SIZE];
    }

    // A class to represent each entry in the hash map
    private int Hash(string key)
    {
        int hash = 0;

        foreach (char c in key)
        {
            hash += c;
        }

        return Mathf.Abs(hash % SIZE);
    }

    // Insert a new key-value pair into the hash map
    public void Add(string key, AudioClip value)
    {
        int index = Hash(key);

        HashMapEntry newEntry = new HashMapEntry(key, value);

        // Empty bucket
        if (table[index] == null)
        {
            table[index] = newEntry;
            return;
        }

        // Collision occurred
        HashMapEntry current = table[index];

        while (current.next != null)
        {
            // Update existing key if found
            if (current.key == key)
            {
                current.value = value;
                return;
            }

            current = current.next;
        }

        // Check last node
        if (current.key == key)
        {
            current.value = value;
            return;
        }

        current.next = newEntry;
    }
    
    // Retrieve the value associated with a key
    public AudioClip Get(string key)
    {
        int index = Hash(key);

        HashMapEntry current = table[index];

        while (current != null)
        {
            if (current.key == key)
            {
                return current.value;
            }

            current = current.next;
        }

        return null;
    }

    public bool ContainsKey(string key)
    {
        return Get(key) != null;
    }
}