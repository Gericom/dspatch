using dspatch.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dspatch.DS
{
    public class DemoMenu
    {
        public byte[] Write()
        {
            MemoryStream m = new MemoryStream();
            EndianBinaryWriter er = new EndianBinaryWriter(m);
            er.Write((byte)entries.Count);
            er.Write((byte)0);
            er.Write((byte)0);
            er.Write((byte)0);
            foreach (var e in entries)
                e.Write(er);
            er.Write((uint)0);
            byte[] result = m.ToArray();
            er.Close();
            return result;
        }
        public List<DemoMenuEntry> entries = new List<DemoMenuEntry>();
        public class DemoMenuEntry
        {
            private string createString(string text, int length, bool nullTerminated = true)
            {
                if (text == null)
                    text = "";
                if (text.Length > (length - (nullTerminated ? 1 : 0)))
                    return text.Substring(0, length - (nullTerminated ? 1 : 0));
                return text.PadRight(length, '\0');
            }

            public void Write(EndianBinaryWriter er)
            {
                er.Write(bannerImage, 0, 512);
                er.Write(bannerPalette, 0, 32);
                er.Write(createString(bannerText1, 0x80), Encoding.ASCII, false);
                er.Write(createString(bannerText2, 0x80), Encoding.ASCII, false);
                er.Write(rating);
                er.Write(guideMode);
                er.Write(createString(selectButtonText, 0x20), Encoding.ASCII, false);
                er.Write(createString(startButtonText, 0x20), Encoding.ASCII, false);
                er.Write(createString(aButtonText, 0x20), Encoding.ASCII, false);
                er.Write(createString(bButtonText, 0x20), Encoding.ASCII, false);
                er.Write(createString(xButtonText, 0x20), Encoding.ASCII, false);
                er.Write(createString(yButtonText, 0x20), Encoding.ASCII, false);
                er.Write(createString(lButtonText, 0x20), Encoding.ASCII, false);
                er.Write(createString(rButtonText, 0x20), Encoding.ASCII, false);
                er.Write(createString(dpadText, 0x20), Encoding.ASCII, false);
                er.Write(createString(unknown1Text, 0x20), Encoding.ASCII, false);
                er.Write(createString(unknown2Text, 0x20), Encoding.ASCII, false);
                er.Write(createString(unknown3Text, 0x20), Encoding.ASCII, false);
                er.Write(createString(touchText1, 0x20), Encoding.ASCII, false);
                er.Write(createString(touchText2, 0x20), Encoding.ASCII, false);
                er.Write(padding, 0, 0x40);
                er.Write(createString(internalName, 0xA, false), Encoding.ASCII, false);
            }
            public byte[] bannerImage;
            public byte[] bannerPalette;
            public string bannerText1;
            public string bannerText2;
            public byte rating = 0x1;//0x1 = Everyone
            public byte guideMode = 0x11;//0x11 = nothing, 0x13 = only buttons, 0x15 = only touch, 0x17 = buttons + touch
            public string selectButtonText;
            public string startButtonText;
            public string aButtonText;
            public string bButtonText;
            public string xButtonText;
            public string yButtonText;
            public string lButtonText;
            public string rButtonText;
            public string dpadText;
            public string unknown1Text;
            public string unknown2Text;
            public string unknown3Text;
            public string touchText1;
            public string touchText2;
            public byte[] padding = new byte[0x40];//?
            public string internalName;
        }
    }
}
