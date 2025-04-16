Shader "Custom/invert"
{
    Properties 
	{
		_Color ("Tint Color", Color) = (1,1,1,1)
	}
	
	SubShader 
	{
		Tags { "Queue"="Transparent" }

		Pass
		{
		   ZWrite On
		   ColorMask 0
		}

        // Inversion pass
        Pass
		{ 
        Stencil
		{
			Ref 1
			Comp NotEqual
			Pass Keep
		}

        Blend OneMinusDstColor OneMinusSrcAlpha //invert blending, so long as FG color is 1,1,1,1
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

fragmentInput vert( vertexInput i )
{
	fragmentInput o;
	o.pos = UnityObjectToClipPos(i.vertex);
	o.color = _Color;
	return o;
}

half4 frag( fragmentInput i ) : COLOR
{
	return i.color;
}
ENDCG
}
}
}
