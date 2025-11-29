using System.Numerics;
using KamiToolKit.Classes;
using KamiToolKit.Nodes;

namespace KtKTestBed.PvPMKSBattleLog;

public class PVPMKSTextureHelper
{
    
    
    //NEVER use high rez coordinates
    private static readonly string Tex = "ui/uld/PVPScreenInformation.tex"; 
    public static unsafe void LoadPvPScreenInformation(NineGridNode grid) {
        grid.AddPart(new Part {
            Id = 0, TexturePath = Tex, TextureCoordinates = new Vector2(1, 303), 
            Size = new Vector2(80, 90)
        });
        grid.AddPart(new Part {
            Id = 1, TexturePath = Tex, TextureCoordinates = new Vector2(83, 303), 
            Size = new Vector2(80, 90),
        });
        grid.AddPart(new Part {
            Id = 2, TexturePath = Tex, TextureCoordinates = new Vector2(165, 303), 
            Size = new Vector2(80, 90),
        });
        grid.AddPart(new Part {
            Id = 3, TexturePath = Tex, TextureCoordinates = new Vector2(61, 240), 
            Size = new Vector2(60, 46),
        });
        grid.AddPart(new Part {
            Id = 4, TexturePath = Tex, TextureCoordinates = new Vector2(2, 273), 
            Size = new Vector2(40, 28),
        });
        grid.AddPart(new Part {
            Id = 5, TexturePath = Tex, TextureCoordinates = new Vector2(260, 334), 
            Size = new Vector2(156, 60),
        });
        grid.AddPart(new Part {
            Id = 6, TexturePath = Tex, TextureCoordinates = new Vector2(220, 210), 
            Size = new Vector2(40, 32),
        });
        grid.AddPart(new Part {
            Id = 7, TexturePath = Tex, TextureCoordinates = new Vector2(0, 272), 
            Size = new Vector2(44, 30),
        });
        grid.AddPart(new Part {
            Id = 8, TexturePath = Tex, TextureCoordinates = new Vector2(44, 272), 
            Size = new Vector2(16, 16),
        });
        grid.AddPart(new Part {
            Id = 9, TexturePath = Tex, TextureCoordinates = new Vector2(261, 211), 
            Size = new Vector2(154, 106),
        });
        grid.AddPart(new Part {
            Id = 10, TexturePath = Tex, TextureCoordinates = new Vector2(260, 320), 
            Size = new Vector2(156, 6),
        });
        grid.AddPart(new Part {
            Id = 11, TexturePath = Tex, TextureCoordinates = new Vector2(260, 329), 
            Size = new Vector2(156, 4),
        });
        grid.AddPart(new Part {
            Id = 12, TexturePath = Tex, TextureCoordinates = new Vector2(222,242), 
            Size = new Vector2(36, 36),
        });
        grid.AddPart(new Part {
            Id = 13, TexturePath = Tex, TextureCoordinates = new Vector2(24,264), 
            Size = new Vector2(28, 8),
        });
    }
    
}