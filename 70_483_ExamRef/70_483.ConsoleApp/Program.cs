using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _70_483.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) AES Symetric  ");
            Console.WriteLine("2) RSA ");
            Console.WriteLine("3) User Level Key Store ");
            Console.WriteLine("4) Machine Level key store ");
            Console.WriteLine("5) Signing Documents ");
            Console.WriteLine("6) CheckSum");
            Console.WriteLine("7) ShowHash");
            Console.WriteLine("8) SHA2");
            Console.WriteLine("9) Double Encryting");
            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");
           
            switch (Console.ReadLine())
            {
                case "1":

                    string plainText = "This is super secret";

                    //byte array to hold the encryted message
                    byte[] cipherText;

                    //byte array to hold the key that was used for the encryption
                    byte[] key;

                    //byte array to hold the initialization vector that was used for encryption
                    byte[] initializationVector;

                    //create AES instance
                    // this creates a random key and initialization vector
                    // usyng System.Crypography
                    using (Aes aes = Aes.Create())
                    {
                        // copy the key and initialization vector
                        key = aes.Key;
                        initializationVector = aes.IV;

                        //create an encryptor to encrypt some data
                        // should be wrapped in using for production code 
                        ICryptoTransform encryptor = aes.CreateEncryptor();

                        //Create  memory stream to receive the encrypted data
                        using (MemoryStream encryptMemoryStream = new MemoryStream())
                        {
                            //creatre a CryptoStream, tell it the stream to write to 
                            // and the encryptor to use. Also set the mode
                            using (CryptoStream encryptCrypoStream =
                                new CryptoStream(encryptMemoryStream, encryptor, CryptoStreamMode.Write))
                            {

                                //make a stremWriter from the cryptoStream
                                using (StreamWriter swEncrypt = new StreamWriter(encryptCrypoStream))
                                {
                                    swEncrypt.Write(plainText);
                                }
                                //get the encrypted message from the stream
                                cipherText = encryptMemoryStream.ToArray();
                            }
                        }
                    } // end

                    // dump out Data
                    Console.WriteLine("String to encrypt: {0} ", plainText );
                    DumpBytes("Key: ", key);
                    DumpBytes("Initial vector: ", initializationVector);
                    DumpBytes("Encryoted: ", cipherText);


                    //Decrypt

                    // Decrypt AES

                    string decryptedText;

                    using (Aes aes = Aes.Create())
                    {
                        // Configure the isntances with the key
                        // and intialization Vector
                        aes.Key = key;
                        aes.IV = initializationVector;

                        //create a Decryptor from aes
                        // should be wrapped in using for production code
                        ICryptoTransform decryptor = aes.CreateDecryptor();

                        using (MemoryStream decryptStream = new MemoryStream(cipherText))
                        {

                            using (CryptoStream decryptCryptoStream =
                                new CryptoStream(decryptStream, decryptor, CryptoStreamMode.Read))
                            {
                                using (StreamReader srDecrypt = new StreamReader(decryptCryptoStream))
                                {
                                    decryptedText = srDecrypt.ReadToEnd();
                                }
                            }
                        }

                        //
                        Console.WriteLine("decrypted: {0}", decryptedText);
                    }


                    Console.WriteLine("finishing AES Encrypt");
                    Console.ReadKey();
                    return true;

                case "2":
                    // RSA

                    string plainText2 ="THis is RSA Text";
                    Console.WriteLine("Plain Text: {0}", plainText2);

                    //RSA works on byte arrays , not string of text
                    // this will convert out Input string into bytes and back

                    ASCIIEncoding converter = new ASCIIEncoding();

                    //convert a plant text into a byte array
                    byte[] plainBytes = converter.GetBytes(plainText2);

                    DumpBytes("Pain bytes:", plainBytes);

                    byte[] encryptedBytes;
                    byte[] decryptedBytes;

                    //creste a new RSA to encryp the data
                    //should be wrapped using the production code
                    RSACryptoServiceProvider rsaEncrypt = new RSACryptoServiceProvider();

                    //get the keys out of the encrypter
                    string publicKey = rsaEncrypt.ToXmlString(includePrivateParameters: false);
                    Console.WriteLine("Public key: {0}", publicKey);
                    string privateKey = rsaEncrypt.ToXmlString(includePrivateParameters: true);
                    Console.WriteLine("Pirvete key: {0}", privateKey);

                    //now tell the encryptor to use the PUBLIC KEY to encrpt the data
                    rsaEncrypt.FromXmlString(publicKey);
                   // rsaEncrypt.FromXmlString(privateKey);

                    // use the encryptor to encryopt the Data. 
                    // the f0AEP parameter specifies how the output is "padded" with extra bytes
                    // For maximum compatibility with receiving system , set this to FALSE
                    encryptedBytes = rsaEncrypt.Encrypt(plainBytes, fOAEP: false);

                    DumpBytes("Encryoted bytes: ", encryptedBytes);

                    // now do the DECODE -use the private key for this
                    // we have sent someone our public key and they
                    // have used this to encrypt data that they are sendung to US

                    //Create a new RSA to DECRYOPT THE DATA
                    // should be wrapped in using for production  code

                    RSACryptoServiceProvider rsaDecryp = new RSACryptoServiceProvider();

                    // configure de decryptor from  the XML in the private key
                    rsaDecryp.FromXmlString(privateKey);

                    decryptedBytes = rsaDecryp.Decrypt(encryptedBytes, false);

                    Console.WriteLine("Decrypted string: {0}", converter.GetString(decryptedBytes));



                    Console.WriteLine("finishing RSA");
                    Console.ReadKey();
                    return true;

                case "3":
                    // User level key store

                    string containerName = "MyKeyStore";

                    CspParameters csp = new CspParameters();
                    csp.KeyContainerName = containerName;

                    //create new RSA to encrypt the data
                    // passes the parameter CSP 
                    RSACryptoServiceProvider rsaStore = new RSACryptoServiceProvider(csp);
                    Console.WriteLine("Stored key: {0}", rsaStore.ToXmlString(true));

                    //Load the same Key
                    RSACryptoServiceProvider rsaLoad = new RSACryptoServiceProvider(csp);
                    Console.WriteLine("Loaded key: {0}", rsaLoad.ToXmlString(true));

                    //DELETE A STORED KEY
                    rsaStore.PersistKeyInCsp = false;
                    rsaStore.Clear();

                    Console.WriteLine("finishing RSA");
                    Console.ReadKey();
                    return true;

                case "4":
                    // Machine level key store

                    CspParameters cspParams = new CspParameters();
                    cspParams.KeyContainerName = "Machine Level Key";

                    //scpecify that the is to be stored in the machine level key store
                    cspParams.Flags = CspProviderFlags.UseMachineKeyStore;

                    //create a cryptoservice provider
                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParams);

                    Console.WriteLine(rsa.ToXmlString(false)); // set to false

                    // make sure taht it persists the key
                    rsa.PersistKeyInCsp = true;
                    // clear the provider to make sure it saves the key
                    rsa.Clear();

                    Console.WriteLine("finishing machine Store key");
                    Console.ReadKey();
                    return true;
                case "5":
                    // Signing Documents  249

                    //This Convert out input string into bytes and back
                    ASCIIEncoding converter5 = new ASCIIEncoding();

                    // get crypto provider out of gthe certificate store
                    // should be wrraped
                    X509Store store = new X509Store("demoCertStore", StoreLocation.CurrentUser);

                    store.Open(OpenFlags.ReadOnly);

                    X509Certificate2 certificate = store.Certificates[0];

                    // provate key from certificate as a Provider
                    RSACryptoServiceProvider encryptProvider = certificate.PrivateKey as RSACryptoServiceProvider;

                    string messageToSign = "This is the message";
                    Console.WriteLine("This is the message: {0}",messageToSign);

                    byte[] messageToSignBytes = converter5.GetBytes(messageToSign);
                    DumpBytes("Message to sign in bytes: ", messageToSignBytes);

                    // need to calculate the hash for this message -this will go into the
                    // signature and be used to verify  the messafe
                    // create an implememtation of the hashing algorithm we are going to use
                    // ..wrapped
                    HashAlgorithm hasher = new SHA1Managed();
                    // Use the hasher to hash the message
                    byte[] hash = hasher.ComputeHash(messageToSignBytes);

                    //now sign the hash to create a signature
                    byte[] signature = encryptProvider.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
                    DumpBytes("Signature: ", signature);
                    Console.WriteLine("Base64: {0} ", Convert.ToBase64String(signature));

                    //we can send the signature along with the message to authenticate it
                    //create a decryptor that uses a public key

                    RSACryptoServiceProvider rsaDecryptProvider = certificate.PublicKey.Key as RSACryptoServiceProvider;

                    //now use the signature to perform a successful validation of the message
                    bool validSignature = rsaDecryptProvider.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);

                    if (validSignature)
                        Console.WriteLine("Correct: {0}", validSignature);

                    //Change one byte of the signature
                    signature[0] = 99;
                    //now try the using the incorrect signature to validate the message
                    bool inValidSignature = rsaDecryptProvider.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);
                    Console.WriteLine("Invalid: {0}", inValidSignature);
                   


                    Console.WriteLine("finishing Signing Documents");
                    Console.ReadKey();
                    return true;

                case "6":
                    // CheckSum

                    showCheckSum("Hello world");
                    showCheckSum("world Hello");
                    showCheckSum("Hemmm world");

                    Console.WriteLine("finishing CheckSum");
                    Console.ReadKey();
                    return true;

                case "7":
                    // Showhash
                    //All c# objects provides a GetHash

                    Console.Write("Hash for Hello world : ");
                    showHash("Hello world");
                    Console.Write("Hash for world Hello : ");
                    showHash("world Hello");


                    Console.WriteLine("finishing CheckSum");
                    Console.ReadKey();
                    return true;

                case "8":
                    // SHA2
                    showHash8("Hello world");
                    showHash8("world Hello");
                    showHash8("Hemmm world");

                    Console.WriteLine("finishing SHA2");
                    Console.ReadKey();
                    return true;
                case "9":
                    // Double Encrypting

                    string plaintText = "This is my super super data";

                    //byte array to hold the message
                    byte[] encryptedtext;

                    // bytes arrays to hold the keys that was used for encryption
                    byte[] key1;
                    byte[] key2;

                    //byte array to hold the initialization vector that was used for encryption
                    byte[] initializationVector1;
                    byte[] initializationVector2;

                    using (Aes aes1 = Aes.Create())
                    {
                        //copy the key and the initialization vector
                        key1 = aes1.Key;
                        initializationVector1 = aes1.IV;

                        //create an encryptor to encrypt some data
                        ICryptoTransform encryptor1 = aes1.CreateEncryptor();

                        //create a memoryStream to receive the data
                        using (MemoryStream encrypMemoryStream = new MemoryStream())
                        {
                            //create a cryptoStream, tell it the stream to write to
                            // and the encryptor to use. Also set the mode
                            using (CryptoStream crytoStream1 =
                                new CryptoStream(encrypMemoryStream, encryptor1, CryptoStreamMode.Write))
                            {

                                // add another LAYER OF ENCRYPTION
                                using (Aes aes2 = Aes.Create())
                                {
                                    key2 = aes2.Key;
                                    initializationVector2 = aes2.IV;

                                    ICryptoTransform encryptor2 = aes1.CreateEncryptor();
                                    // uses crytoStream1 instead of MemoryStream
                                    using (CryptoStream cryptoStream2 =
                                        new CryptoStream(crytoStream1, encryptor2, CryptoStreamMode.Write))
                                    {
                                        using (StreamWriter sWriter = new StreamWriter(cryptoStream2))
                                        {
                                            //write the secret message to the Strema
                                            sWriter.Write(plaintText);
                                        }
                                    }

                                    //get the encrypted message  from the stream
                                    encryptedtext = encrypMemoryStream.ToArray();
                                }
                            }
                        }
                    }

                        Console.WriteLine("finishing Double Encrypting");
                    Console.ReadKey();
                    return true;
                case "99":
                    Environment.Exit(0);
                    return true;
                default:
                    return true;
            }
        }

        static void DumpBytes(string title, byte[] bytes)
        {
            Console.WriteLine(title );
            foreach (byte b in bytes)
            {
                Console.Write("{0:X} ", b);
            }
            Console.WriteLine();
        }

        //checksum
        public static int calculateCheckSum(string source)
        {
            int total = 0;
            List<byte> listByte = new List<byte>();

            foreach (char ch in source)
            {
                total = total + (int)ch;
                // listByte.Add(Convert.ToByte((int)ch)); // check values
            }
            return total;
        }

        static void showCheckSum(string source)
        {
            Console.WriteLine("Checksum for {0} is {1}" , source, calculateCheckSum(source));
        }

        // showhash
        static void showHash(object source)
        {
            Console.WriteLine("Has for {0} is {1:X} " , source, source.GetHashCode());
        }

        // 8 SHA2
        static byte[] calculateHash8(string source)
        {
            //This Convert out input string into bytes and back
            ASCIIEncoding converter8 = new ASCIIEncoding();
            byte[] sourceBytes = converter8.GetBytes(source);

            HashAlgorithm hasher = SHA256.Create();
            byte[] hash = hasher.ComputeHash(sourceBytes);
            return hash;
        }

        static void showHash8(string source)
        {
            Console.WriteLine("hash for {0}:", source);

            byte[] hash = calculateHash8(source);

            foreach (byte  b in hash)
            {
                Console.Write("{0:X}",b);
            }
            Console.WriteLine();
            Console.WriteLine("base 64:");
            Console.WriteLine(Convert.ToBase64String(hash));

        }


    }


}
