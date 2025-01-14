﻿using SkiaSharp;

namespace PopStudio.Image.Ptx
{
    internal static class Ptx
    {
        public static void Encode(string inFile, string outFile, int format)
        {
            using (BinaryStream bs = BinaryStream.Create(outFile))
            {
                using (SKBitmap sKBitmap = SKBitmap.Decode(inFile))
                {
                    long off = bs.Position;
                    PtxHead head = new PtxHead
                    {
                        width = sKBitmap.Width,
                        height = sKBitmap.Height,
                    };
                    head.Write(bs);
                    switch (format)
                    {
                        case 0:
                            head.check = Texture.ARGB8888.Write(bs, sKBitmap);
                            head.format = PtxFormat.ARGB8888;
                            break;
                        case 1:
                            head.check = Texture.ABGR8888.Write(bs, sKBitmap);
                            head.format = PtxFormat.ARGB8888;
                            break;
                        case 2:
                            head.check = Texture.RGBA4444.Write(bs, sKBitmap);
                            head.format = PtxFormat.RGBA4444;
                            break;
                        case 3:
                            head.check = Texture.RGB565.Write(bs, sKBitmap);
                            head.format = PtxFormat.RGB565;
                            break;
                        case 4:
                            head.check = Texture.RGBA5551.Write(bs, sKBitmap);
                            head.format = PtxFormat.RGBA5551;
                            break;
                        case 5:
                            if (head.width % 32 != 0) head.width = head.width / 32 * 32 + 32;
                            if (head.height % 32 != 0) head.height = head.height / 32 * 32 + 32;
                            head.check = Texture.RGBA4444_Block.Write(bs, sKBitmap);
                            head.format = PtxFormat.RGBA4444_Block;
                            break;
                        case 6:
                            if (head.width % 32 != 0) head.width = head.width / 32 * 32 + 32;
                            if (head.height % 32 != 0) head.height = head.height / 32 * 32 + 32;
                            head.check = Texture.RGB565_Block.Write(bs, sKBitmap);
                            head.format = PtxFormat.RGB565_Block;
                            break;
                        case 7:
                            if (head.width % 32 != 0) head.width = head.width / 32 * 32 + 32;
                            if (head.height % 32 != 0) head.height = head.height / 32 * 32 + 32;
                            head.check = Texture.RGBA5551_Block.Write(bs, sKBitmap);
                            head.format = PtxFormat.RGBA5551_Block;
                            break;
                        case 8:
                            head.check = Texture.XRGB8888_A8.Write(bs, sKBitmap);
                            head.format = PtxFormat.XRGB8888_A8;
                            break;
                        case 9:
                            bs.Endian = Endian.Big;
                            head.check = Texture.ARGB8888.Write(bs, sKBitmap);
                            head.format = PtxFormat.ARGB8888;
                            break;
                        case 10:
                            bs.Endian = Endian.Big;
                            int w = sKBitmap.Width;
                            if ((w % 64) != 0) w = (w / 64) * 64 + 64;
                            head.check = Texture.ARGB8888_Padding.Write(bs, sKBitmap, w << 2);
                            head.format = PtxFormat.ARGB8888;
                            break;
                        case 11:
                            head.check = Texture.DXT1_RGB.Write(bs, sKBitmap);
                            head.format = PtxFormat.DXT1_RGB;
                            break;
                        case 12:
                            head.check = Texture.DXT3_RGBA.Write(bs, sKBitmap);
                            head.format = PtxFormat.DXT3_RGBA;
                            break;
                        case 13:
                            head.check = Texture.DXT5_RGBA.Write(bs, sKBitmap);
                            head.format = PtxFormat.DXT5_RGBA;
                            break;
                        case 14:
                            head.check = Texture.DXT5_RGBA.Write(bs, sKBitmap);
                            head.format = PtxFormat.DXT5;
                            break;
                        case 15:
                            head.check = Texture.DXT5_RGBA.Write(bs, sKBitmap);
                            head.format = PtxFormat.DXT5; //the texture is also small endian
                            bs.Endian = Endian.Big; //but the info is big endian
                            break;
                        case 16:
                            head.check = Texture.ETC1_RGB.Write(bs, sKBitmap);
                            head.format = PtxFormat.ETC1_RGB;
                            break;
                        case 17:
                            head.check = Texture.ETC1_RGB_A8.Write(bs, sKBitmap);
                            head.format = PtxFormat.ETC1_RGB_A8;
                            break;
                        case 18:
                            head.check = Texture.ETC1_RGB_A_Palette.Write(bs, sKBitmap, out head.alphaSize);
                            head.format = PtxFormat.ETC1_RGB_A8; //Also 147
                            head.alphaFormat = 0x64;
                            break;
                        case 19:
                            head.check = Texture.ETC1_RGB_A_Palette.Write(bs, sKBitmap, out head.alphaSize);
                            head.format = PtxFormat.ETC1_RGB_A_Palette;
                            head.alphaFormat = 0x64;
                            break;
                        case 20:
                            head.check = Texture.PVRTC_4BPP_RGBA.Write(bs, sKBitmap);
                            head.format = PtxFormat.PVRTC_4BPP_RGBA;
                            break;
                        case 21:
                            head.check = Texture.PVRTC_4BPP_RGB_A8.Write(bs, sKBitmap);
                            head.format = PtxFormat.PVRTC_4BPP_RGB_A8;
                            break;
                        default:
                            throw new Exception(Str.Obj.UnknownFormat);
                    }
                    bs.Position = off;
                    head.Write(bs);
                }
            }
        }

        public static void Encode(string inFile, string outFile, PtxFormat format, Endian encodeendian, bool chinesemode)
        {
            using (BinaryStream bs = BinaryStream.Create(outFile))
            {
                bs.Endian = encodeendian;
                using (SKBitmap sKBitmap = SKBitmap.Decode(inFile))
                {
                    long off = bs.Position;
                    PtxHead head = new PtxHead
                    {
                        width = sKBitmap.Width,
                        height = sKBitmap.Height,
                        format = format
                    };
                    head.Write(bs);
                    switch (format)
                    {
                        case PtxFormat.ARGB8888:
                            if (Setting.RsbPtxABGR8888Mode)
                            {
                                head.check = Texture.ABGR8888.Write(bs, sKBitmap);
                            }
                            else if (Setting.RsbPtxARGB8888PaddingMode)
                            {
                                int w = sKBitmap.Width;
                                if ((w % 64) != 0) w = (w / 64) * 64 + 64;
                                head.check = Texture.ARGB8888_Padding.Write(bs, sKBitmap, w << 2);
                            }
                            else
                            {
                                head.check = Texture.ARGB8888.Write(bs, sKBitmap);
                            }
                            break;
                        case PtxFormat.RGBA4444:
                            head.check = Texture.RGBA4444.Write(bs, sKBitmap);
                            break;
                        case PtxFormat.RGB565:
                            head.check = Texture.RGB565.Write(bs, sKBitmap);
                            break;
                        case PtxFormat.RGBA5551:
                            head.check = Texture.RGBA5551.Write(bs, sKBitmap);
                            break;
                        case PtxFormat.DXT5:
                            Endian backendian = bs.Endian;
                            bs.Endian = Endian.Small;
                            head.check = Texture.DXT5_RGBA.Write(bs, sKBitmap);
                            bs.Endian = backendian;
                            break;
                        case PtxFormat.RGBA4444_Block:
                            if (head.width % 32 != 0) head.width = head.width / 32 * 32 + 32;
                            if (head.height % 32 != 0) head.height = head.height / 32 * 32 + 32;
                            head.check = Texture.RGBA4444_Block.Write(bs, sKBitmap);
                            break;
                        case PtxFormat.RGB565_Block:
                            if (head.width % 32 != 0) head.width = head.width / 32 * 32 + 32;
                            if (head.height % 32 != 0) head.height = head.height / 32 * 32 + 32;
                            head.check = Texture.RGB565_Block.Write(bs, sKBitmap);
                            break;
                        case PtxFormat.RGBA5551_Block:
                            if (head.width % 32 != 0) head.width = head.width / 32 * 32 + 32;
                            if (head.height % 32 != 0) head.height = head.height / 32 * 32 + 32;
                            head.check = Texture.RGBA5551_Block.Write(bs, sKBitmap);
                            break;
                        case PtxFormat.PVRTC_4BPP_RGBA:
                            head.check = Texture.PVRTC_4BPP_RGBA.Write(bs, sKBitmap);
                            break;
                        case PtxFormat.ETC1_RGB:
                            head.check = Texture.ETC1_RGB.Write(bs, sKBitmap);
                            break;
                        case PtxFormat.DXT1_RGB:
                            head.check = Texture.DXT1_RGB.Write(bs, sKBitmap);
                            break;
                        case PtxFormat.DXT3_RGBA:
                            head.check = Texture.DXT3_RGBA.Write(bs, sKBitmap);
                            break;
                        case PtxFormat.DXT5_RGBA:
                            head.check = Texture.DXT5_RGBA.Write(bs, sKBitmap);
                            break;
                        case PtxFormat.ETC1_RGB_A8:
                            if (chinesemode)
                            {
                                head.check = Texture.ETC1_RGB_A_Palette.Write(bs, sKBitmap, out head.alphaSize);
                                head.alphaFormat = 0x64;
                            }
                            else
                            {
                                head.check = Texture.ETC1_RGB_A8.Write(bs, sKBitmap);
                            }
                            break;
                        case PtxFormat.PVRTC_4BPP_RGB_A8:
                            head.check = Texture.PVRTC_4BPP_RGB_A8.Write(bs, sKBitmap);
                            break;
                        case PtxFormat.XRGB8888_A8:
                            head.check = Texture.XRGB8888_A8.Write(bs, sKBitmap);
                            break;
                        case PtxFormat.ETC1_RGB_A_Palette:
                            head.check = Texture.ETC1_RGB_A_Palette.Write(bs, sKBitmap, out head.alphaSize);
                            head.alphaFormat = 0x64;
                            break;
                        default:
                            throw new Exception(Str.Obj.UnknownFormat);
                    }
                    bs.Position = off;
                    head.Write(bs);
                }
            }
        }

        public static void Decode(string inFile, string outFile, bool fromrsb = false)
        {
            using (BinaryStream bs = BinaryStream.Open(inFile))
            {
                PtxHead head = new PtxHead().Read(bs);
                switch (head.format)
                {
                    case PtxFormat.ARGB8888:
                        {
                            if ((fromrsb && Setting.RsbPtxABGR8888Mode) || ((!fromrsb) && Setting.PtxABGR8888Mode))
                            {
                                using (SKBitmap sKBitmap = Texture.ABGR8888.Read(bs, head.width, head.height))
                                {
                                    sKBitmap.Save(outFile);
                                }
                            }
                            else if ((fromrsb && Setting.RsbPtxARGB8888PaddingMode) || ((!fromrsb) && Setting.PtxARGB8888PaddingMode))
                            {
                                int w = head.width;
                                if ((w % 64) != 0) w = (w / 64) * 64 + 64;
                                using (SKBitmap sKBitmap = Texture.ARGB8888_Padding.Read(bs, head.width, head.height, w << 2))
                                {
                                    sKBitmap.Save(outFile);
                                }
                            }
                            else
                            {
                                using (SKBitmap sKBitmap = Texture.ARGB8888.Read(bs, head.width, head.height))
                                {
                                    sKBitmap.Save(outFile);
                                }
                            }
                        }
                        break;
                    case PtxFormat.RGBA4444:
                        using (SKBitmap sKBitmap = Texture.RGBA4444.Read(bs, head.width, head.height))
                        {
                            sKBitmap.Save(outFile);
                        }
                        break;
                    case PtxFormat.RGB565:
                        using (SKBitmap sKBitmap = Texture.RGB565.Read(bs, head.width, head.height))
                        {
                            sKBitmap.Save(outFile);
                        }
                        break;
                    case PtxFormat.RGBA5551:
                        using (SKBitmap sKBitmap = Texture.RGBA5551.Read(bs, head.width, head.height))
                        {
                            sKBitmap.Save(outFile);
                        }
                        break;
                    case PtxFormat.DXT5:
                        bs.Endian = Endian.Small;
                        using (SKBitmap sKBitmap = Texture.DXT5_RGBA.Read(bs, head.width, head.height))
                        {
                            sKBitmap.Save(outFile);
                        }
                        break;
                    case PtxFormat.RGBA4444_Block:
                        using (SKBitmap sKBitmap = Texture.RGBA4444_Block.Read(bs, head.width, head.height))
                        {
                            sKBitmap.Save(outFile);
                        }
                        break;
                    case PtxFormat.RGB565_Block:
                        using (SKBitmap sKBitmap = Texture.RGB565_Block.Read(bs, head.width, head.height))
                        {
                            sKBitmap.Save(outFile);
                        }
                        break;
                    case PtxFormat.RGBA5551_Block:
                        using (SKBitmap sKBitmap = Texture.RGBA5551_Block.Read(bs, head.width, head.height))
                        {
                            sKBitmap.Save(outFile);
                        }
                        break;
                    case PtxFormat.PVRTC_4BPP_RGBA:
                        using (SKBitmap sKBitmap = Texture.PVRTC_4BPP_RGBA.Read(bs, head.width, head.height))
                        {
                            sKBitmap.Save(outFile);
                        }
                        break;
                    case PtxFormat.PVRTC_2BPP_RGBA:
                        using (SKBitmap sKBitmap = Texture.PVRTC_2BPP_RGBA.Read(bs, head.width, head.height))
                        {
                            sKBitmap.Save(outFile);
                        }
                        break;
                    case PtxFormat.ETC1_RGB:
                        using (SKBitmap sKBitmap = Texture.ETC1_RGB.Read(bs, head.width, head.height))
                        {
                            sKBitmap.Save(outFile);
                        }
                        break;
                    case PtxFormat.DXT1_RGB:
                        using (SKBitmap sKBitmap = Texture.DXT1_RGB.Read(bs, head.width, head.height))
                        {
                            sKBitmap.Save(outFile);
                        }
                        break;
                    case PtxFormat.DXT3_RGBA:
                        using (SKBitmap sKBitmap = Texture.DXT3_RGBA.Read(bs, head.width, head.height))
                        {
                            sKBitmap.Save(outFile);
                        }
                        break;
                    case PtxFormat.DXT5_RGBA:
                        using (SKBitmap sKBitmap = Texture.DXT5_RGBA.Read(bs, head.width, head.height))
                        {
                            sKBitmap.Save(outFile);
                        }
                        break;
                    case PtxFormat.ETC1_RGB_A8:
                        if (head.alphaFormat == 0x64)
                        {
                            using (SKBitmap sKBitmap = Texture.ETC1_RGB_A_Palette.Read(bs, head.width, head.height))
                            {
                                sKBitmap.Save(outFile);
                            }
                        }
                        else
                        {
                            if (head.alphaFormat != 0x0) throw new Exception();
                            using (SKBitmap sKBitmap = Texture.ETC1_RGB_A8.Read(bs, head.width, head.height))
                            {
                                sKBitmap.Save(outFile);
                            }
                        }
                        break;
                    case PtxFormat.PVRTC_4BPP_RGB_A8:
                        using (SKBitmap sKBitmap = Texture.PVRTC_4BPP_RGB_A8.Read(bs, head.width, head.height))
                        {
                            sKBitmap.Save(outFile);
                        }
                        break;
                    case PtxFormat.XRGB8888_A8:
                        using (SKBitmap sKBitmap = Texture.XRGB8888_A8.Read(bs, head.width, head.height))
                        {
                            sKBitmap.Save(outFile);
                        }
                        break;
                    case PtxFormat.ETC1_RGB_A_Palette:
                        using (SKBitmap sKBitmap = Texture.ETC1_RGB_A_Palette.Read(bs, head.width, head.height))
                        {
                            sKBitmap.Save(outFile);
                        }
                        break;
                    default:
                        throw new Exception(Str.Obj.UnknownFormat);
                }
            }
        }
    }
}