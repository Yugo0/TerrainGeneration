Shader "Custom/TerrainShader"
{
	Properties
	{
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Color ("Color", color) = (1, 1, 1, 0)
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 200

		Pass
		{
			Tags { "LightMode" = "ForwardBase" }

			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			uniform float4 _LightColor0;
			uniform float4 _Color;
			uniform float Top;
			uniform float Bottom;

			struct appdata
			{
				float4 position: POSITION;
				float3 normal: NORMAL;
			};

			struct v2f
			{
				float4 position: SV_POSITION;
				float3 worldNormal: TEXCOORD0;
				float4 pos: TEXCOORD1;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.position = UnityObjectToClipPos(v.position);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.pos = v.position;
				return o;
			}

			fixed4 frag(v2f i): SV_Target
			{
				float hue;
				if (Top == Bottom)
				{
					hue = 0;
				}
				else
				{
					hue = (i.pos.y - Bottom) / (Top - Bottom) * 0.85;
				}

				float R = abs(hue * 6 - 3) - 1;
				float G = 2 - abs(hue * 6 - 2);
				float B = 2 - abs(hue * 6 - 4);

				float3 color = float3(R, G, B);

				float3 normal = normalize(i.worldNormal);
				float3 light = normalize(_WorldSpaceLightPos0.xyz);
				float3 view = normalize(_WorldSpaceCameraPos - i.position.xyz);

				float3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb * color.rgb;

				float3 diffuse = _LightColor0.rgb * color.rgb * max(0, dot(normal, light));
				
				return float4(ambient + diffuse, 1);
			}

			ENDCG
		}
	}
	FallBack "Diffuse"
}
