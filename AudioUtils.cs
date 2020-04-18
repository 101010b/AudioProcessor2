using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    public class AudioUtils
    {
        public class WaveData
        {
            public bool valid;
            public byte channels;
            public UInt64 samples;
            public double samplerate;
            public List<float[]> wave;
            public string filename;

            public WaveData()
            {
                valid = false;
                channels = 0;
                samples = 0;
                samplerate = 0;
                wave = null;
                filename = "";
            }

            public WaveData(byte _channels, UInt64 _samples, double _samplerate):this()
            {
                if (_channels < 1)
                    throw new Exception("Illegal instantiation of class WaveData");
                if (_samplerate <= 0)
                    throw new Exception("Illegal instantiation of class WaveData");
                if (_samples < 1)
                    throw new Exception("Illegal instantiation of class WaveData");

                // Allocate Memory
                wave = new List<float[]>();
                for (int i = 0; i < _channels; i++)
                    wave.Add(new float[_samples]);
                channels = _channels;
                samples = _samples;
                samplerate = _samplerate;
                valid = true;
            }

            static string readRIFFHeader(BinaryReader b)
            {
                string s = "";
                for (int i = 0; i < 4; i++)
                {
                    char c = (char)b.ReadByte();
                    s += c;
                }
                return s;
            }


            public static WaveData readWAV(string filename)
            {
                BinaryReader inputFile = new BinaryReader(new FileStream(filename, FileMode.Open));

                // File Magic
                string id = readRIFFHeader(inputFile);
                if (!id.Equals("RIFF"))
                    throw new Exception(String.Format("File {0} is no WAV File", filename));

                UInt32 fs = inputFile.ReadUInt32();
                if (fs + 8 != inputFile.BaseStream.Length)
                    throw new Exception(String.Format("File {0} seems truncated", filename));

                // File type
                string typ = readRIFFHeader(inputFile);
                if (!typ.Equals("WAVE"))
                    throw new Exception(String.Format("File {0} contains no WAV-Data", filename));

                // Format header
                string fmt = readRIFFHeader(inputFile);
                if (!fmt.Equals("fmt "))
                    throw new Exception(String.Format("File {0} has no format chunk", filename));

                UInt32 fmtlen = inputFile.ReadUInt32();
                if (fmtlen < 16)
                    throw new Exception(String.Format("File {0} has a truncated format chunk", filename));

                UInt16 formatTag = inputFile.ReadUInt16();
                if (formatTag != 1)
                    throw new Exception(String.Format("File {0} is not a PCM File", filename));

                UInt16 chs = inputFile.ReadUInt16();
                if ((chs < 1) || (chs > 8))
                    throw new Exception(String.Format("File {0} has an unsupported number of channels (only 1 to 8 allowed)", filename));

                UInt32 srs = inputFile.ReadUInt32();
                UInt32 datarate = inputFile.ReadUInt32();
                UInt16 blockalign = inputFile.ReadUInt16();
                UInt16 bits = inputFile.ReadUInt16();
                if (bits != 16)
                    throw new Exception(String.Format("File {0} has an unsupported number of bits/sample (only 16 allowed)", filename));

                if (fmtlen > 16)
                {
                    // Skip over any additional bytes
                    for (int i = 0; i < fmtlen - 16; i++)
                        inputFile.ReadByte();
                }

                string datahdr = readRIFFHeader(inputFile);
                if (!datahdr.Equals("data"))
                    throw new Exception(String.Format("File {0} has no data chunk", filename));
                UInt32 dlen = inputFile.ReadUInt32();
                if (dlen + fmtlen + 8 + 8 + 8 + 4 > inputFile.BaseStream.Length)
                    throw new Exception(String.Format("File {0} seems to be corrupt", filename));

                // Try to allocate a structure
                UInt64 samples = (UInt64) ( dlen / (2 * chs) );
                WaveData wvd = null;
                try
                {
                    wvd = new WaveData((Byte)chs, samples, srs);
                }
                catch (Exception e)
                {
                    throw new Exception("File {0} cannot be read --> Out of Memory");
                }
                for (UInt64 i = 0; i < samples; i++)
                    for (byte j = 0; j < chs; j++)
                        wvd.wave[j][i] = (float)inputFile.ReadInt16()/(float)32768.0;
                inputFile.Close();
                wvd.filename = filename;
                return wvd;
            }

        }

    }
}
