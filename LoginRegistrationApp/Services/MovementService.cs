using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WODWarriors.Services;
public class MovementService
{
    List<Movement> grindList = new();
    public async Task<List<Movement>> GetProducts(string file)
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync(file);
        using var reader = new StreamReader(stream);
        var content = await reader.ReadToEndAsync();
        grindList = JsonSerializer.Deserialize<List<Movement>>(content);

        return grindList;
    }
}
