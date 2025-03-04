﻿using SkiaSharp;

namespace PopStudio.Image.PtxPS3
{
    /// <summary>
    /// It's dds used DXT5_RGBA Texture
    /// </summary>
    internal static class Ptx
    {
        public static void Encode(string inFile, string outFile)
        {
            using (BinaryStream bs = new BinaryStream(outFile, FileMode.Create))
            {
                using (SKBitmap sKBitmap = SKBitmap.Decode(inFile))
                {
                    PtxHead head = new PtxHead
                    {
                        width = (ushort)sKBitmap.Width,
                        height = (ushort)sKBitmap.Height
                    };
                    head.Write(bs);
                    Texture.DXT5_RGBA.Write(bs, sKBitmap);
                    bs.Position = 0;
                    head.Write(bs);
                }
            }
        }

        public static void Decode(string inFile, string outFile)
        {
            using (BinaryStream bs = new BinaryStream(inFile, FileMode.Open))
            {
                PtxHead head = new PtxHead().Read(bs);
                using (SKBitmap sKBitmap = Texture.DXT5_RGBA.Read(bs, head.width, head.height))
                {
                    sKBitmap.Save(outFile);
                }
            }
        }
    }
}