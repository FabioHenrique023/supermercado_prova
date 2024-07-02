using System.Security.Cryptography;
using System.Text;

public class Hash
{
    private HashAlgorithm hashAlgorithm;

    public Hash(HashAlgorithm algorithm = null) {
        this.hashAlgorithm = algorithm ?? SHA256.Create();
    }

    public string CriptografarSenha(string senha) {
        var encodedValue = Encoding.UTF8.GetBytes(senha);
        var encryptedSenha = this.hashAlgorithm.ComputeHash(encodedValue);

        var sb = new StringBuilder();

        foreach (var s in encryptedSenha)
        {
            sb.Append(s.ToString("X2"));
        }

        return sb.ToString();
    }

    public bool validarSenha(string senha, string senhaCad) {
        var senhaDigCrip = this.CriptografarSenha(senha);
        return senhaDigCrip.Equals(senhaCad);
    }

    internal bool validarSenha(string senha1, object senha2)
    {
        throw new NotImplementedException();
    }
}