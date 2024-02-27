Shader "Custom/Shader" 
{
	Properties 
	{
		_MainTex ("Texture", 2D) = ""{}
		_Level ("Level", int) = 4
	}


	SubShader 
		{
		Pass 
			{
			CGPROGRAM
			#include "UnityCG.cginc"
			#pragma vertex vert_img
			#pragma fragment frag

			sampler2D _MainTex;
			int _Level;

			half4 frag (v2f_img i): COLOR
			{
				half4 c = tex2D(_MainTex, i.uv);
				// 階調化
				c.rgb = floor(c * _Level) / _Level;
				return c;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}