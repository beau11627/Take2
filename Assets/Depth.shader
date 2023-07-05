Shader "Custom/DistanceColorShader"
{
    Properties
    {
        _Color ("Base Color", Color) = (1, 0, 0, 1)
        _MinDistance ("Minimum Distance", Range(0, 100)) = 0
        _MaxDistance ("Maximum Distance", Range(0, 100)) = 10
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        fixed4 _Color;
        float _MinDistance;
        float _MaxDistance;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            float distance = length(IN.worldPos - _WorldSpaceCameraPos.xyz);
            float t = saturate((distance - _MinDistance) / (_MaxDistance - _MinDistance));
            fixed4 color = lerp(_Color, fixed4(0, 0, 1, 1), t);
            o.Albedo = color.rgb;
            o.Alpha = color.a;
        }
        ENDCG
    }

    FallBack "Diffuse"
}