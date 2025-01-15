Shader "Custom/ScanlineEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ScanlineIntensity ("Scanline Intensity", Range(0, 1)) = 0.5
        _ScanlineFrequency ("Scanline Frequency", Range(0, 1000)) = 300
    }
    SubShader
    {
        Tags { "Queue"="Overlay" "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _ScanlineIntensity;
            float _ScanlineFrequency;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Sample the original screen color
                fixed4 col = tex2D(_MainTex, i.uv);
                
                // Add scanlines based on the UV y-coordinate
                float scanline = abs(sin(i.uv.y * _ScanlineFrequency)) * _ScanlineIntensity;
                
                // Blend the scanlines with the original color
                col.rgb -= scanline;

                // Ensure color stays within valid range
                col.rgb = saturate(col.rgb);

                return col;
            }
            ENDCG
        }
    }
}
