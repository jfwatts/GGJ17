Shader "Custom/PixelatedShader" {
	Properties{
		_MainTex("Texture", 2D) = "white" {}
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		CGPROGRAM
#pragma surface surf SimpleLambert

	half4 LightingSimpleLambert(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten) {
		half NdotL = dot(round(s.Normal), lightDir);
		half4 c;
		c.rgb = s.Albedo.rgb;
		c.rgb = fixed3 (1,1,1) * _LightColor0.rgb * (NdotL * atten);
		
		return c;
	}

	struct Input {
		float2 uv_MainTex;
		float3 worldPos;
	};

	sampler2D _MainTex;

	uniform int _gNumPulses = 0;

	uniform float4 _gPulseCenters[10];
	uniform float _gPulseRadiuses[10];

	void surf(Input IN, inout SurfaceOutput o) {
		o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
		o.Albedo = float3(0, 0, 0);
		
		for (int i = 0; i < _gNumPulses; i++) {
			float l = length(IN.worldPos - _gPulseCenters[i]);
			float r = _gPulseRadiuses[i];
			if (l > r * 0.9 && l < r) {
				o.Albedo = float3(1, 1, 1);
			}

			if (l > r * 0.7 && l < r * 0.8) {
				o.Albedo = float3(1, 1, 1);
			}
		}

	}
	ENDCG
	}
		Fallback "Diffuse"
}