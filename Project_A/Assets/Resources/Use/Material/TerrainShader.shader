Shader "Custom/TerrainShader"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}      
        _MainTex2 ("Albedo (RGB)", 2D) = "white" {}
    
        _BumpText("Bumped", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert
        

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _MainTex2;
        sampler2D _BumpTex;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MainTex2;
            float2 uv_BumpTex;

            float4 color : COLOR;

            
        };


        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            fixed4 d = tex2D(_MainTex2, IN.uv_MainTex2);

            fixed3 n = UnpackNormal(tex2D(_BumpTex, IN.uv_BumpTex));

            o.Albedo = lerp(c.rgb, d.rgb, IN.color.r);
            
            o.Normal = n;

            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
