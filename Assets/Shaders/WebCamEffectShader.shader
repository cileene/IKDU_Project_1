Shader "Custom/WebCamEffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Tint ("Tint", Color) = (1,1,1,1)
        _Brightness ("Brightness", Range(0, 2)) = 1
        _Opacity ("Opacity", Range(0, 1)) = 1
        _BlurSize ("Blur Size", Range(0, 10)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
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
            float4 _MainTex_ST;
            float4 _Tint;
            float _Brightness;
            float _Opacity;
            float _BlurSize;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

                // Apply Gaussian blur
                if (_BlurSize > 0)
                {
                    float2 uvOffset = _BlurSize / _ScreenParams.xy;
                    col = tex2D(_MainTex, i.uv) * 0.2270270270;
                    col += tex2D(_MainTex, i.uv + uvOffset) * 0.1945945946;
                    col += tex2D(_MainTex, i.uv - uvOffset) * 0.1945945946;
                    col += tex2D(_MainTex, i.uv + uvOffset * 2.0) * 0.1216216216;
                    col += tex2D(_MainTex, i.uv - uvOffset * 2.0) * 0.1216216216;
                    col += tex2D(_MainTex, i.uv + uvOffset * 3.0) * 0.0540540541;
                    col += tex2D(_MainTex, i.uv - uvOffset * 3.0) * 0.0540540541;
                }

                // Apply tint
                col.rgb *= _Tint.rgb;

                // Apply brightness
                col.rgb *= _Brightness;

                // Apply opacity
                col.a *= _Opacity;

                return col;
            }
            ENDCG
        }
    }
}