using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
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

        public async Task<List<Shape>> LoadShapes(string path)
        {
            List<Shape> loadedShapes = new List<Shape>();
            var content = await File.ReadAllTextAsync(path);
            var dtos = JsonConvert.DeserializeObject<List<Shape.ShapeDTO>>(content);
            foreach (var dto in dtos)
            {
                Type typ = dto.type;
                var shape = Activator.CreateInstance(typ, dto) as Shape;
                loadedShapes.Add(shape);
            }
            return loadedShapes;
        }

        public void CopyDllToAppFolder(string path, string filename)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            var newPath = Path.Combine(appDataPath, "ShapesDrawing4ITC" , filename);
            Debug.WriteLine(newPath);
            File.Copy(path, newPath, true);
        }
    }
}
