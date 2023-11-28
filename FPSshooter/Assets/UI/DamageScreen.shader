Shader "Custom/CenterFadeShader"
{
    Properties
    {
        _Color("Main Color", Color) = (1, 1, 1, 1)
        _MainTex("Base (RGB)", 2D) = "white" { }
    }

        SubShader
    {
        Tags {"Queue" = "Overlay" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma exclude_renderers gles xbox360 ps3
            ENDCG

            CGPROGRAM
            #pragma fragment frag
            fixed4 frag(v2f i) : COLOR
            {
            // Ekran�n ortas�ndan d��ar� do�ru opakl��� artan bir gradient olu�tur
            float distance = length(i.uv - 0.5);
            float alpha = 1.0 - smoothstep(0.4, 0.5, distance);
            return _Color * alpha;
        }
        ENDCG
    }
    }
}
