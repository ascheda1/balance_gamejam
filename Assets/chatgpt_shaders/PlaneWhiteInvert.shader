Shader "Custom/PlaneWhiteInvert"
{
    Properties 
    {
        _Color ("Tint Color", Color) = (1,1,1,1)
    }

    SubShader 
    {
        Tags { "Queue"="Geometry+2" }

        // Write stencil
        Pass
        {
            ZWrite Off
            ColorMask 0
            Stencil
            {
                Ref 2
                Comp Always
                Pass Replace
            }
        }

        // Inversion pass
        Pass
        { 
            ZWrite Off
            Stencil
            {
                Ref 2
                Comp Equal
                Pass Keep
            }

            Blend OneMinusDstColor OneMinusSrcAlpha
            BlendOp Add

CGPROGRAM
#pragma vertex vert
#pragma fragment frag 
uniform float4 _Color;

struct vertexInput
{
    float4 vertex: POSITION;
    float4 color : COLOR;    
};

struct fragmentInput
{
    float4 pos : SV_POSITION;
    float4 color : COLOR0; 
};

fragmentInput vert(vertexInput i)
{
    fragmentInput o;
    o.pos = UnityObjectToClipPos(i.vertex);
    o.color = _Color;
    return o;
}

half4 frag(fragmentInput i) : COLOR
{
    return i.color;
}
ENDCG
        }
    }
}
