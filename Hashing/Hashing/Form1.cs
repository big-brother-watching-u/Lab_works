using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;


namespace Hashing
{
    public partial class MainWindow : Form
    {

        private readonly AES128 AESEnc = new AES128();
        public MainWindow()
        {

            InitializeComponent();
            BtnEcrypt.Click += async (data, eventArgs) =>
            {
                var message = Message.Text;
                var pass = PassEncr.Text;
                var encrypted = "";
                await ExceptAsync(() =>
                {
                    encrypted = AESEnc.Encrypt(message, pass);
                });
                EncrMessageOut.Text = encrypted;
                
            };
            BtnDecrypt.Click += async (data, eventArgs) =>
            {
                
                var message = EncrMessageIn.Text;
                var pass = PassDecr.Text; var decrypted = "";
                await ExceptAsync(() =>
                {
                    decrypted = AESEnc.Decrypt(message, pass);
                });
                DecrMessageOut.Text = decrypted;
                
            };
        }
        private async Task ExceptAsync(Action action)
        {
            try
            {
                await Task.Run(action);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

    }
    public class AES128
    {
        private readonly byte[] Sbox = new byte[]
        {
            0x63,0x7c,0x77,0x7b,0xf2,0x6b,0x6f,0xc5,0x30,0x01,0x67,0x2b,0xfe,0xd7,0xab,0x76,
            0xca,0x82,0xc9,0x7d,0xfa,0x59,0x47,0xf0,0xad,0xd4,0xa2,0xaf,0x9c,0xa4,0x72,0xc0,
            0xb7,0xfd,0x93,0x26,0x36,0x3f,0xf7,0xcc,0x34,0xa5,0xe5,0xf1,0x71,0xd8,0x31,0x15,
            0x04,0xc7,0x23,0xc3,0x18,0x96,0x05,0x9a,0x07,0x12,0x80,0xe2,0xeb,0x27,0xb2,0x75,
            0x09,0x83,0x2c,0x1a,0x1b,0x6e,0x5a,0xa0,0x52,0x3b,0xd6,0xb3,0x29,0xe3,0x2f,0x84,
            0x53,0xd1,0x00,0xed,0x20,0xfc,0xb1,0x5b,0x6a,0xcb,0xbe,0x39,0x4a,0x4c,0x58,0xcf,
            0xd0,0xef,0xaa,0xfb,0x43,0x4d,0x33,0x85,0x45,0xf9,0x02,0x7f,0x50,0x3c,0x9f,0xa8,
            0x51,0xa3,0x40,0x8f,0x92,0x9d,0x38,0xf5,0xbc,0xb6,0xda,0x21,0x10,0xff,0xf3,0xd2,
            0xcd,0x0c,0x13,0xec,0x5f,0x97,0x44,0x17,0xc4,0xa7,0x7e,0x3d,0x64,0x5d,0x19,0x73,
            0x60,0x81,0x4f,0xdc,0x22,0x2a,0x90,0x88,0x46,0xee,0xb8,0x14,0xde,0x5e,0x0b,0xdb,
            0xe0,0x32,0x3a,0x0a,0x49,0x06,0x24,0x5c,0xc2,0xd3,0xac,0x62,0x91,0x95,0xe4,0x79,
            0xe7,0xc8,0x37,0x6d,0x8d,0xd5,0x4e,0xa9,0x6c,0x56,0xf4,0xea,0x65,0x7a,0xae,0x08,
            0xba,0x78,0x25,0x2e,0x1c,0xa6,0xb4,0xc6,0xe8,0xdd,0x74,0x1f,0x4b,0xbd,0x8b,0x8a,
            0x70,0x3e,0xb5,0x66,0x48,0x03,0xf6,0x0e,0x61,0x35,0x57,0xb9,0x86,0xc1,0x1d,0x9e,
            0xe1,0xf8,0x98,0x11,0x69,0xd9,0x8e,0x94,0x9b,0x1e,0x87,0xe9,0xce,0x55,0x28,0xdf,
            0x8c,0xa1,0x89,0x0d,0xbf,0xe6,0x42,0x68,0x41,0x99,0x2d,0x0f,0xb0,0x54,0xbb,0x16
        };
        private readonly byte[] Rsbox = new byte[]
        {
            0x52, 0x09, 0x6a, 0xd5, 0x30, 0x36, 0xa5, 0x38, 0xbf, 0x40, 0xa3, 0x9e, 0x81, 0xf3, 0xd7, 0xfb,
            0x7c, 0xe3, 0x39, 0x82, 0x9b, 0x2f, 0xff, 0x87, 0x34, 0x8e, 0x43, 0x44, 0xc4, 0xde, 0xe9, 0xcb,
            0x54, 0x7b, 0x94, 0x32, 0xa6, 0xc2, 0x23, 0x3d, 0xee, 0x4c, 0x95, 0x0b, 0x42, 0xfa, 0xc3, 0x4e,
            0x08, 0x2e, 0xa1, 0x66, 0x28, 0xd9, 0x24, 0xb2, 0x76, 0x5b, 0xa2, 0x49, 0x6d, 0x8b, 0xd1, 0x25,
            0x72, 0xf8, 0xf6, 0x64, 0x86, 0x68, 0x98, 0x16, 0xd4, 0xa4, 0x5c, 0xcc, 0x5d, 0x65, 0xb6, 0x92,
            0x6c, 0x70, 0x48, 0x50, 0xfd, 0xed, 0xb9, 0xda, 0x5e, 0x15, 0x46, 0x57, 0xa7, 0x8d, 0x9d, 0x84,
            0x90, 0xd8, 0xab, 0x00, 0x8c, 0xbc, 0xd3, 0x0a, 0xf7, 0xe4, 0x58, 0x05, 0xb8, 0xb3, 0x45, 0x06,
            0xd0, 0x2c, 0x1e, 0x8f, 0xca, 0x3f, 0x0f, 0x02, 0xc1, 0xaf, 0xbd, 0x03, 0x01, 0x13, 0x8a, 0x6b,
            0x3a, 0x91, 0x11, 0x41, 0x4f, 0x67, 0xdc, 0xea, 0x97, 0xf2, 0xcf, 0xce, 0xf0, 0xb4, 0xe6, 0x73,
            0x96, 0xac, 0x74, 0x22, 0xe7, 0xad, 0x35, 0x85, 0xe2, 0xf9, 0x37, 0xe8, 0x1c, 0x75, 0xdf, 0x6e,
            0x47, 0xf1, 0x1a, 0x71, 0x1d, 0x29, 0xc5, 0x89, 0x6f, 0xb7, 0x62, 0x0e, 0xaa, 0x18, 0xbe, 0x1b,
            0xfc, 0x56, 0x3e, 0x4b, 0xc6, 0xd2, 0x79, 0x20, 0x9a, 0xdb, 0xc0, 0xfe, 0x78, 0xcd, 0x5a, 0xf4,
            0x1f, 0xdd, 0xa8, 0x33, 0x88, 0x07, 0xc7, 0x31, 0xb1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xec, 0x5f,
            0x60, 0x51, 0x7f, 0xa9, 0x19, 0xb5, 0x4a, 0x0d, 0x2d, 0xe5, 0x7a, 0x9f, 0x93, 0xc9, 0x9c, 0xef,
            0xa0, 0xe0, 0x3b, 0x4d, 0xae, 0x2a, 0xf5, 0xb0, 0xc8, 0xeb, 0xbb, 0x3c, 0x83, 0x53, 0x99, 0x61,
            0x17, 0x2b, 0x04, 0x7e, 0xba, 0x77, 0xd6, 0x26, 0xe1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0c, 0x7d
        };
        private readonly byte[,] Rcon = new byte[,]
        {
            {0x00, 0x00, 0x00, 0x00},
            {0x01, 0x00, 0x00, 0x00},
            {0x02, 0x00, 0x00, 0x00},
            {0x04, 0x00, 0x00, 0x00},
            {0x08, 0x00, 0x00, 0x00},
            {0x10, 0x00, 0x00, 0x00},
            {0x20, 0x00, 0x00, 0x00},
            {0x40, 0x00, 0x00, 0x00},
            {0x80, 0x00, 0x00, 0x00},
            {0x1b, 0x00, 0x00, 0x00},
            {0x36, 0x00, 0x00, 0x00}
        };
        private readonly int BlockSize = 16; // размер одного блока данных
        private readonly int KeyLength = 128; // размер ключа (в битах) 
        private readonly int Nb = 4;    // число столбцов (32-битных слов), составляющих State 
        private readonly int Nk = 4;    // число 32-битных слов, составляющих шифроключ 
        private readonly int Nr = 10;	// число раундо 
        public AES128() { }
        private void CheckInputs(string message, string pass)
        {
            if (message == null || message.Length == 0) throw new Exception("Enter the message"); if (pass == null || pass.Length == 0) throw new Exception("Enter the password"); if (pass == null || pass.Length == 0) throw new Exception("Incorrect pass");
        }

        public string Encrypt(string message, string pass)
        {
            CheckInputs(message, pass);
            var keySchedule = ExpandKey(GetPassBytes(MD5.GetMD5(pass), KeyLength)); var preparedData = PrepareInput(Encoding.UTF8.GetBytes(message)); var encryptedBytes = new byte[preparedData.Length];
            for (int i = 0; i < preparedData.Length / BlockSize; i++)
            {
                var currentBlock = new byte[BlockSize];
                Array.Copy(preparedData, i * BlockSize, currentBlock, 0, BlockSize);
                Array.Copy(Cipher(currentBlock, keySchedule), 0, encryptedBytes, i * BlockSize, BlockSize);
            }
            return Convert.ToBase64String(encryptedBytes);
        }
        public string Decrypt(string message, string pass)
        {
            CheckInputs(message, pass);
            var keySchedule = ExpandKey(GetPassBytes(MD5.GetMD5(pass), KeyLength)); var preparedData = PrepareInput(Convert.FromBase64String(message)); var decryptedBytes = new byte[preparedData.Length];
            for (int i = 0; i < preparedData.Length / BlockSize; i++)
            {
                var currentBlock = new byte[BlockSize];
                Array.Copy(preparedData, i * BlockSize, currentBlock, 0, BlockSize);
                Array.Copy(InvCipher(currentBlock, keySchedule), 0, decryptedBytes, i * BlockSize, BlockSize);
            }
            return Encoding.UTF8.GetString(decryptedBytes);
        }

        private byte[] PrepareInput(byte[] msgBytes)
        {
            var blocksCount = msgBytes.Length / BlockSize;
            if (blocksCount == 0) Array.Resize(ref msgBytes, BlockSize);
            else if (msgBytes.Length % BlockSize != 0)
            {
                Array.Resize(ref msgBytes, (blocksCount + 1) * BlockSize);
            }
            return msgBytes;
        }
        private byte[] GetPassBytes(string pass, int keyLength)
        {
            var passBytes = new byte[keyLength / 8]; var inputBytes = Encoding.UTF8.GetBytes(pass);
            Array.Copy(inputBytes, passBytes, inputBytes.Length > passBytes.Length ? passBytes.Length :
            inputBytes.Length); return passBytes;
        }
        private byte[] Cipher(byte[] input, byte[,] words)
        {
            var state = new byte[4, Nb]; var idx = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < Nb; j++) state[i, j] = input[idx++]; AddRoundKey(state, words, 0);
            for (int round = 1; round < Nr; round++)
            {
                SubBytes(state);
                ShiftRows(state);
                MixColumns(state);
                AddRoundKey(state, words, round);
            }
            SubBytes(state);
            ShiftRows(state);
            AddRoundKey(state, words, Nr); var output = new byte[4 * Nb]; idx = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < Nb; j++) output[idx++] = state[i, j];
            return output;
        }
        private byte[] InvCipher(byte[] input, byte[,] words)
        {
            var state = new byte[4, Nb]; var idx = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < Nb; j++) state[i, j] = input[idx++]; AddRoundKey(state, words, Nr);
            for (int round = Nr - 1; round > 0; round--)
            {
                ShiftRows(state, true);
                SubBytes(state, true);
                AddRoundKey(state, words, round);
                MixColumns(state, true);
            }
            ShiftRows(state, true);
            SubBytes(state, true); AddRoundKey(state, words, 0); var output = new byte[4 * Nb]; idx = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < Nb; j++) output[idx++] = state[i, j];
            return output;
        }
        private byte[,] ExpandKey(byte[] key)
        {
            byte[] SubWord(byte[] word)
            {
                for (int i = 0; i < 4; i++) word[i] = Sbox[word[i]]; return word;
            }
            byte[] RotateWord(byte[] word)
            {
                var tempWord = word[0]; for (int i = 0; i < 3; i++) word[i] = word[i + 1]; word[3] = tempWord; return word;
            }
            var temp = new byte[4]; byte[,] w = new byte[Nb * (Nr + 1), 4];
            for (int i = 0; i < Nk; i++)
                for (int j = 0; j < 4; j++) w[i, j] = key[4 * i + j];
            for (int i = Nk; i < Nb * (Nr + 1); i++)
            {
                for (int t = 0; t < 4; t++) temp[t] = w[i - 1, t];
                if (i % Nk == 0)
                {
                    temp = SubWord(RotateWord(temp)); for (int t = 0; t < 4; t++) temp[t] ^= Rcon[i / Nk, t];
                }
                else if (Nk > 6 && i % Nk == 4)
                {
                    temp = SubWord(temp);
                }
                for (int t = 0; t < 4; t++) w[i, t] = (byte)(w[i - Nk, t] ^ temp[t]);
            }
            return w;
        }
        private byte[,] SubBytes(byte[,] s, bool inv = false)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < Nb; j++) s[i, j] = inv ? Rsbox[s[i, j]] : Sbox[s[i, j]];
            return s;
        }
        private byte[,] ShiftRows(byte[,] s, bool inv = false)
        {
            var temp = new byte[4]; for (int i = 1; i < 4; i++)
            {
                for (int j = 0; j < 4; j++) temp[inv ? (i + j) % Nb : j] = s[i, inv ? j : (i + j) % Nb]; for (int k = 0; k < 4; k++) s[i, k] = temp[k];
            }
            return s;
        }
        private byte[,] MixColumns(byte[,] s, bool inv = false)
        {
            int Mul_by_02(int num)
            {
                int res;
                if (num < 0x80) res = num << 1; else res = (num << 1) ^ 0x1b; return res % 0x100;
            }
            int Mul_by_03(int num) => Mul_by_02(num) ^ num; int Mul_by_09(int num) => Mul_by_02(Mul_by_02(Mul_by_02(num))) ^ num; int Mul_by_0b(int num) => Mul_by_02(Mul_by_02(Mul_by_02(num))) ^ Mul_by_02(num) ^ num; int Mul_by_0d(int num) => Mul_by_02(Mul_by_02(Mul_by_02(num))) ^ Mul_by_02(Mul_by_02(num)) ^
            num; int Mul_by_0e(int num) => Mul_by_02(Mul_by_02(Mul_by_02(num))) ^ Mul_by_02(Mul_by_02(num)) ^
            Mul_by_02(num);
            int s0, s1, s2, s3; for (int i = 0; i < 4; i++)
            {
                if (inv)
                {
                    s0 = Mul_by_0e(s[0, i]) ^ Mul_by_0b(s[1, i]) ^ Mul_by_0d(s[2, i]) ^ Mul_by_09(s[3, i]); s1 = Mul_by_09(s[0, i]) ^ Mul_by_0e(s[1, i]) ^ Mul_by_0b(s[2, i]) ^ Mul_by_0d(s[3, i]); s2 = Mul_by_0d(s[0, i]) ^ Mul_by_09(s[1, i]) ^ Mul_by_0e(s[2, i]) ^ Mul_by_0b(s[3, i]); s3 = Mul_by_0b(s[0, i]) ^ Mul_by_0d(s[1, i]) ^ Mul_by_09(s[2, i]) ^ Mul_by_0e(s[3, i]);
                }
                else
                {
                    s0 = Mul_by_02(s[0, i]) ^ Mul_by_03(s[1, i]) ^ s[2, i] ^ s[3, i]; s1 = s[0, i] ^ Mul_by_02(s[1, i]) ^ Mul_by_03(s[2, i]) ^ s[3, i]; s2 = s[0, i] ^ s[1, i] ^ Mul_by_02(s[2, i]) ^ Mul_by_03(s[3, i]); s3 = Mul_by_03(s[0, i]) ^ s[1, i] ^ s[2, i] ^ Mul_by_02(s[3, i]);
                }
                s[0, i] = (byte)s0; s[1, i] = (byte)s1; s[2, i] = (byte)s2; s[3, i] = (byte)s3;
            }
            return s;
        }
        private byte[,] AddRoundKey(byte[,] state, byte[,] w, int round)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < Nb; j++) state[i, j] ^= w[round * 4 + j, i];
            return state;
        }
    }
    public class MD5
    {
        private readonly static uint[] T = new uint[64]
        {
        0xd76aa478,0xe8c7b756,0x242070db,0xc1bdceee,
        0xf57c0faf,0x4787c62a,0xa8304613,0xfd469501,
        0x698098d8,0x8b44f7af,0xffff5bb1,0x895cd7be,
        0x6b901122,0xfd987193,0xa679438e,0x49b40821,
        0xf61e2562,0xc040b340,0x265e5a51,0xe9b6c7aa,
        0xd62f105d,0x2441453,0xd8a1e681,0xe7d3fbc8,
        0x21e1cde6,0xc33707d6,0xf4d50d87,0x455a14ed,
        0xa9e3e905,0xfcefa3f8,0x676f02d9,0x8d2a4c8a,
        0xfffa3942,0x8771f681,0x6d9d6122,0xfde5380c,
        0xa4beea44,0x4bdecfa9,0xf6bb4b60,0xbebfbc70,
        0x289b7ec6,0xeaa127fa,0xd4ef3085,0x4881d05,
        0xd9d4d039,0xe6db99e5,0x1fa27cf8,0xc4ac5665,
        0xf4292244,0x432aff97,0xab9423a7,0xfc93a039,
        0x655b59c3,0x8f0ccc92,0xffeff47d,0x85845dd1,
        0x6fa87e4f,0xfe2ce6e0,0xa3014314,0x4e0811a1,
        0xf7537e82,0xbd3af235,0x2ad7d2bb,0xeb86d391
        };
        private enum MD5InitializerConstant : uint
        {
            A = 0x67452301,
            B = 0xEFCDAB89, C = 0x98BADCFE,
            D = 0X10325476
        }
        public static string GetMD5(string input)
        {
            var inputBytes = new byte[input.Length];
            for (int i = 0; i < input.Length; i++)
                inputBytes[i] = (byte)input[i];
            return CalculateMD5Value(inputBytes);
        }
        public static string GetMD5(byte[] input) => CalculateMD5Value(input);
        private static string CalculateMD5Value(byte[] input)
        {
            byte[] bMsg;    //буфер для хранения битов
            uint N;	//N - размер сообщения в виде слова (32 бита)
                            // создать буфер с заполненными битами, и длина также будет дополнена
            bMsg = CreatePaddedBuffer(input);
            N = (uint)(bMsg.Length * 8) / 32;   //нет 32-битных блоков
            uint A = (uint)MD5InitializerConstant.A; uint B = (uint)MD5InitializerConstant.B; uint C = (uint)MD5InitializerConstant.C; uint D = (uint)MD5InitializerConstant.D;
            for (uint i = 0; i < N / 16; i++)
            {
                var result = CopyBlock(bMsg, i);
                PerformTransformation(result, ref A, ref B, ref C, ref D);
            }
            return ReverseByte(A).ToString("X8") + ReverseByte(B).ToString("X8") + ReverseByte(C).ToString("X8") + ReverseByte(D).ToString("X8");
        }
        private static byte[] CreatePaddedBuffer(byte[] input)
        {
            uint pad;   //количество битов заполнения для 448 mod 512
            byte[] bMsg;    //буфер для хранения битов
            ulong sizeMsg;  //64-битный размер блокнота
            uint sizeMsgBuff;   //размер буфера кратный байтам
            int temp = 448 - (input.Length * 8 % 512);
            pad = (uint)((temp + 512) % 512);
            if (pad == 0)   //блокнот в битах
                pad = 512;  //можно добавить минимум 1 или максимум 512
            sizeMsgBuff = (uint)((input.Length) + (pad / 8) + 8); 
            sizeMsg = (ulong)input.Length * 8; 
            bMsg = new byte[sizeMsgBuff];
            for (int i = 0; i < input.Length; i++)
                bMsg[i] = input[i]; bMsg[input.Length] |= 0x80;
            for (int i = 8; i > 0; i--)
                bMsg[sizeMsgBuff - i] = (byte)(sizeMsg >> ((8 - i) * 8) & 0x00000000000000ff);
            return bMsg;
        }
        private static uint[] CopyBlock(byte[] bMsg, uint block)
        {
            uint[] X = new uint[16]; block <<= 6; for (uint j = 0; j < 61; j += 4)
            {
                X[j >> 2] = (((uint)bMsg[block + j + 3]) << 24) |
                (((uint)bMsg[block + j + 2]) << 16) | (((uint)bMsg[block + j + 1]) << 8) | bMsg[block + (j)];
            }
            return X;
        }
        private static void PerformTransformation(uint[] x, ref uint A, ref uint B, ref uint C, ref uint D)
        {
            uint AA, BB, CC, DD;
            AA = A;
            BB = B;
            CC = C;
            DD = D;

            TransF(x, ref A, B, C, D, 0, 7, 1); TransF(x, ref D, A, B, C, 1, 12, 2); TransF(x, ref C, D, A, B, 2, 17, 3); TransF(x, ref B, C, D, A, 3, 22, 4);
            TransF(x, ref A, B, C, D, 4, 7, 5); TransF(x, ref D, A, B, C, 5, 12, 6); TransF(x, ref C, D, A, B, 6, 17, 7);
            TransF(x, ref B, C, D, A, 7, 22, 8);
            TransF(x, ref A, B, C, D, 8, 7, 9); TransF(x, ref D, A, B, C, 9, 12, 10); TransF(x, ref C, D, A, B, 10, 17, 11);
            TransF(x, ref B, C, D, A, 11, 22, 12);
            TransF(x, ref A, B, C, D, 12, 7, 13); TransF(x, ref D, A, B, C, 13, 12, 14); TransF(x, ref C, D, A, B, 14, 17,
            15); TransF(x, ref B, C, D, A, 15, 22, 16);

            TransG(x, ref A, B, C, D, 1, 5, 17); TransG(x, ref D, A, B, C, 6, 9, 18); TransG(x, ref C, D, A, B, 11, 14, 19);
            TransG(x, ref B, C, D, A, 0, 20, 20);
            TransG(x, ref A, B, C, D, 5, 5, 21); TransG(x, ref D, A, B, C, 10, 9, 22); TransG(x, ref C, D, A, B, 15, 14,
            23); TransG(x, ref B, C, D, A, 4, 20, 24);
            TransG(x, ref A, B, C, D, 9, 5, 25); TransG(x, ref D, A, B, C, 14, 9, 26); TransG(x, ref C, D, A, B, 3, 14, 27); TransG(x, ref B, C, D, A, 8, 20, 28);
            TransG(x, ref A, B, C, D, 13, 5, 29); TransG(x, ref D, A, B, C, 2, 9, 30); TransG(x, ref C, D, A, B, 7, 14, 31);
            TransG(x, ref B, C, D, A, 12, 20, 32);

            TransH(x, ref A, B, C, D, 5, 4, 33); TransH(x, ref D, A, B, C, 8, 11, 34); TransH(x, ref C, D, A, B, 11, 16,
            35); TransH(x, ref B, C, D, A, 14, 23, 36);
            TransH(x, ref A, B, C, D, 1, 4, 37); TransH(x, ref D, A, B, C, 4, 11, 38); TransH(x, ref C, D, A, B, 7, 16, 39);
            TransH(x, ref B, C, D, A, 10, 23, 40);
            TransH(x, ref A, B, C, D, 13, 4, 41); TransH(x, ref D, A, B, C, 0, 11, 42); TransH(x, ref C, D, A, B, 3, 16,
            43); TransH(x, ref B, C, D, A, 6, 23, 44);
            TransH(x, ref A, B, C, D, 9, 4, 45); TransH(x, ref D, A, B, C, 12, 11, 46); TransH(x, ref C, D, A, B, 15, 16,
            47); TransH(x, ref B, C, D, A, 2, 23, 48);

            TransI(x, ref A, B, C, D, 0, 6, 49); TransI(x, ref D, A, B, C, 7, 10, 50); TransI(x, ref C, D, A, B, 14, 15, 51);
            TransI(x, ref B, C, D, A, 5, 21, 52);
            TransI(x, ref A, B, C, D, 12, 6, 53); TransI(x, ref D, A, B, C, 3, 10, 54); TransI(x, ref C, D, A, B, 10, 15, 55);
            TransI(x, ref B, C, D, A, 1, 21, 56);
            TransI(x, ref A, B, C, D, 8, 6, 57); TransI(x, ref D, A, B, C, 15, 10, 58); TransI(x, ref C, D, A, B, 6, 15, 59); TransI(x, ref B, C, D, A, 13, 21, 60);
            TransI(x, ref A, B, C, D, 4, 6, 61); TransI(x, ref D, A, B, C, 11, 10, 62); TransI(x, ref C, D, A, B, 2, 15, 63); TransI(x, ref B, C, D, A, 9, 21, 64);
            A += AA;
            B += BB;
            C += CC;
            D += DD;
        }
        private static void TransF(uint[] X, ref uint a, uint b, uint c, uint d, uint k, ushort s, uint i) => a = b + RotateLeft((a + ((b & c) | (~b & d)) + X[k] + T[i - 1]), s);
        private static void TransG(uint[] X, ref uint a, uint b, uint c, uint d, uint k, ushort s, uint i) => a = b + RotateLeft(a + ((b & d) | (c & ~d)) + X[k] + T[i - 1], s);
        private static void TransH(uint[] X, ref uint a, uint b, uint c, uint d, uint k, ushort s, uint i) => a = b + RotateLeft(a + (b ^ c ^ d) + X[k] + T[i - 1], s);
        private static void TransI(uint[] X, ref uint a, uint b, uint c, uint d, uint k, ushort s, uint i) => a = b + RotateLeft(a + (c ^ (b | ~d)) + X[k] + T[i - 1], s);
        private static uint RotateLeft(uint uiNumber, ushort shift) => ((uiNumber >> 32 - shift) | (uiNumber << shift));
        private static uint ReverseByte(uint uiNumber) => ((uiNumber & 0x000000ff) << 24) | (uiNumber >> 24) | ((uiNumber & 0x00ff0000) >> 8) | ((uiNumber & 0x0000ff00) << 8);
    }
}