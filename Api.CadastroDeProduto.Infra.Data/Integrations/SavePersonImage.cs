using ApiCadastroDeProduto.Domain.Integrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Infra.Data.Integrations
{
    public class SavePersonImage : ISavePersonImage
    {
        private readonly string _fillePath;

        public SavePersonImage(string filepath)
        {
            _fillePath = "/Users/User/Desktop/API";
        }

        /// <summary> Método para interpretar qual a extensão do base 64 (png,jpeg,etc) </summary>
        public string Save(string imageBase64)
        {
            var fileExt = imageBase64.Substring(imageBase64.IndexOf("/") + 1, 
                          imageBase64.IndexOf(";") - imageBase64.IndexOf("/")-1); //png ou jpge

            var base64Code = imageBase64.Substring(imageBase64.IndexOf(",") + 1);
            var imgBytes = Convert.FromBase64String(base64Code);

            var fileName = Guid.NewGuid().ToString() + "." + fileExt;
            using(var imageFile = new FileStream(_fillePath+"/"+fileName, FileMode.Create))
            {
                imageFile.Write(imgBytes,0,imgBytes.Length);
                imageFile.Flush();

                return _fillePath+ "/" + fileName;
            }
        }
    }
}
