# IN DEVELOPMENT
> Try not to take it too serious
---
---
# TO DO List
> Lista para acompanhar o desenvolvimento da StoreAPI


---
## Construindo uma bicicleta

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
- [ ] Implementar o Base Repository

### Manager
- [ ] Criar o RoleManager (Permissoes: UserStore)
- [ ] Criar o UserManager
- [ ] Crair o StoreManager

---
### Para fazer:
- [ ] Implementar as Sessões
- [ ] Implementar a adição de itens por loja
- [ ] Implementar a venda de itens
- [ ] Adicionar validação de vendas utilizando um Consumer e Producer com RabbitMQ
- [ ] Melhorar o readme
- [ ] Melhorar o dockerfile
- [ ] Criar um docker compose para inicializar o rabbit, o sql server e a aplicação