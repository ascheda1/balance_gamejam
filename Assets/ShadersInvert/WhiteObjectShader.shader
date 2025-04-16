Shader "Custom/BlackObjectShader"
{
    Properties
    {
        _Color("Color", Color) = (0,0,0,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            float4 _Color;
            float3 _BlackPlanePosition;
            float3 _BlackPlaneNormal;

            struct appdata {
                float4 vertex : POSITION;
            };
            struct v2f {
                float4 pos : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            v2f vert(appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                float d = dot(i.worldPos - _BlackPlanePosition, _BlackPlaneNormal);
                if (d < 0) discard; // Behind black plane = invisible
                return _Color;
            }
            ENDCG
        }
    }
}
