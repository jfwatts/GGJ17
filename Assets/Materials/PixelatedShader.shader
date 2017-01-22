Shader "Custom/PixelatedShader" {
	Properties{
		_MainTex("Texture", 2D) = "white" {}
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		CGPROGRAM
#pragma surface surf SimpleLambert


	struct Input {
		float2 uv_MainTex;
		float3 worldPos;
	};

	sampler2D _MainTex;

	uniform int _gNumPulses = 0;

	uniform float4 _gPulseCenters[50];
	uniform float _gPulseRadiuses[50];
	uniform float _gPulseDecayPower[50];
	uniform int _gLightsOn = 0;
	uniform int _gNumCircles = 3;

	half4 LightingSimpleLambert(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten) {
		half NdotL = dot(round(s.Normal), lightDir);
		half4 c;
		c.rgb = s.Albedo.rgb;
		if (_gLightsOn > 0) {
			c.rgb = fixed3(1, 1, 1) * _LightColor0.rgb * (NdotL * atten);
		}
		
		return c;
	}

	void surf(Input IN, inout SurfaceOutput o) {
		o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
		o.Albedo = float3(0, 0, 0);
		
		for (int i = 0; i < _gNumPulses; i++) {
			float l = length(IN.worldPos - _gPulseCenters[i]);
			float r = _gPulseRadiuses[i];
			float c = 0;

			if (r > 0) {
				c = min(l / pow(r, _gPulseDecayPower[i]), 1.0);
			}

			if (l > r * 0.9 && l < r && _gNumCircles >= 1) {
				o.Albedo = float3(c, c, c);
			}

			if (l > r * 0.7 && l < r * 0.8 && _gNumCircles >= 2) {
				o.Albedo = float3(c, c, c);
			}

			if (l > r * 0.5 && l < r * 0.6 && _gNumCircles >= 3) {
				o.Albedo = float3(c, c, c);
			}

			if (l > r * 0.3 && l < r * 0.4 && _gNumCircles >= 4) {
				o.Albedo = float3(c, c, c);
			}

			if (l > r * 0.1 && l < r * 0.2 && _gNumCircles >= 5) {
				o.Albedo = float3(c, c, c);
			}
		}

	}
	ENDCG
	}
		Fallback "Diffuse"
}