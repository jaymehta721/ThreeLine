using UnityEngine;

public class BackgroundTile : MonoBehaviour
{

    public enum eBackgroundLocation
    {
        TOP =0,
        BOTTOM =1,
    }

    private eBackgroundLocation m_location;
    
    [SerializeField] private SpriteRenderer m_rebder;

    public void Config(eBackgroundLocation location)
    {
        m_location = location;
    }

    public eBackgroundLocation GetLocation()
    {
        return m_location;
    }

    public SpriteRenderer GetRenderer()
    {
        return m_rebder;
    }

}
