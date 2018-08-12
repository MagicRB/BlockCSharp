using System;
using System.Text;
using OpenGL;

namespace BlockCSharp.OpenGLAdditions
{
    public class Shader
    {
        public void Create(ShaderType shaderType, string source)
        {
            _id = Gl.CreateShader(shaderType);

            Gl.ShaderSource(_id, new [] {source});

            Gl.CompileShader(_id);

            int[] infoLogLength = new int[1];
            
            Gl.GetShader(_id, ShaderParameterName.InfoLogLength, infoLogLength);

            if (infoLogLength[0] > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.EnsureCapacity(infoLogLength[0]);

                int lenght = 0;
                
                Gl.GetShaderInfoLog(_id, infoLogLength[0], out lenght, stringBuilder);
                
                Console.WriteLine(stringBuilder);
            }
        }

        public void Delete()
        {
            Gl.DeleteShader(_id);
            _id = 0;
        }

        /// <summary>
        /// The OpenGL shader object.
        /// </summary>
        private uint _id;

        /// <summary>
        /// Gets the shader object.
        /// </summary>
        public uint Id
        {
            get { return _id; }
        }
    }    
}
