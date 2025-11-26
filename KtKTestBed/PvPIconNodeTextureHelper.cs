using System.Numerics;
using KamiToolKit.Classes;
using KamiToolKit.Nodes;

namespace KtKTestBed;

public static class PvPIconNodeTextureHelper
{
    //NEVER use high rez coordinates
    public static unsafe void LoadPvPmksGuageTexture(ImageNode image) {
        image.AddPart(new Part {
            Id = 0, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(424, 60), TextureCoordinates = new Vector2(0, 0)
        });
        image.AddPart(new Part {
            Id = 1, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(416, 60), TextureCoordinates = new Vector2(424, 0),
        });
        image.AddPart(new Part {
            Id = 2, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(512, 60), TextureCoordinates = new Vector2(0, 60),
        });
        image.AddPart(new Part {
            Id = 3, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(512, 60), TextureCoordinates = new Vector2(512, 60),
        });
        image.AddPart(new Part {
            Id = 4, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(512, 60), TextureCoordinates = new Vector2(0, 120),
        });
        image.AddPart(new Part {
            Id = 5, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(512, 60), TextureCoordinates = new Vector2(512, 120),
        });
        image.AddPart(new Part {
            Id = 6, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(1024, 60), TextureCoordinates = new Vector2(0, 180),
        });
        image.AddPart(new Part {
            Id = 7, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(1024, 60), TextureCoordinates = new Vector2(0, 240),
        });
        image.AddPart(new Part {
            Id = 8, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(52, 60), TextureCoordinates = new Vector2(840, 0),
        });
        image.AddPart(new Part {
            Id = 9, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(52, 60), TextureCoordinates = new Vector2(892, 0),
        });
        image.AddPart(new Part {
            Id = 10, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(48, 60), TextureCoordinates = new Vector2(946, 0),
        });
        image.AddPart(new Part {
            Id = 11, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(24, 60), TextureCoordinates = new Vector2(996, 0),
        });
        image.AddPart(new Part {
            Id = 12, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(492, 4), TextureCoordinates = new Vector2(516, 306),
        });
        image.AddPart(new Part {
            Id = 13, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(60, 60), TextureCoordinates = new Vector2(0, 300),
        });
        image.AddPart(new Part {
            Id = 14, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(60, 60), TextureCoordinates = new Vector2(60, 300),
        });
        image.AddPart(new Part {
            Id = 15, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(60, 60), TextureCoordinates = new Vector2(120, 300),
        });
        image.AddPart(new Part {
            Id = 16, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(60, 60), TextureCoordinates = new Vector2(180, 300),
        });
        image.AddPart(new Part {
            Id = 17, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(80, 80), TextureCoordinates = new Vector2(0, 424),
        });
        image.AddPart(new Part {
            Id = 18, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(508, 8), TextureCoordinates = new Vector2(516, 328),
        });
        image.AddPart(new Part {
            Id = 19, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(52, 60), TextureCoordinates = new Vector2(244, 300),
        });
        image.AddPart(new Part {
            Id = 20, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(64, 64), TextureCoordinates = new Vector2(128, 360),
        });
        image.AddPart(new Part {
            Id = 21, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(152, 152), TextureCoordinates = new Vector2(192, 360),
        });
        image.AddPart(new Part {
            Id = 22, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(428, 58), TextureCoordinates = new Vector2(596, 344),
        });
        image.AddPart(new Part {
            Id = 23, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(40, 58), TextureCoordinates = new Vector2(556, 344),
        });
        image.AddPart(new Part {
            Id = 24, TexturePath = "ui/uld/PvPMKSGauge_hr1.tex", Size = new Vector2(44, 44), TextureCoordinates = new Vector2(490, 362),
        });
    }
    
}
