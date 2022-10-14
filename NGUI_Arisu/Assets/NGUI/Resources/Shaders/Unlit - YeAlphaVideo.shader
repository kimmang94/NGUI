Shader "Matte/Ye_AlphaVideo"
{

	Properties{
	   _MainTex("Base (RGB)", 2D) = "white" {}
	   _Matte("Matte Color", Color) = (1,0,1,1)
	   _Thresh("Threshold", Range(0,1)) = 0.0
	   _Cutoff("Cutoff", Range(0,1)) = .5
	}

		SubShader{

		   Pass {
			  AlphaTest Less[_Cutoff]
		CGPROGRAM
		#pragma fragment frag
		#include "UnityCG.cginc"

		struct v2f {
			float4 pos : POSITION;
			float4 uv : TEXCOORD0;
		};

		sampler2D _MainTex;
		uniform half4 _Matte;
		uniform float _Thresh;
		uniform float _Cutoff;

		half4 frag(v2f i) : COLOR
		{
			//return _Matte;
			half4 color = tex2D(_MainTex, i.uv.xy);

			half3 keyMinus = half3((_Matte.r - _Thresh), (_Matte.g - _Thresh), (_Matte.b - _Thresh));
			half3 keyPlus = half3((_Matte.r + _Thresh), (_Matte.g + _Thresh), (_Matte.b + _Thresh));

			if (((color.r > keyMinus.r)  (color.r < keyPlus.r))  ((color.g > keyMinus.g)  (color.g < keyPlus.g))  ((color.b > keyMinus.b)  (color.b < keyPlus.b)))
			{
				return _Cutoff;
			}

			return float4(color.rgb, max(0, _Cutoff - 0.01));
		}

		ENDCG
			  } // pass
	   } // subshader
	   //Fallback "Transparent/Diffuse"
} // shader