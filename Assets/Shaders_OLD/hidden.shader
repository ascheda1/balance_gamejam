Shader "Custom/HiddenBehindInvert"
{
    Properties
    {
        _Color ("Color", Color) = (0,0,0,1)
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }

        // ✅ Pass 1: Draw ONLY where stencil != 2 (i.e., NOT behind plane)
        Pass
        {
            Stencil
            {
                Ref 2
                Comp NotEqual // Only draw where stencil is NOT 2
                Pass Keep
            }

            ZWrite On         // Write depth normally when visible
            ColorMask RGBA

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            fixed4 _Color;

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return _Color;
            }
            ENDCG
        }

        // ❌ Pass 2: Do NOT draw anything or write depth where stencil == 2
        // Prevents blocking objects seen through the plane
        Pass
        {
            Stencil
            {
                Ref 2
                Comp Equal // This is the hidden area (behind plane)
                Pass Keep
            }

            ZWrite Off        // <- THIS is the critical line
            ColorMask 0       // <- No color written either
        }
    }
}
