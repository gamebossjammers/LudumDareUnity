// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.17 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.17;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:0,x:34407,y:31947,varname:node_0,prsc:2|normal-83-RGB,emission-3802-OUT,custl-64-OUT,olwid-5315-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:37,x:33685,y:31995,varname:node_37,prsc:2;n:type:ShaderForge.SFN_Dot,id:40,x:32855,y:32099,varname:node_40,prsc:2,dt:1|A-42-OUT,B-41-OUT;n:type:ShaderForge.SFN_NormalVector,id:41,x:32646,y:32193,prsc:2,pt:True;n:type:ShaderForge.SFN_LightVector,id:42,x:32646,y:32072,varname:node_42,prsc:2;n:type:ShaderForge.SFN_Dot,id:52,x:32855,y:32272,varname:node_52,prsc:2,dt:1|A-41-OUT,B-62-OUT;n:type:ShaderForge.SFN_Add,id:55,x:33872,y:32288,varname:node_55,prsc:2|A-84-OUT,B-187-RGB,C-1966-OUT;n:type:ShaderForge.SFN_Power,id:58,x:33133,y:32523,cmnt:Specular Light,varname:node_58,prsc:2|VAL-52-OUT,EXP-244-OUT;n:type:ShaderForge.SFN_HalfVector,id:62,x:32646,y:32332,varname:node_62,prsc:2;n:type:ShaderForge.SFN_LightColor,id:63,x:33872,y:32155,varname:node_63,prsc:2;n:type:ShaderForge.SFN_Multiply,id:64,x:34056,y:32155,varname:node_64,prsc:2|A-37-OUT,B-63-RGB,C-55-OUT;n:type:ShaderForge.SFN_Color,id:80,x:33368,y:32178,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:0;n:type:ShaderForge.SFN_Tex2d,id:82,x:33368,y:32002,ptovrint:False,ptlb:Diffuse map,ptin:_Diffusemap,varname:_Diffuse,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8993b617f08498f43adcbd90697f1c5d,ntxv:0,isnm:False|UVIN-272-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:83,x:34056,y:31966,ptovrint:False,ptlb:Normal map,ptin:_Normalmap,varname:_Normals,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c6dfb00dbee6bc044a8a3bb22e56e064,ntxv:3,isnm:True|UVIN-272-UVOUT;n:type:ShaderForge.SFN_Multiply,id:84,x:33573,y:32160,cmnt:Diffuse Light,varname:node_84,prsc:2|A-82-RGB,B-80-RGB,C-264-OUT;n:type:ShaderForge.SFN_AmbientLight,id:187,x:33573,y:32281,varname:node_187,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:216,x:33133,y:32423,ptovrint:False,ptlb:Diffuse bands,ptin:_Diffusebands,varname:_Bands,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Slider,id:239,x:32082,y:32731,ptovrint:False,ptlb:Glossiness multiplier,ptin:_Glossinessmultiplier,varname:_GlossMultiplier,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:10,max:50;n:type:ShaderForge.SFN_Add,id:240,x:32722,y:32640,varname:node_240,prsc:2|A-242-OUT,B-243-OUT;n:type:ShaderForge.SFN_Multiply,id:242,x:32554,y:32578,varname:node_242,prsc:2|A-8453-OUT,B-239-OUT;n:type:ShaderForge.SFN_Vector1,id:243,x:32521,y:32778,varname:node_243,prsc:2,v1:1;n:type:ShaderForge.SFN_Exp,id:244,x:32893,y:32640,varname:node_244,prsc:2,et:1|IN-240-OUT;n:type:ShaderForge.SFN_Posterize,id:264,x:33368,y:32339,varname:node_264,prsc:2|IN-395-OUT,STPS-216-OUT;n:type:ShaderForge.SFN_Posterize,id:265,x:33368,y:32475,varname:node_265,prsc:2|IN-58-OUT,STPS-4853-OUT;n:type:ShaderForge.SFN_TexCoord,id:272,x:31870,y:31908,varname:node_272,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:1764,x:31969,y:32296,ptovrint:False,ptlb:Roughness map,ptin:_Roughnessmap,varname:_RoughnessMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8993b617f08498f43adcbd90697f1c5d,ntxv:1,isnm:False|UVIN-272-UVOUT;n:type:ShaderForge.SFN_OneMinus,id:8453,x:32141,y:32412,varname:node_8453,prsc:2|IN-1764-RGB;n:type:ShaderForge.SFN_ValueProperty,id:4853,x:33221,y:32675,ptovrint:False,ptlb:Specular bands,ptin:_Specularbands,varname:_Specular_Bands,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1966,x:33676,y:32781,varname:node_1966,prsc:2|IN-265-OUT,IMIN-8524-OUT,IMAX-1760-OUT,OMIN-8524-OUT,OMAX-8453-OUT;n:type:ShaderForge.SFN_Vector1,id:8524,x:33406,y:32675,varname:node_8524,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:1760,x:33406,y:32772,varname:node_1760,prsc:2,v1:1;n:type:ShaderForge.SFN_RemapRange,id:6877,x:33884,y:31835,cmnt:Frames the light S,varname:node_6877,prsc:2,frmn:0,frmx:1,tomn:0.5,tomx:1|IN-37-OUT;n:type:ShaderForge.SFN_RemapRange,id:395,x:33121,y:32188,varname:node_395,prsc:2,frmn:0,frmx:1,tomn:0.256,tomx:1|IN-479-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5315,x:34056,y:32349,ptovrint:False,ptlb:Outline width,ptin:_Outlinewidth,varname:node_5315,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:479,x:33029,y:32024,varname:node_479,prsc:2|A-6758-OUT,B-40-OUT;n:type:ShaderForge.SFN_Tex2d,id:9571,x:32408,y:31499,ptovrint:False,ptlb:AO map,ptin:_AOmap,varname:node_9571,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-272-UVOUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:6758,x:32840,y:31665,varname:node_6758,prsc:2|IN-9571-RGB,IMIN-9446-OUT,IMAX-5496-OUT,OMIN-4065-OUT,OMAX-5496-OUT;n:type:ShaderForge.SFN_Vector1,id:9446,x:32408,y:31652,varname:node_9446,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:5496,x:32408,y:31705,varname:node_5496,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:2467,x:32251,y:31779,ptovrint:False,ptlb:AO power,ptin:_AOpower,varname:node_2467,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_OneMinus,id:4065,x:32619,y:31779,varname:node_4065,prsc:2|IN-2467-OUT;n:type:ShaderForge.SFN_Tex2d,id:5186,x:34032,y:32584,ptovrint:False,ptlb:Emissive map,ptin:_Emissivemap,varname:_Diffusemap_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8993b617f08498f43adcbd90697f1c5d,ntxv:2,isnm:False|UVIN-272-UVOUT;n:type:ShaderForge.SFN_Multiply,id:3802,x:34196,y:32584,varname:node_3802,prsc:2|A-5186-RGB,B-2950-OUT;n:type:ShaderForge.SFN_Slider,id:2950,x:33875,y:32764,ptovrint:False,ptlb:Emissive power,ptin:_Emissivepower,varname:_Glossinessmultiplier_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:2;proporder:80-82-216-83-1764-4853-239-9571-2467-5315-5186-2950;pass:END;sub:END;*/

Shader "Shader Forge/CelShading" {
    Properties {
        _Color ("Color", Color) = (1,1,1,0)
        _Diffusemap ("Diffuse map", 2D) = "white" {}
        _Diffusebands ("Diffuse bands", Float ) = 4
        _Normalmap ("Normal map", 2D) = "bump" {}
        _Roughnessmap ("Roughness map", 2D) = "gray" {}
        _Specularbands ("Specular bands", Float ) = 4
        _Glossinessmultiplier ("Glossiness multiplier", Range(0, 50)) = 10
        _AOmap ("AO map", 2D) = "white" {}
        _AOpower ("AO power", Range(0, 1)) = 0.5
        _Outlinewidth ("Outline width", Float ) = 0
        _Emissivemap ("Emissive map", 2D) = "black" {}
        _Emissivepower ("Emissive power", Range(0, 2)) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform float _Outlinewidth;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = mul(UNITY_MATRIX_MVP, float4(v.vertex.xyz + v.normal*_Outlinewidth,1));
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                return fixed4(float3(0,0,0),0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _Diffusemap; uniform float4 _Diffusemap_ST;
            uniform sampler2D _Normalmap; uniform float4 _Normalmap_ST;
            uniform float _Diffusebands;
            uniform float _Glossinessmultiplier;
            uniform sampler2D _Roughnessmap; uniform float4 _Roughnessmap_ST;
            uniform float _Specularbands;
            uniform sampler2D _AOmap; uniform float4 _AOmap_ST;
            uniform float _AOpower;
            uniform sampler2D _Emissivemap; uniform float4 _Emissivemap_ST;
            uniform float _Emissivepower;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normalmap_var = UnpackNormal(tex2D(_Normalmap,TRANSFORM_TEX(i.uv0, _Normalmap)));
                float3 normalLocal = _Normalmap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float4 _Emissivemap_var = tex2D(_Emissivemap,TRANSFORM_TEX(i.uv0, _Emissivemap));
                float3 emissive = (_Emissivemap_var.rgb*_Emissivepower);
                float4 _Diffusemap_var = tex2D(_Diffusemap,TRANSFORM_TEX(i.uv0, _Diffusemap));
                float4 _AOmap_var = tex2D(_AOmap,TRANSFORM_TEX(i.uv0, _AOmap));
                float node_9446 = 0.0;
                float node_5496 = 1.0;
                float node_4065 = (1.0 - _AOpower);
                float4 _Roughnessmap_var = tex2D(_Roughnessmap,TRANSFORM_TEX(i.uv0, _Roughnessmap));
                float3 node_8453 = (1.0 - _Roughnessmap_var.rgb);
                float node_8524 = 0.0;
                float3 node_64 = (attenuation*_LightColor0.rgb*((_Diffusemap_var.rgb*_Color.rgb*floor((((node_4065 + ( (_AOmap_var.rgb - node_9446) * (node_5496 - node_4065) ) / (node_5496 - node_9446))*max(0,dot(lightDirection,normalDirection)))*0.744+0.256) * _Diffusebands) / (_Diffusebands - 1))+UNITY_LIGHTMODEL_AMBIENT.rgb+(node_8524 + ( (floor(pow(max(0,dot(normalDirection,halfDirection)),exp2(((node_8453*_Glossinessmultiplier)+1.0))) * _Specularbands) / (_Specularbands - 1) - node_8524) * (node_8453 - node_8524) ) / (1.0 - node_8524))));
                float3 finalColor = emissive + node_64;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _Diffusemap; uniform float4 _Diffusemap_ST;
            uniform sampler2D _Normalmap; uniform float4 _Normalmap_ST;
            uniform float _Diffusebands;
            uniform float _Glossinessmultiplier;
            uniform sampler2D _Roughnessmap; uniform float4 _Roughnessmap_ST;
            uniform float _Specularbands;
            uniform sampler2D _AOmap; uniform float4 _AOmap_ST;
            uniform float _AOpower;
            uniform sampler2D _Emissivemap; uniform float4 _Emissivemap_ST;
            uniform float _Emissivepower;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normalmap_var = UnpackNormal(tex2D(_Normalmap,TRANSFORM_TEX(i.uv0, _Normalmap)));
                float3 normalLocal = _Normalmap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _Diffusemap_var = tex2D(_Diffusemap,TRANSFORM_TEX(i.uv0, _Diffusemap));
                float4 _AOmap_var = tex2D(_AOmap,TRANSFORM_TEX(i.uv0, _AOmap));
                float node_9446 = 0.0;
                float node_5496 = 1.0;
                float node_4065 = (1.0 - _AOpower);
                float4 _Roughnessmap_var = tex2D(_Roughnessmap,TRANSFORM_TEX(i.uv0, _Roughnessmap));
                float3 node_8453 = (1.0 - _Roughnessmap_var.rgb);
                float node_8524 = 0.0;
                float3 node_64 = (attenuation*_LightColor0.rgb*((_Diffusemap_var.rgb*_Color.rgb*floor((((node_4065 + ( (_AOmap_var.rgb - node_9446) * (node_5496 - node_4065) ) / (node_5496 - node_9446))*max(0,dot(lightDirection,normalDirection)))*0.744+0.256) * _Diffusebands) / (_Diffusebands - 1))+UNITY_LIGHTMODEL_AMBIENT.rgb+(node_8524 + ( (floor(pow(max(0,dot(normalDirection,halfDirection)),exp2(((node_8453*_Glossinessmultiplier)+1.0))) * _Specularbands) / (_Specularbands - 1) - node_8524) * (node_8453 - node_8524) ) / (1.0 - node_8524))));
                float3 finalColor = node_64;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #include "UnityCG.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform sampler2D _Emissivemap; uniform float4 _Emissivemap_ST;
            uniform float _Emissivepower;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
/////// Vectors:
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 _Emissivemap_var = tex2D(_Emissivemap,TRANSFORM_TEX(i.uv0, _Emissivemap));
                o.Emission = (_Emissivemap_var.rgb*_Emissivepower);
                
                float3 diffColor = float3(0,0,0);
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
