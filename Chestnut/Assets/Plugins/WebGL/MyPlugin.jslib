mergeInto(LibraryManager.library, {

    JSPopUp: function (str) {
        window.alert(Pointer_stringify(str));
    },

    HelloString: function (str) {
        window.alert();
    },

    PrintFloatArray: function (array, size) {
        for (var i = 0; i < size; i++)
            console.log(HEAPF32[(array >> 2) + size]);
    },

    AddNumbers: function (x, y) {
        return x + y;
    },

    GetName: function () {
        
        var returnStr = localStorage.getItem('Name');
        var buffer = _malloc(lengthBytesUTF8(returnStr) + 1);
        stringToUTF8(returnStr, buffer,lengthBytesUTF8(returnStr) + 1);
        return buffer;
    },

    BindWebGLTexture: function (texture) {
        GLctx.bindTexture(GLctx.TEXTURE_2D, GL.textures[texture]);
    }

});