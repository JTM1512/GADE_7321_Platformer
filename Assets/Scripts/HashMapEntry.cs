using UnityEngine;

public class HashMapEntry
{
    public string key;
    public AudioClip value;
    public HashMapEntry next;

    // Creates a new entry with the specified key and value
    public HashMapEntry(string key, AudioClip value)
    {
        this.key = key;
        this.value = value;
        next = null;
    }
}