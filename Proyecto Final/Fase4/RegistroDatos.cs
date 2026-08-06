public struct RegistroDatos
{
    public int Id;
    public string HashValidacion;
    public double PesoBytes;

    /// Constructor con validación de dominio.
    /// Garantiza que ningún registro inválido ingrese al arreglo de prueba.
    /// Las excepciones son fail-fast: detectan errores en tiempo de construcción en lugar de propagar datos corruptos silenciosamente.
    
    public RegistroDatos(int id, string hashValidacion, double pesoBytes)
    {
        // Validar Id: debe ser positivo (no cero, no negativo)
        if (id <= 0)
        throw new ArgumentException(
        "El Id debe ser un entero positivo mayor que cero.", nameof(id));
        // Validar HashValidacion: no null, no vacío
        if (string.IsNullOrEmpty(hashValidacion))
        throw new ArgumentNullException(
        nameof(hashValidacion),
        "HashValidacion no puede ser null ni una cadena vacía.");
        // Validar PesoBytes: debe ser positivo
        if (pesoBytes <= 0.0)
        throw new ArgumentOutOfRangeException(
        nameof(pesoBytes),
        "PesoBytes debe ser un valor numérico positivo mayor que cero.");
        Id = id;
        HashValidacion = hashValidacion;
        PesoBytes = pesoBytes;
    }

    /// Representación de cadena para depuración y logging.
    /// No usar en rutas de código críticas de rendimiento.
    public override string ToString() =>
    $"[Id={Id}, Hash={HashValidacion[..8]}..., Peso={PesoBytes:F2}B]";
}