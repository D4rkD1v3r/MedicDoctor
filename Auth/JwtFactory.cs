using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using rmi.medicine.doctor.Auth;
using rmiMedicineDoctor.Models;

namespace rmiMedicineDoctor.Auth
{
  /// <summary>
  /// Обработка токенов.
  /// </summary>
  public class JwtFactory : IJwtFactory
  {
    private readonly JwtIssuerOptions _jwtOptions;

    public JwtFactory(IOptions<JwtIssuerOptions> jwtOptions)
    {
      _jwtOptions = jwtOptions.Value;
      ThrowIfInvalidOptions(_jwtOptions);
    }
    /// <summary>
    /// Генерация токена.
    /// </summary>
    /// <param name="userName">Имя пользователя.</param>
    /// <param name="identity">Набор разрешений.</param>
    /// <returns>Сгенерированный токен.</returns>
    public async Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity)
    {
      var claims = new[]
      {
        new Claim(JwtRegisteredClaimNames.Sub, userName),
        new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
        new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
        identity.FindFirst(ClaimConsts.RoleClaimName),
        identity.FindFirst(ClaimConsts.IdClaimName)
      };

      // Create the JWT security token and encode it.
      var jwt = new JwtSecurityToken(
        issuer: _jwtOptions.Issuer,
        audience: _jwtOptions.Audience,
        claims: claims,
        notBefore: _jwtOptions.NotBefore,
        expires: _jwtOptions.Expiration,
        signingCredentials: _jwtOptions.SigningCredentials);

      var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

      return encodedJwt;
    }
    /// <summary>
    /// Генерация набора разрешений.
    /// </summary>
    /// <param name="userName">Имя пользователя.</param>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <returns>Набор разрешений.</returns>
    public ClaimsIdentity GenerateClaimsIdentity(string userName, string id)
    {
      return new ClaimsIdentity(new GenericIdentity(userName, "Token"), new[]
      {
        new Claim(ClaimConsts.IdClaimName, id),
        new Claim(ClaimConsts.RoleClaimName, "api_access")
      });
    }

    /// <summary>
    /// Преобразование даныв количество секунд с эпохи Unix.
    /// </summary>
    /// <param name="date">Дата.</param>
    /// <returns>Количество секунд прошедших с 01.01.1970</returns>
    private static long ToUnixEpochDate(DateTime date)
      => (long)Math.Round((date.ToUniversalTime() -
                           new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
        .TotalSeconds);

    /// <summary>
    /// Проверка опций для Jwt токена.
    /// </summary>
    /// <param name="options">Опции создания токена.</param>
    private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
    {
      if (options == null) throw new ArgumentNullException(nameof(options));

      if (options.ValidFor <= TimeSpan.Zero)
      {
        throw new ArgumentException("Должен быть задан не нулевой промежуток времени.", nameof(JwtIssuerOptions.ValidFor));
      }

      if (options.SigningCredentials == null)
      {
        throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
      }

      if (options.JtiGenerator == null)
      {
        throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
      }
    }
  }
}
