using System.Text;
public static class TelemetryBuffer
{
    private static int bytesInInt64 = 8;
    private static int bytesInInt32 = 4;
    private static int bytesInInt16 = 2;    
    
    public static byte[] ToBuffer(long reading)
    {
        byte[] bytes = new byte[0];
        int prefix = 0;
        
        if(reading > uint.MaxValue && reading <= Int64.MaxValue)
        {
            bytes = BitConverter.GetBytes((long)reading);
            prefix = 256 - bytesInInt64;
        }
        else if(reading > Int32.MaxValue && reading <= uint.MaxValue)
        {
            bytes = BitConverter.GetBytes((uint)reading);
            prefix = bytesInInt32;
        }
        else if(reading > ushort.MaxValue && reading <= Int32.MaxValue)
        {
            bytes = BitConverter.GetBytes((int)reading);
            prefix = 256 - bytesInInt32;
        }
        else if(reading >= 0 && reading <= ushort.MaxValue)
        {
            bytes = BitConverter.GetBytes((ushort)reading);
            prefix = bytesInInt16;
        }
        else if(reading >= Int16.MinValue && reading < 0)//FAILS
        {
            bytes = BitConverter.GetBytes((short)reading);
            prefix = 256 - bytesInInt16;
        }
        else if(reading >= Int32.MinValue && reading < Int16.MinValue)//FAILS
        {
            bytes = BitConverter.GetBytes((int)reading);
            prefix = 256 - bytesInInt32;
        }
        else if(reading >= Int64.MinValue && reading < Int32.MinValue)
        {
            bytes = BitConverter.GetBytes((long)reading);
            prefix = 256 - bytesInInt64;
        }

        byte[] newArray = new byte[9];
        bytes.CopyTo(newArray, 1);
        newArray[0] = (byte)prefix;
        
        return newArray;
    }

    public static long FromBuffer(byte[] buffer)
    {
        int prefix = buffer[0];
        bool isSigned = false;
        if(buffer[0] > bytesInInt64)
        {
            prefix = 256 - prefix;
            isSigned = true;
        }

        if(prefix == bytesInInt16)
        {
            if(isSigned)
            {
                return BitConverter.ToInt16(buffer, 1);
            }
            else
            {
                return BitConverter.ToUInt16(buffer, 1);
            }
        }
        else if(prefix == bytesInInt32)
        {
            if(isSigned)
            {
                return BitConverter.ToInt32(buffer, 1);
            }
            else
            {
                return BitConverter.ToUInt32(buffer, 1);
            }
        }
        else if(prefix == bytesInInt64)
        {
            return BitConverter.ToInt64(buffer, 1);
        }

        return 0;
    }
}
