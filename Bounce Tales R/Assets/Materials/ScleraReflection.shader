Shader "Custom/SpriteLitWithReflection" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _ReflectionTex ("Reflection Texture", 2D) = "white" {}
        _ReflectionIntensity ("Reflection Intensity", Range(0,1)) = 0.5
    }
    SubShader {
        Tags { "Queue"="Transparent" "RenderType"="Opaque" }
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            sampler2D _ReflectionTex;
            float _ReflectionIntensity;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                float4 col = tex2D(_MainTex, i.uv);
                float3 worldPos = i.worldPos;
                float3 viewDir = normalize(UnityWorldSpaceViewDir(worldPos));
                float3 reflectionDir = reflect(viewDir, normalize(worldPos));
                float4 reflectionColor = tex2D(_ReflectionTex, reflectionDir.xy);
                float4 finalColor = lerp(col, reflectionColor, _ReflectionIntensity);
                return finalColor;
            }
            ENDCG
        }
    }
    FallBack "Sprite/Lit-Default"
}
