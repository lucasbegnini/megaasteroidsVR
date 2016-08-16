Shader "BeeShaders/Reticle"
{
	Properties
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Sprite Texture", 2D) = "white" {}
		_AlphaScale ("Alpha scale", 2D) = "White" {}
		_Fator ("Fator", Range (-1, 1)) = 1.0
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue" = "Transparent" "IgnoreProjector"="true" }

		Pass
		{
			AlphaToMask On

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			//#pragma multi_compile_fog
			
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
			sampler2D _AlphaScale;
			float _Fator;
			float4 _Color;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				float4 col = tex2D(_MainTex, i.uv) * _Color;

				if(col.a < 0.1f)
					return col;

				col.a = tex2D(_AlphaScale, i.uv).a + _Fator;

				return col;
			}
			ENDCG
		}
	}
}
