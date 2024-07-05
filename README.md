# Projeto CRUD de Clientes - Supermercado

Este projeto foi desenvolvido como parte da disciplina de Programação Web 1 e consiste em um sistema CRUD (Create, Read, Update, Delete) para o cadastro de clientes de um supermercado. O sistema permite que os dados dos clientes sejam utilizados para efetuar vendas nominais no estabelecimento.

## Funcionalidades

- **Cadastro de Clientes**: Adicionar novos clientes ao sistema.
- **Listagem de Clientes**: Visualizar a lista de clientes cadastrados.
- **Atualização de Clientes**: Editar informações dos clientes cadastrados.
- **Exclusão de Clientes**: Remover clientes do sistema.
- **Autenticação de Usuário**: Sistema de login para acesso à aplicação.
- **Exportação de Dados**: Exportar o cadastro do cliente em formato JSON.

## Requisitos do Sistema

O sistema implementa os seguintes campos obrigatórios para o cadastro de clientes:

- **ID**: Código único do sistema que identifica o cliente.
- **CodigoFiscal**: CPF/CNPJ do Cliente.
- **InscricaoEstatudal**: Número com até 15 dígitos.
- **Nome**: Nome do cliente.
- **NomeFantasia**: Nome Fantasia do cliente.
- **Endereco**: Endereço do cliente.
- **Numero**: Número do endereço do cliente.
- **Bairro**: Bairro do endereço do cliente.
- **Cidade**: Cidade onde o cliente mora.
- **Estado**: Estado onde o cliente mora.
- **DataNascimento**: Data de nascimento para pessoas físicas e data de abertura para pessoas jurídicas.
- **Imagem**: Foto ou logo do cliente.

## Requisitos Obrigatórios Atendidos

- Página para cadastro de usuários.
- Senha criptografada para os usuários.
- Usuários só podem editar seus próprios perfis.
- Persistência de dados em arquivo JSON.
- Implementação completa das operações CRUD para clientes.
- Validação para evitar cadastro de Clientes com CodigoFiscal ou InscricaoEstatudal duplicados.
- Seleção de cidades a partir de uma lista pré-definida, sem possibilidade de cadastro de novas cidades.
- Tela unificada para inserção e atualização dos dados do cliente.
- Botão para exportação do cadastro do cliente em formato JSON na tela de criar/editar cliente.

## Tecnologias Utilizadas

- **Linguagem de Programação**: C# (ASP.NET Core MVC/Razor)
- **Persistência de Dados**: Arquivo JSON
- **Interface de Usuário**: Razor Pages
- **Segurança**: Criptografia de Senhas

## Como Executar o Projeto

1. **Clone o repositório**:
   ```sh
   git clone https://github.com/FabioHenrique023/supermercado_prova.git
   ```

2. **Navegue até o diretório do projeto**:
   ```sh
   cd supermercado_prova
   ```

3. **Instale as dependências**:
   ```sh
   dotnet restore
   ```

4. **Execute o projeto**:
   ```sh
   dotnet run
   ```

5. **Acesse a aplicação**:
   Abra o navegador e vá para `http://localhost:5259`

6. **Acesse com o usuário padrão**:
   - **Login**: `admin`
   - **Senha**: `123456`

## Estrutura do Projeto

- **Controllers**: Contém os controladores da aplicação.
- **Models**: Contém as classes de modelo.
- **Views**: Contém as páginas Razor.
- **Raiz do projeto**: Contém o arquivo JSON para persistência de dados.

## Contato

Fábio Henrique - fabiohomeoffice904@gmail.com

Link do Projeto: [https://github.com/FabioHenrique023/supermercado_prova.git](https://github.com/FabioHenrique023/supermercado_prova.git)
