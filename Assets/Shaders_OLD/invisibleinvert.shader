Shader "Custom/StencilMask"
{
    Properties
    {
        _Color ("Color", Color) = (0,0,0,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            Stencil
            {
                Ref 2
                Comp Always
                Pass Replace
            }

            ZWrite Off
            ColorMask RGBA // Don't actually draw anything
        }
    }
}
