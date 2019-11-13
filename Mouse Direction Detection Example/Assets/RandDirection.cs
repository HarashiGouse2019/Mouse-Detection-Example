using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandDirection : MonoBehaviour
{
    public enum Direction
    {
        LEFT = 180,
        RIGHT = 0,
        UP = 90,
        DOWN = 270
    }

    public Direction enum_Direction;

    public int setHorizontal;
    public int setVertical;

    MouseEvent m_Event;
    bool coolDown = false;
    public float time;

    public AudioSource source;

    private void Start()
    {
        m_Event = FindObjectOfType<MouseEvent>();
        RandomizeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        CoolDown();

        transform.eulerAngles = new Vector3(0, 0, (float)enum_Direction);

        if (!coolDown && 
            (m_Event.horIndex == setHorizontal && (enum_Direction == Direction.LEFT || enum_Direction == Direction.RIGHT) || 
            (m_Event.verIndex == setVertical && (enum_Direction == Direction.UP || enum_Direction == Direction.DOWN))))
        {
            m_Event.Refresh();
            RandomizeDirection();
            source.PlayOneShot(source.clip);
            coolDown = true;
        }
    }

    void RandomizeDirection()
    {
        int randDirection = Random.Range(0, 2);
        switch (randDirection)
        {
            case 0:
                enum_Direction = Direction.LEFT;
                setHorizontal = 0;
                break;

            case 1:
                enum_Direction = Direction.RIGHT;
                setHorizontal = 1;
                break;

            case 2:
                enum_Direction = Direction.UP; 
                setVertical = 0;
                break;

            case 3:
                enum_Direction = Direction.DOWN;
                setVertical = 1;
                break;
        }
    }

    void CoolDown()
    {
        if (coolDown)
        {
            m_Event.horIndex = 2;
            m_Event.verIndex = 2;

            time += Time.deltaTime;
            if (time > 0.25f)
            {
                coolDown = false;
                time = 0f;
            }
        }
    }
}
