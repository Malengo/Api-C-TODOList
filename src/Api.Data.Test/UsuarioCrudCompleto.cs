using Api.Data.Context;
using Api.Data.Implemention;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Crud de usuário")]
        [Trait("Crud", "UserEntity")]
        public async Task E_Possivel_realizar_Crud_Usuario()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context);
                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName(),
                    Senha = "1234"

                };
                var _resgistroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_resgistroCriado);
                Assert.Equal(_entity.Email, _resgistroCriado.Email);
                Assert.Equal(_entity.Name, _resgistroCriado.Name);
                Assert.False(_resgistroCriado.Id == Guid.Empty);

                _entity.Name = Faker.Name.First();
                var _resgistroAlterado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(_resgistroAlterado);
                Assert.Equal(_entity.Email, _resgistroAlterado.Email);
                Assert.Equal(_entity.Name, _resgistroAlterado.Name);

                var _resgistroExiste = await _repositorio.SelectAsync(_resgistroAlterado.Id);
                Assert.Equal(_resgistroAlterado, _resgistroExiste);

                var _todosUser = await _repositorio.SelectAllAsync();
                Assert.NotNull(_todosUser);
                Assert.True(_todosUser.Count() > 0);

                var _findByEmail = await _repositorio.FingByEmail(_resgistroAlterado.Email);
                Assert.NotNull(_findByEmail);
                Assert.Equal(_resgistroAlterado.Email, _findByEmail.Email);
                Assert.Equal(_resgistroAlterado.Name, _findByEmail.Name);


                var _deletado = await _repositorio.DeleteAsync(_resgistroAlterado.Id);
                Assert.True(_deletado);
            }
        }
    }
}
