using System;
using System.Text;
using OpenTK.Graphics.OpenGL4;

namespace BlockCSharp.OpenGLAdditions
{
    public class Shader
    {
        public void Create(ShaderType shaderType, string source)
        {
            _id = GL.CreateShader(shaderType);

            GL.ShaderSource(_id, source);

            GL.CompileShader(_id);

            int[] infoLogLength = new int[1];
            
            GL.GetShader(_id, ShaderParameter.InfoLogLength, infoLogLength);

            if (infoLogLength[0] > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.EnsureCapacity(infoLogLength[0]);

                int lenght = 0;
                
                GL.GetShaderInfoLog(_id, infoLogLength[0], out lenght, stringBuilder);
                
                Console.WriteLine(stringBuilder);
            }
        }

        public void Delete()
        {
            GL.DeleteShader(_id);
            _id = 0;
        }

        /// <summary>
        /// The OpenGL shader object.
        /// </summary>
        private int _id;

        /// <summary>
        /// Gets the shader object.
        /// </summary>
        public int Id
        {
            get { return _id; }
        }
    }    
}
