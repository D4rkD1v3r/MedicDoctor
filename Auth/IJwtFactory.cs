using System.Security.Claims;
using System.Threading.Tasks;

namespace rmi.medicine.doctor.Auth
{
  /// <summary>
  /// Интерфейс генератора токенов.
  /// </summary>
  public interface IJwtFactory
  {
    /// <summary>
    /// Генерация токена.
    /// </summary>
    /// <param name="userName">Имя пользователя.</param>
    /// <param name="identity">Набор разрешений.</param>
    /// <returns>Сгенерированный токен.</returns>
    Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
    /// <summary>
    /// Генерация набора разрешений.
    /// </summary>
    /// <param name="userName">Имя пользователя.</param>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <returns>Набор разрешений.</returns>
    ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
  }
}
