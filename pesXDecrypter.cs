using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace AATF_15
{
    class PES16Decrypter
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 176), Serializable]
        private unsafe struct FileHeader
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] mysteryData;
            public UInt32 dataSize;
            public UInt32 logoSize;
            public UInt32 descSize;
            public UInt32 serialLength;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] hash;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] fileTypeString;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 24), Serializable]
        private unsafe struct FileDescriptor
        {
            public byte* encryptionHeader;
            public IntPtr fileHeader;
            public byte* description;
            public byte* logo;
            public byte* data;
            public byte* serial;
        };

        [DllImport("pesXdecryptor.dll", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern void decrypt(ref FileDescriptor descriptor, byte* input);

        public static byte[] decryptFile(byte[] input)
        {
            byte[] output;
            unsafe
            {
                fixed (byte* inputPtr = input)
                {
                    FileDescriptor descriptor = new FileDescriptor();
                    decrypt(ref descriptor, inputPtr);
                    FileHeader header = (FileHeader)Marshal.PtrToStructure(descriptor.fileHeader, typeof(FileHeader));
                    output = new byte[header.dataSize];
                    Marshal.Copy((IntPtr)descriptor.data, output, 0, (int)header.dataSize);
                }
            }
            return output;
        }
    }
}
