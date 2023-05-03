using UnityEngine;

public class SideLineTiles : MonoBehaviour
{

    public enum eLineLocation
    {
        LEFT = 0,
        RIGHT = 1,
        
    }

    private eLineLocation m_location;
    
    [SerializeField] private SpriteRenderer m_rebder;

    public void Config(eLineLocation location)
    {
        m_location = location;
    }

    public eLineLocation GetLocation()
    {
        return m_location;
    }

    public SpriteRenderer GetRenderer()
    {
        return m_rebder;
    }

}