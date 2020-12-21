using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using MagusAppGateway.Gateway.Models;
using System.Text;
using Newtonsoft.Json;

namespace MagusAppGateway.Gateway
{
    public static class OcelotConfigJsonToModel
    {

        public static OcelotConfigModel OcelotConfigJsonCoverToModel()
        {
            string json = GetFileJson("ocelot.json");
            var model = JsonConvert.DeserializeObject<OcelotConfigModel>(json);
            return model;
        }

        private static string GetFileJson(string filepath)
        {
            string json = string.Empty;
            using (FileStream fs = new FileStream(filepath, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    json = sr.ReadToEnd().ToString();
                }
            }
            return json;
        }
    }
}
