Shader "Custom/ObjectBlack"
{
    Properties
    {
        _Color ("Color", Color) = (0,0,0,1)
    }

    SubShader
    {
        Tags { "Queue"="Transparent+100" }

        Stencil
        {
            Ref 1
            Comp Equal
        }

        Pass
        {
            ZWrite On
            ColorMask RGBA

CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

uniform float4 _Color;

struct appdata
{
    float4 vertex : POSITION;
};

struct v2f
{
    float4 pos : SV_POSITION;
};

v2f vert(appdata v)
{
    v2f o;
    o.pos = UnityObjectToClipPos(v.vertex);
    return o;
}

half4 frag(v2f i) : COLOR
{
    return _Color;
}
ENDCG
        }
    }
}
