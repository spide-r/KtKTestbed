using System.Numerics;
using KamiToolKit.Classes;
using KamiToolKit.Nodes;

namespace KtKTestBed;

public static class PvPIconNodeTextureHelper
{
    //NEVER use high rez coordinates
    public static unsafe void LoadPvPmksGuageTexture(ImageNode image) {
        image.AddPart(new Part {
            Id = 0, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(0, 0), 
            Size = new Vector2(212, 30)
        });
        image.AddPart(new Part {
            Id = 1, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(212, 0), 
            Size = new Vector2(208, 30),
        });
        image.AddPart(new Part {
            Id = 2, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(0, 30), 
            Size = new Vector2(256, 30),
        });
        image.AddPart(new Part {
            Id = 3, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(256, 30), 
            Size = new Vector2(256, 30),
        });
        image.AddPart(new Part {
            Id = 4, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(0, 60), 
            Size = new Vector2(256, 30),
        });
        image.AddPart(new Part {
            Id = 5, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(256, 60), 
            Size = new Vector2(256, 30),
        });
        image.AddPart(new Part {
            Id = 6, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(0, 90), 
            Size = new Vector2(512, 30),
        });
        image.AddPart(new Part {
            Id = 7, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(0, 120), 
            Size = new Vector2(512, 30),
        });
        image.AddPart(new Part {
            Id = 8, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(420, 0), 
            Size = new Vector2(26, 30),
        });
        image.AddPart(new Part {
            Id = 9, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(446, 0), 
            Size = new Vector2(26, 30),
        });
        image.AddPart(new Part {
            Id = 10, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(473, 0), 
            Size = new Vector2(24, 30),
        });
        image.AddPart(new Part {
            Id = 11, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(499, 0), 
            Size = new Vector2(12, 30),
        });
        image.AddPart(new Part {
            Id = 12, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(258, 153), 
            Size = new Vector2(246, 2),
        });
        image.AddPart(new Part {
            Id = 13, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(0, 150), 
            Size = new Vector2(30, 30),
        });
        image.AddPart(new Part {
            Id = 14, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(30, 150), 
            Size = new Vector2(30, 30),
        });
        image.AddPart(new Part {
            Id = 15, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(60, 150), 
            Size = new Vector2(30, 30),
        });
        image.AddPart(new Part {
            Id = 16, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(90, 150), 
            Size = new Vector2(30, 30),
        });
        image.AddPart(new Part {
            Id = 17, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(0, 212), 
            Size = new Vector2(40, 40),
        });
        image.AddPart(new Part {
            Id = 18, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(258, 164), 
            Size = new Vector2(254, 4),
        });
        image.AddPart(new Part {
            Id = 19, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(122, 150),
            Size = new Vector2(26, 30),
        });
        image.AddPart(new Part {
            Id = 20, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(64, 180), 
            Size = new Vector2(32, 32),
        });
        image.AddPart(new Part {
            Id = 21, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(96, 180), 
            Size = new Vector2(76, 76),
        });
        image.AddPart(new Part {
            Id = 22, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(298, 172), 
            Size = new Vector2(214, 29),
        });
        image.AddPart(new Part {
            Id = 23, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(278, 172), 
            Size = new Vector2(20, 29),
        });
        image.AddPart(new Part {
            Id = 24, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", TextureCoordinates = new Vector2(245, 181), 
            Size = new Vector2(22, 22),
        });
    }
    
}
