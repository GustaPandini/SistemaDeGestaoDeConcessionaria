Sistema de Gestão de Concessionária (SGC)

Uma API RESTful desenvolvida em .NET para gerenciar as operações completas de uma concessionária de veículos. O sistema permite o gerenciamento de estoque de automóveis, carteira de clientes, controle de usuários do sistema (adimistradores) e registro de vendas, garantindo segurança e integridade dos dados.

🚀 Tecnologias e Ferramentas
- C# e .NET (ASP.NET Core)
- Entity Framework Core: Para acesso e mapeamento objeto-relacional (ORM) do banco de dados.
- Cloudinary: Serviço de armazenamento em nuvem para upload e gerenciamento das imagens dos automóveis.
- JWT (JSON Web Token): Padrão utilizado para gerar tokens de acesso, garantindo autenticação segura e autorização baseada em perfis (roles) nas requisições da API.
- HMACSHA512: Algoritmo de criptografia utilizado para o hash e segurança das senhas dos usuários.
- Swagger/OpenAPI: Para documentação e teste dos endpoints.

🏗️ Arquitetura e Padrões de Projeto (Design Patterns)
O projeto foi construído focando na manutenibilidade, testabilidade e baixo acoplamento, utilizando:
- Arquitetura em Camadas (N-Tier / Clean Architecture): Separação clara entre Application (Casos de uso, DTOs e Serviços) e Domain (Entidades, Interfaces e Exceções).
- Repository Pattern: Abstração da camada de acesso a dados (IClienteRepository, IAutomovelRepository), centralizando as queries e facilitando a troca de ORM ou criação de Mocks para testes.
- Service Pattern: Centralização das regras de negócio na camada de aplicação (ClienteService, AutomovelService), mantendo os Controllers limpos.
- DTO Pattern (Data Transfer Object): Separação estrita dos dados de entrada (PostDTO, PutDTO) e saída (GetDTO). Impede o vazamento de propriedades do banco de dados e controla o que é exibido ao cliente.

💼 Regras de Negócio Implementadas
Analisando o código dos serviços, destacam-se as seguintes regras de negócio e fluxos:
- Autenticação e Controle de Acesso (JWT): O sistema utiliza rotas protegidas que exigem um token Bearer válido. Existe uma separação clara de perfis:
- Rotas Autenticadas: Permitem acesso total às funcionalidades de gestão (CRUD de clientes, vendas, controle de estoque) para os usuários do sistema.
- Rotas Públicas (Deslogadas): O sistema possui endpoints específicos (ex: vitrine de carros) que não exigem o token. Nesses casos, a regra de negócio protege informações sensíveis, como ocultar a Placa e o Chassi, retornando apenas os dados comerciais do veículo para visitantes.
- Exclusão Lógica (Soft Delete): Entidades como Cliente e Automovel não são apagadas fisicamente do banco de dados. O método DeleteAsync marca a propriedade Excluido = true. O método GetAllAsync filtra automaticamente esses registros para não exibi-los.
- Reativação Inteligente de Cadastros: Se um usuário tentar cadastrar um CPF (Cliente) ou uma Placa/Chassi (Automóvel) que já existe no banco, mas está marcado como excluído, o sistema não gera duplicidade. Ele reativa o cadastro antigo (Excluido = false) e atualiza os dados com as novas informações fornecidas.
- Validações Rígidas de Entrada:
   - Placas e Chassis: Utilização de Expressões Regulares (RegEx) garantindo que apenas formatos válidos de 7 ou 17 caracteres entrem no sistema.
   - Telefone e CPF: Controle estrito de tamanho mínimo e máximo.
   - Senhas: Obrigatório o mínimo de 8 caracteres no momento do cadastro.
- Integração de Múltiplas Imagens: Um mesmo automóvel pode receber uma lista de imagens (IFormFile). O sistema faz o upload dessas imagens (Cloudinary), salva as URLs e o PublicId no banco, permitindo fácil renderização no frontend.

✨ Boas Práticas Adotadas
- Data Annotations: Validações diretamente nos DTOs ([Required], [MaxLength], [RegularExpression]), garantindo que dados inválidos não cheguem à camada de serviço.
- Paginação Customizada (PagedList<T>): Em vez de retornar milhares de registros de uma vez, as listagens (GetAllAsync) são paginadas, para montagem de grids no Front-End, melhorando a performance e economia de banda.
- Tratamento de Exceções Personalizadas: Uso de exceções de domínio como NotFoundException e BadRequestException (ex: "Cliente não encontrado", "Já existe um automóvel com essa placa"), o que facilita o retorno de Status Codes HTTP corretos no Controller.
- Injeção de Dependência (DI): Uso amplo de injeção por construtor nas classes de serviço, garantindo flexibilidade e facilidade para testes unitários.

📦 Estrutura de DTOs
- PostDTOs: Desenhados especificamente para a criação de novos recursos. Ignoram IDs e dados controlados pelo sistema.
- PutDTOs: Requerem o ID obrigatoriamente para garantir atualizações seguras no banco de dados.
- GetDTOs: Ocultam dados sensíveis da API (como senhas, ids internos de banco) e organizam os dados para o Front-end.
- GetDetailDTOs: Nos GetDetail de vendas são incluídos junto as informações do automóvel e cliente, o que tira a necessidade de realizar 3 operações de Get para mostrar ao usuário todas as informações da venda.

🔮 Próximos Passos e Aprimoramentos (Roadmap)
As seguintes melhorias estão planejadas para o futuro:
- Desenvolvimento do Front-End: Criação de uma interface de usuário (UI) responsiva e moderna, no formato Single Page Application (SPA), utilizando frameworks como React, Angular ou Vue.js. Essa aplicação consumirá a API para oferecer painéis administrativos aos funcionários da concessionária e uma vitrine digital para os clientes explorarem os veículos disponíveis.
- Hospedagem em Nuvem (Cloud Hosting): Realizar o deploy (implantação) da API e do banco de dados em um provedor de nuvem confiável, como Microsoft Azure ou AWS (Amazon Web Services). Isso garantirá alta disponibilidade (uptime), segurança em nível de produção e escalabilidade para o sistema.
- Pipeline de CI/CD (Integração e Entrega Contínuas): Configuração de fluxos automatizados (ex: via GitHub Actions ou Azure DevOps) para que novas atualizações no código passem por testes automáticos e sejam publicadas na nuvem sem interrupções.
- Dashboards e Relatórios Avançados: Criação de novos endpoints na API para retornar dados estatísticos sobre as vendas, desempenho de funcionários e giro de estoque, alimentando gráficos no futuro Front-end.
