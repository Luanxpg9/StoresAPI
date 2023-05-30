
# API para gerenciamento de lojas, estoque, funcionarios e vendas.
> Esse projeto foi desenvolvido para acompanhar meus conhecimentos e me desafiar com um projeto iterativo incremental
No momento ainda falta muito a ser feito comparado com ao que planejei

## Como rodar (Para testes)
1. Adicionar/Alterar a variavel de ambiente "LOCAL_SQL" nas váriaveis de ambiente com a conexão ao banco SQL
2. Pelo VS Studio Ferramentas>Console do gerenciador de pacotes
3. Altere o projeto padrão no console para StoresAPI.Domain
4. Execute o comando Update-Database
5. Defina o projeto StoresAPI.WebApp como projeto de inicialização
6. Execute o projeto (F5)

# IN DEVELOPMENT
---
# TO DO List
> Lista para acompanhar o desenvolvimento da StoreAPI

### Model

- [X] Instacializar uma versao do SQL Server no container
    - O sql server ja estava instalado localmente
- [X] Instalar o MSSMS
    - O MSSMS ja estava instalado na versão 2019
- [X] Criar os Models
    - [X] Users
    - [X] Stores
    - [X] UserStore


### Repository, Context & Migrations
- [X] Configurar os IsUnique 
    - [X] Users
    - [X] Stores
    - (Data Annotations não permite configurar diretamente o banco com IsUnique)
- [X] Instancializar as primeiras migrations
    - [X] Definir o tamanho das strings para não ficar nvarchar(max) nas migrations
    - [X] Definir o tipo da coluna para Enums
- [X] Analisar as tabelas no banco
- [X] Criar o Base Repository
- [X] Implementar o Base Repository
- [X] Implementar o User Repository
- [ ] 

### Manager
- [X] Criar o UserManager
- [ ] Criar o RoleManager (Permissoes: UserStore)
- [ ] Crair o StoreManager

### Controller
- [ ] Criar o UserController
- [ ] Criar o StoreController
- [ ] Criar o RoleController

---
### Para fazer:
- [ ] Adicionar detalhes no swagger dos controllers ja existentes
- [ ] Implementar as Sessões
- [ ] Adicionar autenticação
- [ ] Implementar as autorizações por rota e por cargo
- [ ] Adicionar autorização
- [ ] Implementar a adição de itens por loja
- [ ] Implementar a venda de itens
- [ ] Adicionar validação de vendas utilizando um Consumer e Producer com RabbitMQ
- [ ] Melhorar o readme
- [ ] Melhorar o dockerfile
- [ ] Criar um docker compose para inicializar o rabbit, o sql server e a aplicação
