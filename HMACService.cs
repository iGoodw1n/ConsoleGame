using System.Security.Cryptography;
using System.Text;

namespace Game;

public static class HMACService
{
    public static byte[] GenerateHMACKey(int keyLengthBytes)
    {
        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        byte[] key = new byte[keyLengthBytes];
        rng.GetBytes(key);
        return key;
    }

    public static string SignComputerMove(byte[] keyBytes, string move)
    {
        byte[] messageBytes = Encoding.UTF8.GetBytes(move);

        using var hmac = new HMACSHA256(keyBytes);
        byte[] hashBytes = hmac.ComputeHash(messageBytes);

        string hashHex = BitConverter.ToString(hashBytes).Replace("-", "");
        return hashHex;
    }
}
