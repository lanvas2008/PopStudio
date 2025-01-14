# PopStudio
In English:  
  
A project to convert many kinds of files used in PopCap Games.  
By using C# and .Net 6, this project can easily be used in Linux, MacOS, Windows and Android.  
Both English and Chinese are supported.  
Compile PopStudio.ConsoleProject to use PopStudio in Windows, Linux and MacOS with console.(new feature is not supported)  
Compile PopStudio.MAUI to use PopStudio in Android with GUI.  
Compile PopStudio.WPF to use PopStudio in Windows with GUI.  
Compile PopStudio.GTK to use PopStudio in Linux and MacOS with GUI.  
Now this project supports unpack and pack dz, rsb(including Android, iOS, PS3, Xbox360 and Android Chinese version) and pak(including Windows, MacOS, PS3, PSV and Xbox360 version), decode and encode ptx(including rsb, PS3, Xbox360 and PSV version), tex(including iOS and Android TV version), txz, cdat, RTON, reanim.compiled, trail.compiled, xml.compiled, and cut and create atlas.  
___
If you know other file sturctures such as pam and pax, you can communicate with the author.  
And maybe the author needs some PVZ versions: Tizen, BlackBerry 10. I'll appreciate it if you could provide them.  
___
If you want to communicate with the author, you can download QQ(a chatting software) in Google Play, App Store or Microsoft Store, and then register a QQ account number and enter our QQ group numbered 1017246977(The answer is "Github").
___
This project has used:  
[DotNetZip](https://github.com/eropple/dotnetzip) to decompress and compress BZip2 files.  
[LZMA-SDK](https://github.com/monemihir/LZMA-SDK) to decompress and compress Lzma files.  
[K4os.Compression.LZ4](https://github.com/MiloszKrajewski/K4os.Compression.LZ4) to decompress and compress Lz4 files.  
[SkiaSharp](https://github.com/mono/SkiaSharp) to read and write PNG files.  
[bc-sharp](https://github.com/novotnyllc/bc-csharp) to encrypt and decrypt Rijndael files.  
[MaxRectsBinPack](http://wiki.unity3d.com/index.php/MaxRectsBinPack) to create atlas.  
[NLua](https://github.com/NLua/NLua) to run lua script.  
[GtkSharp](https://github.com/GtkSharp/GtkSharp) to draw GUI for GTK project.  
  
reference:
[Real-Time DXT Compression](https://www.researchgate.net/publication/259000525_Real-Time_DXT_Compression) to encode DXT texture.  
[EveryFileExplorer](https://github.com/Gericom/EveryFileExplorer) to encode ETC1 texture.  
[pvrtccompressor](https://bitbucket.org/jthlim/pvrtccompressor) to decode and encode PVRTC texture.  
___
In Chinese:  
  
一个用于转换很多宝开游戏使用的文件的项目。  
通过使用C#和.Net 6，这个项目可以很轻松地在Linux，MacOS，Windows和Android上使用。  
英文和中文都是被支持的。
编译PopStudio.ConsoleProject以在Windows，Linux和MacOS使用控制台版本。（新功能不受支持）  
编译PopStudio.MAUI以在Android使用GUI版本。  
编译PopStudio.WPF以在Windows使用GUI版本。  
编译PopStudio.GTK以在Linux和MacOS使用GUI版本。  
现在这个项目支持解包打包dz，rsb（包括Android，iOS，PS3，Xbox360和Android中文版）和pak（包括Windows，MacOS，PS3，PSV和Xbox360版），解码编码ptx（包括rsb中的版本，PS3版，Xbox360版和PSV版），tex（包括iOS版和Android TV版），txz，cdat，RTON，reanim.compiled，trail.compiled，xml.compiled，和图集裁剪与拼接。  
___
如果你知道其他文件结构，例如pam和pax，你可以和作者交流。  
或许作者需要一些植物大战僵尸版本：Tizen，黑莓10。如果你可以提供这些版本，我会非常感激。  
___
如果你想和作者交流，你可以使用QQ，加入群聊1017246977（备注“GitHub”）。
___
这个项目使用了：  
[DotNetZip](https://github.com/eropple/dotnetzip)用于解压和压缩BZip2文件。  
[LZMA-SDK](https://github.com/monemihir/LZMA-SDK)用于解压和压缩Lzma文件。  
[K4os.Compression.LZ4](https://github.com/MiloszKrajewski/K4os.Compression.LZ4)用于解压和压缩Lz4文件。  
[SkiaSharp](https://github.com/mono/SkiaSharp)用于读写PNG图像。  
[bc-sharp](https://github.com/novotnyllc/bc-csharp)用于加密和解密Rijndael文件。  
[MaxRectsBinPack](http://wiki.unity3d.com/index.php/MaxRectsBinPack)用于构建图集。  
[NLua](https://github.com/NLua/NLua)用于执行lua脚本。  
[GtkSharp](https://github.com/GtkSharp/GtkSharp)用于GTK项目界面绘制。  
  
参考：
[Real-Time DXT Compression](https://www.researchgate.net/publication/259000525_Real-Time_DXT_Compression)用于编码DXT纹理。  
[EveryFileExplorer](https://github.com/Gericom/EveryFileExplorer)用于编码ETC1纹理。  
[pvrtccompressor](https://bitbucket.org/jthlim/pvrtccompressor)用于解码和编码PVRTC纹理。  