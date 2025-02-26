using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DuelingMonsters;
public class DuelMonsters
{
    public string Name { get; init; }
    public int Attack { get; init; }
    public int Defense { get; init; }
    public string ImageFile { get; init; }
    public int XSize { get; init; }
    public int YSize { get; init; }


    public DuelMonsters(string name, int attack, int defense, string imageFile, int xSize, int ySize)
    {
        Name = name;
        Attack = attack;
        Defense = defense;
        ImageFile = imageFile;
        XSize = xSize;
        YSize = ySize;        

    }

}
