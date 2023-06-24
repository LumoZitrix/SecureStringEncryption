# SecureStringEncryption
Secure encryption w/o API, SecureString + byte array hidden from memory. (NativeAot comp.)

Features:
- Strong Random Iterations
- password to derive the key
- Random IV
- Random Salt
- Validate HMAC
- Constant Time Comparison protection
- Custom Memory Cleaner (anti-process hacker)
- (password and decrypted string never stay in memory)
- Strong SHA (512)
- Simple Config
- Secure Encryption Byte
- Secure Decryption Byte
- Modular Code
- Secure byte secure string
- ( no dependencies or nugets  )

Type of encryption
- aes.KeySize = 256;
- aes.BlockSize = 128;
- aes.Mode = CipherMode.CBC;
- aes.Padding = PaddingMode.PKCS7;

![image](https://github.com/LumoZitrix/SecureStringEncryption/assets/66798139/bc2ddc68-070c-4dfc-97b0-568a214da879)
