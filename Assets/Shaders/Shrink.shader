Shader "Aus/GlowShader"
{
	Properties
	{
	}
		SubShader
	{
		Pass
	{
		CGPROGRAM

#pragma vertex vert
#pragma fragment frag
#pragma target 3.0

#include "UnityCG.cginc"
		float rand(float2 co)
	{
		return frac((cos(dot(co.xy , float2(12.345 *  _Time.w, 67.890 *  _Time.w))) * 12345.67890 + _Time.w));
	}

	struct vertexInput
	{
		float4 vertex : POSITION;
		float4 texcoord0 : TEXCOORD0;
		float4 texcoord2 : TEXCOORD2;
	};

	struct fragmentInput
	{
		float4 position : SV_POSITION;//SV_POSITION
		float4 texcoord0 : TEXCOORD0;
		float4 camDist : TEXCOORD2;
	};

	fragmentInput vert(vertexInput i)
	{

		fragmentInput o;
		UNITY_INITIALIZE_OUTPUT(fragmentInput, o);
		o.position = mul(UNITY_MATRIX_MVP, i.vertex);
		o.texcoord0 = i.texcoord0;
		float4 modelOrigin = mul(unity_ObjectToWorld, float4(0.0, 0.0, 0.0, 1.0));
		o.camDist.x = distance(_WorldSpaceCameraPos.xyz, modelOrigin.xyz);
		o.camDist.x = lerp(1.0, o.camDist.x, 0);
		return o;

	}

	
	fixed4 frag(float4 screenPos : SV_POSITION, fragmentInput i) : SV_Target
	{

	fixed4 sc = fixed4((screenPos.xy), 0.0, 5.0);
	sc *= 0.001;
	sc.xy -= 0.5;
	sc.xy *= i.camDist.xx;
	sc.xy += 0.5;
	sc.x = round(sc.x*0.1) / 0.1;
	sc.y = round(sc.y*0.1) / 0.1;
	float noise = rand(sc.xy);
	float4 stat = lerp((1, 0, 1, 0), (0, 1, 0, 1), noise.x);
	return fixed4(stat.xyz, 8.0);
	}
		ENDCG
	}
	}
}﻿