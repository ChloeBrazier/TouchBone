// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Shader Tutorials/Unite Tutorial Shader"
{
	Properties
	{
		_MainTexture("Main Texture (Test)", 2D) = "white" {}
		_MainColor("Color", Color) = (1,1,1,1)
	}
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment fragmentFunction

			#include "UnityCG.cginc"

			//vertices
			//normals
			//color
			//uvs
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			//Vertex Function (build things)
			v2f vert(appdata IN)
			{
				v2f OUT;

				OUT.position = UnityObjectToClipPos(IN.vertex);
				OUT.uv = IN.uv;

				return OUT;
			}

			float4 _Color;
			sampler2D _MainTexture;

			//Fragment Function (color it in)
			fixed4 fragmentFunction(v2f IN) : SV_Target
			{
				float4 textureColor = tex2D(_MainTexture, IN.uv);
				return textureColor * _Color;
			}

			ENDCG
		}
	}
}
