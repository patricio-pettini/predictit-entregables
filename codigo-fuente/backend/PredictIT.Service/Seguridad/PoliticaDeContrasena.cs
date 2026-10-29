using System.Security.Cryptography;

namespace PredictIT.Service.Seguridad;

/// <summary>
/// Qué contraseña se acepta y cómo se genera la temporal del alta (RF-02,
/// CU-002, OWASP A07).
///
/// La regla es la del largo y no la de los símbolos obligatorios: la guía de
/// la OWASP —y la NIST SP 800-63B, que es su fuente— desaconseja exigir
/// combinaciones de caracteres, porque producen «Clave2026!» y no contraseñas
/// más difíciles. Lo que sí se exige es largo, que tenga letras y números, y
/// que no sea el propio nombre de usuario.
/// </summary>
public static class PoliticaDeContrasena
{
    public const int Minimo = 10;
    public const int Maximo = 128;

    /// <summary>
    /// Sin caracteres que se confunden al dictarla o leerla de una pantalla:
    /// ni 0/O, ni 1/l/I. La temporal la transcribe una persona.
    /// </summary>
    private const string Letras = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
    private const string Numeros = "23456789";

    /// <summary>El motivo por el que se rechaza, o null si se acepta.</summary>
    public static string? Validar(string? contrasena, string username)
    {
        if (string.IsNullOrEmpty(contrasena) || contrasena.Length < Minimo)
            return $"La contraseña tiene que tener al menos {Minimo} caracteres.";

        if (contrasena.Length > Maximo)
            return $"La contraseña no puede pasar de {Maximo} caracteres.";

        if (!contrasena.Any(char.IsLetter) || !contrasena.Any(char.IsDigit))
            return "La contraseña tiene que combinar letras y números.";

        if (contrasena.Contains(username, StringComparison.OrdinalIgnoreCase))
            return "La contraseña no puede contener el nombre de usuario.";

        return null;
    }

    /// <summary>
    /// Una contraseña temporal de doce caracteres, con letras y números, sacada
    /// de un generador criptográfico. Cumple la política, así que el usuario
    /// puede entrar con ella; y la sesión que abre no tiene patentes hasta que
    /// la cambie.
    /// </summary>
    public static string GenerarTemporal()
    {
        var alfabeto = Letras + Numeros;
        Span<char> salida = stackalloc char[12];

        for (var i = 0; i < salida.Length; i++)
            salida[i] = alfabeto[RandomNumberGenerator.GetInt32(alfabeto.Length)];

        // Garantiza los dos tipos en posiciones al azar: con doce caracteres
        // sacados de 56 la probabilidad de que falte uno es baja, pero no cero.
        salida[RandomNumberGenerator.GetInt32(0, 6)] = Letras[RandomNumberGenerator.GetInt32(Letras.Length)];
        salida[RandomNumberGenerator.GetInt32(6, 12)] = Numeros[RandomNumberGenerator.GetInt32(Numeros.Length)];

        return new string(salida);
    }
}
