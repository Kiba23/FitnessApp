using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controller
{
    public abstract class ControllerBase
    {
        protected void Save(string filename, object itemToSerialize) // Serialization to bin file. It will be used in DI in the future
        {
            if (filename.Length > 0 && filename.IndexOfAny(Path.GetInvalidFileNameChars()) < 0)
            {
                var binFormattor = new BinaryFormatter();

                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    binFormattor.Serialize(fs, itemToSerialize);
                }
            }
            else throw new FileNotFoundException("Wrong file.", nameof(filename));
        }

        protected T Load<T>(string filename)
        {
            if (filename.Length > 0 && filename.IndexOfAny(Path.GetInvalidFileNameChars()) < 0)
            {
                var binFormattor = new BinaryFormatter();

                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    if (fs.Length > 0)
                    {
                        if (binFormattor.Deserialize(fs) is T items)
                            return items;
                        else
                            return default(T);
                    }
                    else
                    {
                        return default(T);
                    }
                }
            }
            else throw new FileNotFoundException("Wrong file.", nameof(filename));
        }
    }
}
