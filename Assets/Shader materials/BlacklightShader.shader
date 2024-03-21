Shader "Custom/BlacklightShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _LightPosition ("Light Position", Vector) = (0,0,0,0) //*Light position is important because in VR light and camera positions are different.
        _LightDirection ("Light Direction", Vector) = (0,0,1,0) //*Defaulted to be down the z-axis.
        _LightAngle ("Light Angle", Range(0,180)) = 45 //*The angle of our light in degrees.
        _StrengthScale ("Strength Scale", float) = 50 //*Added to scale the strength in the clamp calculations.
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alpha

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos; //*Gets the world position of the fragment
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        float4 _LightPosition; //*Gets the position of our light.
        float4 _LightDirection; //*Gets the direction of our light.
        float _LightAngle; //*Gets the angle of our light.
        float _StrengthScale; //*Gets the strength scale.

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float3 direction = normalize(_LightPosition - IN.worldPos); //*Normalize the direction towards the "LightPosition - worldPos" to get direction towards fragment.
            float scale = dot(direction, _LightDirection); //*Takes the dot product between the direction our light is facing and direction towards whatever fragment we are at. With this we should be able to figure out in where things are in relation to our light.
            float strength = scale - cos(_LightAngle * (6.28 / 360.0));  //*Converts the angle radians and then to a vector. When angle is 0 only things in front is illuminated
            strength = min(max(strength * _StrengthScale, 0), 1); //*Clamps the min-max to between 0-1. 
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb * strength;
            o.Emission = c.rgb * c.a * strength; //*Adds emission so if wanted we can make it bloom
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness; 
            o.Alpha = strength * c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}