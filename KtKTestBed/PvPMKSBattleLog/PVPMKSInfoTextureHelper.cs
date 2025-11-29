using System.Numerics;
using KamiToolKit.Classes;
using KamiToolKit.Nodes;

namespace KtKTestBed.PvPMKSBattleLog;

public class PVPMKSInfoTextureHelper
{
    private static readonly string Tex = "ui/uld/PVPMKSInfo.tex"; 
    private static readonly string TexJob = "ui/uld/PVPClassJobIcon.tex"; 
    public static unsafe void LoadPvPClassJobIcon(ImageNode node)
    {
        //todo validate
        for (var i = 0; i < 31; i++)
        {
            var column = i % 5;
            var row = i / 5;
            var textureCoords = new Vector2(column * 56, row * 56);

            node.AddPart(new Part
            {
                Id = (uint) i, 
                TexturePath = TexJob, 
                TextureCoordinates = textureCoords,
                Size = new Vector2(56, 56)
            });
        }
    }
    public static unsafe void LoadPvPScreenInformation(ImageNode node) {
        node.AddPart(new Part {
            Id = 0, TexturePath = Tex, TextureCoordinates = new Vector2(0, 0), 
            Size = new Vector2(40,40)
        });
        node.AddPart(new Part {
            Id = 1, TexturePath = Tex, TextureCoordinates = new Vector2(40, 0), 
            Size = new Vector2(40,40),
        });
        node.AddPart(new Part {
            Id = 2, TexturePath = Tex, TextureCoordinates = new Vector2(80, 0), 
            Size = new Vector2(40,40),
        });
        node.AddPart(new Part {
            Id = 3, TexturePath = Tex, TextureCoordinates = new Vector2(120, 0), 
            Size = new Vector2(40,40),
        });
        node.AddPart(new Part {
            Id = 4, TexturePath = Tex, TextureCoordinates = new Vector2(0, 40), 
            Size = new Vector2(40,40),
        });
        node.AddPart(new Part {
            Id = 5, TexturePath = Tex, TextureCoordinates = new Vector2(40, 40), 
            Size = new Vector2(40,40),
        });
        node.AddPart(new Part {
            Id = 6, TexturePath = Tex, TextureCoordinates = new Vector2(80, 40), 
            Size = new Vector2(40,40),
        });
        node.AddPart(new Part {
            Id = 7, TexturePath = Tex, TextureCoordinates = new Vector2(160, 0), 
            Size = new Vector2(52,52),
        });
        node.AddPart(new Part {
            Id = 8, TexturePath = Tex, TextureCoordinates = new Vector2(186, 0), 
            Size = new Vector2(52,52),
        });
        node.AddPart(new Part {
            Id = 9, TexturePath = Tex, TextureCoordinates = new Vector2(212, 0), 
            Size = new Vector2(52,52),
        });
        node.AddPart(new Part {
            Id = 10, TexturePath = Tex, TextureCoordinates = new Vector2(120, 40), 
            Size = new Vector2(40,40),
        });
        node.AddPart(new Part {
            Id = 11, TexturePath = Tex, TextureCoordinates = new Vector2(160, 40), 
            Size = new Vector2(40,40),
        });
        node.AddPart(new Part {
            Id = 12, TexturePath = Tex, TextureCoordinates = new Vector2(200,40), 
            Size = new Vector2(40,40),
        });
    }

}