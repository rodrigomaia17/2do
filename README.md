2do
====

Aplicação base de CRUD de Projetos, Tarefas e Colaboradores.
Tecnologias:
	
	Framework MVC : Asp.Net MVC 4  (Razor + TwitterBootstrap) http://www.asp.net/mvc - http://twitter.github.io/bootstrap/
	Persistencia: MongoDB http://www.mongodb.org/
	Framework Injeção de Dependencias: Ninject http://www.ninject.org/
	Framework Testes : MSUnit http://msdn.microsoft.com/en-us/library/ms243147(v=vs.80).aspx
	Mock Framework: Moq https://code.google.com/p/moq/
	Validation Framework : FluentValidation http://fluentvalidation.codeplex.com/
	
	Servidor de Integração Contínua: https://appharbor.com/ (Link da Aplicação: http://2do.apphb.com/ )
	
	
Processo de Desenvolvimento: 	

Busquei Aplicar design patterns (Repository, Abstract Factory , MVVM...) a medida que a necessidade fosse surgindo. As Interfaces foram geradas seguindo o padrão Basico do Twitter Bootstrap. O Projeto de Testes Contém testes unitários, e alguns testes de integração com mongoDB para conhecer melhor o funcionamento do banco e do seu Driver para C#. Há também um esboço de uma classe teste dos Controllers, que implementei para servir de uma base caso mais testes de integração sejam desenvolvidos. No Mais, dediquei maior tempo ao back-end da aplicação para garantir que a aplicação nao fuja de boas práticas. 

Efetuei a refatoração da tela de Tarefas utilizando KnockoutJS e WebAPI para responder às requisições. Em breve pretendo adequar toda a App para esse padrão.


Outras Ferramentas Utilizadas 

	SignalR - http://signalr.net/
	KnockoutJs - http://knockoutjs.com/

	
	
