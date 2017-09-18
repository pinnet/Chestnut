﻿ Shader "Unlit/Outline"
{
	Properties
	{
		_Color("Main Colour", Color) = (0.5,0.5,0.5,1)
		_MainTex ("Texture", 2D) = "white" {}
		_OutlineColor("Outline Colour",Color) = (0,0,0,1)
		_OutlineWidth("Outline Width",Range(1.0,5.0)) = 1.01
		
	}

	CGINCLUDE
	#include "UnityCG.cginc"
	struct appdata 
	{
		float4 vertex : POSITION;
		float3 normal : NORMAL;

	};
	 
	struct v2f 
	{
		float4 pos : POSITION;
		float4 color : COLOR;
		float3 normal : NORMAL;

	};

	float  _OutlineWidth;
	float4 _OutlineColor;

	v2f vert(appdata v) 
	{
	
		v.vertex.xyz *= _OutlineWidth;

		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		//o.color = _OutlineColor;
		return o;
	
	}


	ENDCG


	SubShader
	{
		Pass 
		{
			ZWrite Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			half4 frag(v2f i) : COLOR
			{ 
				return _OutlineColor;
			}
			
			ENDCG

		}

		Pass
		{
			ZWrite On

			Material
			{
				Diffuse[_Color]
				Ambient[_Color]
			}
				
			Lighting On

			SetTexture[_MainTex]
			{
				ConstantColor[_Color]
			}

			SetTexture[_MainTex]
			{
				Combine previous * primary DOUBLE
			}

		}
	}
}
