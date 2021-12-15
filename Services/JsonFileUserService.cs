using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Absence.Models;
using Microsoft.AspNetCore.Hosting;

namespace Absence.Services
{
    public class JsonFileUserService
    {
        public IWebHostEnvironment WebHostEnvironment { get;}

        public JsonFileUserService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Users.json"); }
        }

        public IEnumerable<User> GetJsonUsers()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<User[]>(jsonFileReader.ReadToEnd());
            }
        }

        public void SaveJsonUsers(List<User> users)
        {
            using (var jsonFileWriter = File.Create(JsonFileName))
            {
                var jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<User[]>(jsonWriter, users.ToArray());
            }
        }
    }
}
