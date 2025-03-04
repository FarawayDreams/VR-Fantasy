// Simplified Diffuse shader. Differences from regular Diffuse one:
// - no Main Color
// - fully supports only 1 directional light. Other lights can affect it, but it will be per-vertex/SH.

Shader "Mobile/Transparent Diffuse Double Sided" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_Cutoff ("Alpha cutoff", Range (0,1)) = 0.5
}
SubShader {
	Tags { "RenderType"="Transparent" "Queue"="Transparent" }
	LOD 150
	Cull Off
	Ztest LEqual
	//Blend SrcAlpha OneMinusSrcAlpha
	AlphaTest Greater [_Cutoff]
	//ZWrite On

CGPROGRAM
#pragma surface surf Lambert noforwardadd

sampler2D _MainTex;

struct Input {
	float2 uv_MainTex;
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
	
	o.Albedo = c.rgb;
	o.Alpha = c.a;
}
ENDCG
}

Fallback "Mobile/VertexLit"
}
