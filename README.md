# Bank_Account_Management

Projeto criado a fim de simular uma arquitetura de MS, onde diversas API's, se comunicam entre si e cada uma possui um papel único.

## 🚀 Começando
Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.

## Índice

- [Instalação](#instalação)
- [Configuração](#configuração)
- [Uso](#uso)
- [Endpoints](#endpoints)
- [Contribuição](#contribuição)

## Instalação

Certifique-se de ter o .Net instalado em seu sistema antes de prosseguir.

**1. Clone o repositório:**
   ```
   git clone [https://github.com/MarcosVenicioSJr/Bank_Account_Management.git]
  ```

**2. Navegue até o diretório da API:**
   ```
   cd Bank_Account_Management
  ```
**3. Baixe e as dependências:**
   ```
   dotnet restore
  ```
**4. Compile e execute a API:**
   ```
   dotnet build
  ```

Para executar o projeto, se faz necessário a criação de um banco de dados primeiro, siga para o MySql e crie um Database com o nome que se encontra na conexão ou modifique a conexão para uma da sua preferência

**Observação: Caso não queira realizar o uso do mysql, também é possivel utilizar o sqlite, só necessita tê-lo instalado na máquina, que é criado automaticamente a migração do banco de dados.**

## Endpoints
A API possui endpoints para Transferência de Dinheiro, Criação de Conta, Login, Saque, Depósito.

Para realizar quaisquer umas das ações, será necessário criar um usuário, após isso, será possivel conseguir a autenticação para realizar quaisquer outras ações.

## Contribuição

Se você deseja contribuir para este projeto, siga estas etapas:

- Fork do repositório
- Crie um branch para sua feature (git checkout -b feature/sua-feature)
- Faça commit das suas alterações (git commit -m 'Adicione sua feature')
- Faça push para o branch (git push origin feature/sua-feature)
- Abra um Pull Request
- Certifique-se de seguir as diretrizes de contribuição 
