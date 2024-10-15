using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MalovaniQQ_4ITC_QQMore
{
    public class SaveLoadManager
    {
        public async Task SaveShapes(string path, List<Shape> shapes, Action callback)
        {
            string content = JsonConvert.SerializeObject(shapes.Select(s => s.GetDTO()).ToList());
            await Task.Delay(4000);
            await File.WriteAllTextAsync(path, content);
            callback();
        }

        public async Task<List<Shape>> LoadShapes(string path, Dictionary<string, Assembly> assies = null)
        {
            List<Shape> loadedShapes = new List<Shape>();
            var content = await File.ReadAllTextAsync(path);

            var dtos = JsonConvert.DeserializeObject<List<Shape.ShapeDTO>>(content);
            foreach (var dto in dtos)
            {
                Type typ = Type.GetType(dto.type);
                if(!dto.type.StartsWith("MalovaniQQ_4ITC_QQMore"))
                {
                    if(!assies.ContainsKey(dto.type))
                    {
                        throw new Exception("Saved shape was not recognized :(");
                    }
                    typ = assies[dto.type].GetType(dto.type);
                }
                var shape = Activator.CreateInstance(typ, dto) as Shape;
                loadedShapes.Add(shape);
            }
            return loadedShapes;
        }

        public void CopyDllToAppFolder(string path, string filename)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            var dirPath = Path.Combine(appDataPath, "ShapesDrawing4ITC");
            if(!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            var dllPath = Path.Combine(dirPath, filename);
            Debug.WriteLine(dllPath);

            File.Copy(path, dllPath, true);
        }

        public List<Assembly> GetAssembliesFromAppDataFolder()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var dirPath = Path.Combine(appDataPath, "ShapesDrawing4ITC");
            
            if (!Directory.Exists(dirPath))
                return new List<Assembly>();

            var dlls = Directory.GetFiles(dirPath, "*.dll").ToList();
            var assies = dlls.Select(dll => Assembly.LoadFile(dll));

            return assies.ToList();
        }
    }
}
