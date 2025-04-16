Shader "Custom/PlaneAStencil"
{
    SubShader
    {
        Tags { "Queue" = "Geometry+1" }

        Pass
        {
            Stencil
            {
                Ref 1
                Comp Always
                Pass Replace
            }

            ZWrite Off
            ColorMask 0
        }
    }
}
