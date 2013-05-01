Shader "Solid Color" {

	Properties {
	    _Color ("Color", Color) = (61,111,109)
	}
	
	SubShader {
	    Color [_Color]
	    Pass {}
	} 

}