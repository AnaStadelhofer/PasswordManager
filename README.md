# Sistema de Gerenciamento de Senhas

Um empresa chamada Safe Security LTDA nos procurou para o desenvolvimento de uma aplicação para gerenciamento das senhas de acesso a suas ferramenas de trabalho.

Eles necessitam que esta aplicação permita o cadastro das senhas compartilhadas entre todos os usuários, de maneira a gerenciar os acessos e permitir o compartilhamento de informações.

Desta forma, logins de administração das contas podem ser compartilhados de forma segura sem que sejam enviados por email, SMS, mensagens de texto e afins.

Desta forma, é necessário que sejam gerenciados os usuários com acesso a esta ferramenta, permitindo a criação de novos usuários e a manutenção de antigos.

Ainda, é necessário a categorização das senhas, onde estas categorias precisam ser customizadas para a necessidade da empresa, como, por exemplo, senhas de serviços externos, acesso a sites, etc.

Por fim, é necessário a criação de TAGs para as senhas, de maneira a agrupar por informações similares e para estruturas parecidas. Por exemplo, uma mesma ferramenta pode ser utilizado pela Diretoria e pelo Administrativo.

## Desenvolvimento

Para esse desenvolvimento, iremos utilizar o XAMPP com MySQL como gerenciador de banco de dados, inicialmente utilizaremos em ambiente local para posterior conexão com um banco em nuvem (Heroku).

Ainda, utilizaremos a linguagem C#, com os frameworks Entity Framework e Windows Forms para nos auxiliar neste desenvolvimento.

## Aplicação

A aplicação conta com 5 entidades:

* Categoria - Registro das informações de categorias;
* Tag - Registro das informações de Tag;
* Usuário - Registro das informações de usuário;
* Senha - Registro das informações de senha;
* SenhaTag - Tabela relacional entre Senha e Tag.

### Campos

* Categoria
    * Id - Numérico autoincremento
    * Nome - String
    * Descrição - String
* Tag
    * Id - Numérico autoincremento
    * Descrição - String
* Usuário
    * Id - Numérico autoincremento
    * Nome - String
    * Senha - String
* Senha
    * Id - Numérico autoincremento
    * Nome - String
    * CategoriaId - Numérico (Chave Estrangeira)
    * Url - String
    * Usuário - String
    * Senha - String
    * Procedimento - String
* SenhaTag
    * Id - Numérico autoincremento
    * SenhaId - Numérico (Chave Estrangeira)
    * TagId - Numérico (Chave Estrangeira)

### Restrições

* Todos os IDs são autoincrementais;
* As senhas (tanto de usuário quanto da tabela de senhas) devem possuir no mínimo 8 caracteres;
* Todas as senhas de usuário devem ser salvas criptografadas no banco de dados, as senhas da tabela de senhas podem ser planificadas;
* É possível ter várias Tags vinculadas a uma senha, mas minimamente deve haver uma Tag;
* Os emails devem ter um formato válido, tal como nome.sobrenome@email.com;
* As URLs devem ter um formato válido, tal como https://www.url.com.br;
* Não é necessário informar os procedimentos de acesso em todas as senhas;
* A descrição de uma categoria é opcional.

### Tarefas

Para essa aplicação serão necessárias as seguintes tarefas:

- [X] Processo de Login
- [X] Menu Principal
- [X] Lista de Categorias
- [X] Lista de Tags
- [X] Lista de Usuários
- [X] Lista de Senhas
- [X] Criar Categoria
- [X] Criar Tag
- [X] Criar Usuário
- [X] Criar Senha
- [X] Alterar Categoria
- [X] Alterar Tag
- [X] Alterar Usuário
- [X] Alterar Senha
- [X] Excluir Categoria
- [X] Excluir Tag
- [X] Excluir Usuário
- [ ] Excluir Senha
- [ ] Criar Relação entre Senha e Tag
- [ ] Excluir Relação entre Senha e Tag
- [ ] Criar e-mail valido
- [X] Criar senha valida
- [ ] As urls devem ter formato valido
- [ ] E-mail devem ser validos
- [x] Cor dos componentes / Desafio
- [X] Fluxo de telas ideal 
- [ ] Cadastro de usuário quando base for vazia / Desafio

### Diferenciais

Serão considerados diferenciais se assim existirem:
- Exportador de Senhas: Gerar um relatório em CSV, TXT ou Excel com todas as informações de senha e acesso;
- Cadastro de usuário inicial: Botão para gera um novo usuário se a base de usuários for vazia;
- Colorização e Customização das Telas.


## Modelagem

Serão fornecidos os modelos inicias e o esqueleto do projeto, pois utilizaremos as camadas MVC para construção e elaboração de nossa estrutura.

O banco de dados, como mencionado, será local, desta forma as migrações deverão ser criadas e rodadas localmente.

Para a aplicação de exemplo foram criadas os seguintes métodos nos controllers:

* Categoria
    * IncluirCategoria
    * AlterarCategoria
    * RemoverItem
    * GetCategorias
    * GetCategoria
* Senha
    * IncluirSenha
    * AlterarSenha
    * RemoverItem
    * GetSenhas
    * GetSenha
* SenhaTag
    * IncluirSenhaTag
    * RemoverItem
    * GetSenhaTags
    * GetSenhaTag
    * GetById
* Tag
    * IncluirTag
    * AlterarTag
    * RemoverItem
    * GetTags
    * GetTag
* Usuario
    * IncluirUsuario
    * AlterarUsuario
    * RemoverItem
    * GetUsuarios
    * GetUsuario
    * Auth

Na estrutura de View foi utilizado algumas abordagens de generalização sendo que os componentes genéricos criados foram:

* BaseForm - Elabora a base dos formulários;
* Button - Cria botões genéricos;
* Field - Cria um TextBox e Label de maneira conjunta;
* FieldCombo - Cria um ComboBox e Label de maneira conjunta;
* FieldText - Cria um TextBox (como TextArea) e Label de maneira conjunta;
* Message - Elabora as mensagens padrões de erro e confirmação.

As aboradegens dessa seção servem de guia e não de restrição de desenvolvimento.

## Entrega

Deverá ser desenvolvido a aplicação em questão e entregue através do Github. É importante que a cada novo desenvolvimento (tarefa) seja feita uma nova Branch com seu respectivo Pull Request no encerramento.

Deverá ser concluído até o dia 22/06/2022 23:59 (2022-06-22T23:59:59.0300).