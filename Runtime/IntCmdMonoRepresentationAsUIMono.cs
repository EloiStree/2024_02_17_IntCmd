using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntCmdMonoRepresentationAsUIMono : MonoBehaviour
{

    public IntCmdMonoRepresentationMono m_representationSource;

    public Text m_debugRaw;
    public Image m_debugIntAsColor;
    public Image[] m_debugIntAsColorRgba;
    public RawImage m_debugIntAsTexture;
    private Texture2D m_debugTexture;
    private Color32[] m_colors;
    public bool m_mipChain;
    public bool m_linear;
    public void Start()
    {
        m_debugTexture = new Texture2D(32,1,TextureFormat.RGBA32, m_mipChain, m_linear);
        m_colors = new Color32[32];
    }

    public Color32 m_color1;
    public Color32 m_color0;
    private void Update()
    {
        if (m_representationSource == null)
            return;
        if (m_representationSource.m_structure.Length < 10)
            return;
       
        m_debugRaw.text = string.Format("{0:000000000000}\n{1}\n{2}\nC# {3}\n|\nPython Javascript {4}",
            m_representationSource.m_int,
            m_representationSource.m_structure,
            m_representationSource.m_binarySplitByByte,
            m_representationSource.littleEndianBytesAsString,
            m_representationSource.bigEndianBytesAsString
            //m_representationSource.littleEndianBytesAs255String,
            //m_representationSource.bigEndianBytesAs255String
            );
        m_debugIntAsColor.color = new Color32(m_representationSource.littleEndianBytes[0], m_representationSource.littleEndianBytes[1], m_representationSource.littleEndianBytes[3], 255);

        string r = m_representationSource.m_structure;
        for (int i = 0; i < 32 ; i++)
        {
            if (i < r.Length)
                m_colors[i] = r[i] == 1 ? m_color1 : m_color0;
            else m_colors[i] = m_color0;
        }
        m_debugTexture.SetPixels32(m_colors);

        m_debugTexture.Apply();
        m_debugIntAsTexture.texture = m_debugTexture;

        m_debugIntAsColorRgba[0].color = new Color32(m_representationSource.littleEndianBytes[0], 0, 0,255);
        m_debugIntAsColorRgba[1].color = new Color32(0,m_representationSource.littleEndianBytes[1],  0, 255);
        m_debugIntAsColorRgba[2].color = new Color32(0,0,m_representationSource.littleEndianBytes[2], 255);
        m_debugIntAsColorRgba[3].color = new Color32(255, 255, 255, m_representationSource.littleEndianBytes[3]);

    }

}
