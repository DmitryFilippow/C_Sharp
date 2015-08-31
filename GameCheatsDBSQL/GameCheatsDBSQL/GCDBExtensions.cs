using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GameCheatsDBSQL
{
    public static class GCDBExtensions
    {
        public static T ReadStruct<T>(this BinaryReader reader) where T : struct
        {
            byte[] rawData = reader.ReadBytes(Marshal.SizeOf(typeof(T)));
            GCHandle handle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
            var retObject = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return retObject;
        }

        public static void Init()
        {
        }

        public static void WriteStruct<T>(this BinaryWriter writer, T obj) where T : struct
        {
            int rawSize = Marshal.SizeOf(typeof(T));
            IntPtr buf = Marshal.AllocHGlobal(rawSize);
            Marshal.StructureToPtr(obj, buf, false);
            byte[] rawDatas = new byte[rawSize];
            Marshal.Copy(buf, rawDatas, 0, rawSize);
            Marshal.FreeHGlobal(buf);
            writer.Write(rawDatas);
        }
    }
}
