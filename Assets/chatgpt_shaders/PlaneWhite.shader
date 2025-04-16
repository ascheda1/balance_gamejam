Shader "Custom/PlaneWhite"
{
    SubShader
    {
        Tags { "Queue"="Geometry+1" }
        Pass
        {
            Stencil
            {
                Ref 1
                Comp Always
                Pass Replace
            }
            ColorMask 0
        }
    }
}