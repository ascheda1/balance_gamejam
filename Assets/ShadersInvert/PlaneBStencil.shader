Shader "Custom/PlaneBStencil"
{
    SubShader
    {
        Tags { "Queue" = "Geometry+1" }

        Pass
        {
            Stencil
            {
                Ref 2
                Comp Always
                Pass Replace
            }

            ZWrite Off
            ColorMask 0
        }
    }
}
