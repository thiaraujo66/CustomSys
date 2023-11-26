
# Sistema de Gestão de Clientes

## Visão Geral
Bem-vindo ao projeto Sistema de Gestão de Clientes! Este projeto faz parte do desenvolvimento do meu portfólio, focado em criar um sistema eficiente e limpo de gestão de clientes utilizando tecnologias da Microsoft. Adotando os princípios de Clean Code e Clean Architecture, este projeto visa demonstrar as melhores práticas em design e desenvolvimento de software.

## Tecnologias Utilizadas
- **Banco de Dados:** Microsoft SQL Server
- **Backend:** .NET 7.0
- **Framework Web:** ASP.NET MVC

## Parâmetros Adotados para o Desenvolvimento do Sistema
- **O sistema não deve gerenciar os funcionários da empresa**
- **O sistema deve cadastrar, alterar e consultar os clientes**
- **O sistema deve armazenar o cpf/cnpj do cliente como chave primaria da tabela de clientes**
- **O sistema possui exclusão lógica e exclusão virtual, deixando a critério do Owner do sistema decidir qual utilizar, levando em consideração que a exclusão lógica causa menos problemas e reteem dados, já a exclusão física auxilia na diminuição do tamanho no banco de dados e performance do sistema.**
- **O sistema não permite a alteração do CPF/CNPJ do cliente uma vez que adicionado ao sistema, para isso, deve-se adicionar um novo registro com o CPF/CNPJ novo.**

## Recursos
- Gestão eficiente de dados de clientes.
- Interface web responsiva usando ASP.NET MVC para uma experiência de usuário fluida.
- Utilização dos princípios de Clean Code para manutenibilidade e legibilidade.
- Design de Clean Architecture para promover a separação de preocupações e escalabilidade.

## Como Começar
1. Clone este repositório em sua máquina local.
2. Configure seu banco de dados Microsoft SQL Server.
3. Abra a solução no Visual Studio com .NET 7.0 instalado.
4. Altere os locais que utilizam String de Conexão de Banco de dados para a sua string. Para facilitar os locais de alteração você pode utilizar o comando ctrl+shift+F e pesquisar por essa string "Server=;Database=CUSTOMSYS;User Id=sa;Password=;Encrypt=False".
5. Certifique-se que o URL da API seja https://localhost:44338/
6. Compile e execute a aplicação.

## Clean Code e Clean Architecture
Este projeto adere aos princípios de Clean Code e Clean Architecture, garantindo uma base de código bem organizada e de fácil manutenção. Sinta-se à vontade para explorar o código-fonte e ver como essas práticas são implementadas.

## Contribuições
Contribuições e feedback são bem-vindos! Se encontrar algum problema ou tiver sugestões de melhorias, por favor, abra uma issue ou envie um pull request.

## Licença
Este projeto está licenciado sob a [Licença MIT](LICENSE).

Obrigado por explorar o projeto Sistema de Gestão de Clientes!

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

# Customer Management System

## Overview
Welcome to the Customer Management System project! This project is a part of my portfolio development, with a focus on creating an efficient and clean customer management system using Microsoft technologies. Embracing the principles of Clean Code and Clean Architecture, this project aims to showcase best practices in software design and development.

## Technologies Used
- **Database:** Microsoft SQL Server
- **Backend:** .NET 7.0
- **Web Framework:** ASP.NET MVC

## System Development Parameters
- **The system should not manage company employees.**
- **The system should register, update, and query customers.**
- **The system should store the customer's CPF/CNPJ as the primary key of the customer table.**
- **The system has logical deletion and virtual deletion, leaving it to the system owner's discretion to decide which to use, considering that logical deletion causes fewer issues and retains data, while physical deletion helps reduce the database size and system performance.**
- **The system does not allow the alteration of the customer's CPF/CNPJ once added to the system. To do this, a new record with the new CPF/CNPJ must be added.**

## Features
- Efficient customer data management.
- Responsive web interface using ASP.NET MVC for a seamless user experience.
- Utilization of Clean Code principles for maintainability and readability.
- Clean Architecture design to promote separation of concerns and scalability.

## Getting Started
1. Clone this repository to your local machine.
2. Configure your Microsoft SQL Server database.
3. Open the solution in Visual Studio with .NET 7.0 installed.
4. Change the locations using the Database Connection String to your string. To facilitate the locations of change, you can use the ctrl+shift+F command and search for this string "Server=;Database=CUSTOMSYS;User Id=sa;Password=;Encrypt=False".
5. Ensure that the API URL is https://localhost:44338/
6. Build and run the application.

## Clean Code and Clean Architecture
This project adheres to the principles of Clean Code and Clean Architecture, ensuring a well-organized and maintainable codebase. Feel free to explore the source code and see how these practices are implemented.

## Contributions
Contributions and feedback are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request.

## License
This project is licensed under the [MIT License](LICENSE).

Thank you for exploring the Customer Management System project!
